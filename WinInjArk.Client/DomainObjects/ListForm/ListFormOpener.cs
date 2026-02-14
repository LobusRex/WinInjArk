using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WinInjArk.Client.DomainObjects.ListForm;

internal class ListFormOpener
{
	private readonly ILogger<ListFormOpener> _logger;
	private readonly Func<IServiceProvider, ListForm> _formFactory;
	private readonly IServiceScopeFactory _serviceScopeFactory;
	private readonly Dictionary<ListForm, IServiceScope> _scopes = [];

	public ListFormOpener(
		ILogger<ListFormOpener> logger,
		Func<IServiceProvider, ListForm> formFactory,
		IServiceScopeFactory serviceScopeFactory)
	{
		_logger = logger;
		_formFactory = formFactory;
		_serviceScopeFactory = serviceScopeFactory;
	}

	public void Open()
	{
		var scope = _serviceScopeFactory.CreateScope();
		var serviceProvider = scope.ServiceProvider;
		_logger.LogInformation(
			"Created scope: {scopeHash} and serviceProvider {serviceProviderHash}",
			scope.GetHashCode(),
			serviceProvider.GetHashCode());

		_logger.LogInformation($"Creating new {nameof(ListForm)}.");
		var listForm = _formFactory(serviceProvider);

		_scopes[listForm] = scope;
		//listForm.FormClosed += listForm_FormClosed;
		listForm.Disposed += listForm_Disposed;

		listForm.Show();
	}

	private void listForm_Disposed(object? sender, EventArgs e)
	{
		if (sender is not ListForm listForm)
			return;

		listForm.Disposed -= listForm_Disposed;

		var scope = _scopes[listForm];

		_scopes.Remove(listForm);

		scope.Dispose();

		_logger.LogInformation("Deleted scope: {scopeHash}", scope.ServiceProvider.GetHashCode());
	}
}

//internal class FormOpener<TForm> where TForm : Form
//{
//	private readonly Func<TForm> _formFactory;

//	public FormOpener(Func<TForm> formFactory)
//	{
//		_formFactory = formFactory;
//	}

//	public void Open()
//	{
//		// Who owns form? Who should dispose of it?

//		var form = _formFactory();
//		form.Show();
//	}
//}