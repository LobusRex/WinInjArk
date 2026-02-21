using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WinInjArk.Forms;

namespace WinInjArk;

public record FormIdentity(object Value);

public class OneOfEach_FormOpener<TForm> where TForm : Form
{
	private readonly ILogger<OneOfEach_FormOpener<TForm>> _logger;
	private readonly Func<IServiceProvider, FormIdentity, TForm> _formFactory;
	private readonly IServiceScopeFactory _serviceScopeFactory;

	private record FormIdentityScope(
		TForm Form,
		FormIdentity Identity,
		IServiceScope Scope);
	private readonly List<FormIdentityScope> _instances = [];

	private OneOfEach_FormOpener(
		ILogger<OneOfEach_FormOpener<TForm>> logger,
		Func<IServiceProvider, FormIdentity, TForm> formFactory,
		IServiceScopeFactory serviceScopeFactory)
	{
		ArgumentNullException.ThrowIfNull(logger, nameof(logger));
		ArgumentNullException.ThrowIfNull(formFactory, nameof(formFactory));
		ArgumentNullException.ThrowIfNull(serviceScopeFactory, nameof(serviceScopeFactory));

		_logger = logger;
		_formFactory = formFactory;
		_serviceScopeFactory = serviceScopeFactory;
	}

	public OneOfEach_FormOpener(
        ILogger<OneOfEach_FormOpener<TForm>> logger,
        IServiceScopeFactory serviceScopeFactory,
        IIDentityFormFactory<TForm> formFactory)
	: this(
		  logger,
		  formFactory.Create,
		  serviceScopeFactory)
	{

	}


    public void Open(FormIdentity formIdentity)
	{
		if (_instances.Any(i => i.Identity == formIdentity)) // Don't think this works...
		{
			var form = _instances.First(i => i.Identity == formIdentity).Form;

			form.Focus();

			return;
		}
		else
		{
			var scope = _serviceScopeFactory.CreateScope();
			var serviceProvider = scope.ServiceProvider;
			var form = _formFactory(serviceProvider, formIdentity);

			_instances.Add(new FormIdentityScope(form, formIdentity, scope));

			form.Disposed += form_Disposed;

			form.Show(); 
		}
	}

	private void form_Disposed(object? sender, EventArgs e)
	{
		if (sender is not TForm form)
			return;

		form.Disposed -= form_Disposed;

		var formIdentityScope = _instances.Single(i => i.Form == form);

		_instances.Remove(formIdentityScope);

		formIdentityScope.Scope.Dispose();
	}
}
