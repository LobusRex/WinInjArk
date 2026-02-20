using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WinInjArk.Forms;

namespace WinInjArk;

public class OnlyOne_FormOpener<TForm> where TForm : Form
{
	private readonly ILogger<OnlyOne_FormOpener<TForm>> _logger;
	private readonly Func<IServiceProvider, TForm> _formFactory;
	private readonly IServiceScopeFactory _serviceScopeFactory;

	private record FormScope(TForm Form, IServiceScope Scope);
	private FormScope? _formScope = null;

	public OnlyOne_FormOpener(
		ILogger<OnlyOne_FormOpener<TForm>> logger,
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

	public OnlyOne_FormOpener(
		ILogger<OnlyOne_FormOpener<TForm>> logger,
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
		if (_formScope is not null)
		{
			_formScope.Form.Focus();
			return;
		}

		var scope = _serviceScopeFactory.CreateScope();
		var serviceProvider = scope.ServiceProvider;
		var form = _formFactory(serviceProvider);

		_formScope = new FormScope(
			Form: form,
			Scope: scope);

		form.Disposed += form_Disposed;

		form.Show();
	}

	private void form_Disposed(object? sender, EventArgs e)
	{
		if (sender is not TForm form)
			return;

		if (_formScope is null || _formScope.Form != form)
			return;

		form.Disposed -= form_Disposed;

		var scope = _formScope.Scope;
		_formScope = null;

		scope.Dispose();
	}
}
