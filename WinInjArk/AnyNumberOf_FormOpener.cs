using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WinInjArk.Forms;

namespace WinInjArk;

public class AnyNumberOf_FormOpener<TForm> where TForm : Form
{
	private readonly ILogger<AnyNumberOf_FormOpener<TForm>> _logger;
	private readonly Func<IServiceProvider, TForm> _formFactory;
	private readonly IServiceScopeFactory _serviceScopeFactory;

	private readonly Dictionary<TForm, IServiceScope> _scopes = [];

	// TODO: Change argument order. It would be nice to have the factory last.
	// TODO: Get rid of this constructor?
	private AnyNumberOf_FormOpener(
		ILogger<AnyNumberOf_FormOpener<TForm>> logger,
		Func<IServiceProvider, TForm> formFactory,
		IServiceScopeFactory serviceScopeFactory)
	{
		ArgumentNullException.ThrowIfNull(logger, nameof(logger));
		ArgumentNullException.ThrowIfNull(formFactory, nameof(formFactory));
		ArgumentNullException.ThrowIfNull(serviceScopeFactory, nameof(serviceScopeFactory));

		_logger = logger;
		_formFactory = formFactory;
		_serviceScopeFactory = serviceScopeFactory;
	}

	public AnyNumberOf_FormOpener(
		ILogger<AnyNumberOf_FormOpener<TForm>> logger,
		IServiceScopeFactory serviceScopeFactory,
		IFormFactory<TForm> formFactory)
	: this(
		  logger,
		  formFactory.Create,
		  serviceScopeFactory)
	{

	}

	public void Open()
	{
		var scope = _serviceScopeFactory.CreateScope();
		var serviceProvider = scope.ServiceProvider;
		var form = _formFactory(serviceProvider);

		_scopes[form] = scope;

		form.Disposed += form_Disposed;

		form.Show();
	}

	private void form_Disposed(object? sender, EventArgs e)
	{
		if (sender is not TForm form)
			return;

		form.Disposed -= form_Disposed;

		var scope = _scopes[form];

		_scopes.Remove(form);

		scope.Dispose();
	}
}
