using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WinInjArk.Client.DomainObjects.ObjectForm;

internal class DomainObjectFormOpener
{
	private readonly ILogger<DomainObjectFormOpener> _logger;
	private readonly Func<IServiceProvider, string, DomainObjectForm> _formFactory;
	private readonly IServiceScopeFactory _serviceScopeFactory;
	private readonly Dictionary<DomainObjectForm, IServiceScope> _scopes = [];

	public DomainObjectFormOpener(
		ILogger<DomainObjectFormOpener> logger,
		Func<IServiceProvider, string, DomainObjectForm> formFactory,
		IServiceScopeFactory serviceScopeFactory)
	{
		_logger = logger;
		_formFactory = formFactory;
		_serviceScopeFactory = serviceScopeFactory;
	}

	public void Open(string id)
	{
		var form = _scopes.Keys.FirstOrDefault(f => f.ObjectId == id);

		if (form is null)
		{
			var scope = _serviceScopeFactory.CreateScope();
			var serviceProvider = scope.ServiceProvider;
			_logger.LogInformation(
				"Created scope: {scopeHash} and serviceProvider {serviceProviderHash}",
				scope.GetHashCode(),
				serviceProvider.GetHashCode());

			_logger.LogInformation($"Creating new {nameof(DomainObjectForm)} with ID {{objectId}}.", id);
			form = _formFactory(serviceProvider, id);

			_scopes.Add(form, scope);

			// Both of these cause double form Disposing.
			//form.FormClosed += form_FormClosed;
			form.Disposed += form_Disposed;

			form.Show();
		}
		else
		{
			_logger.LogInformation($"{nameof(DomainObjectForm)} with ID {{objectId}} already exists.", id);

			form.Focus();
		}
	}

	private void form_Disposed(object? sender, EventArgs e)
	{
		if (sender is not DomainObjectForm form)
			return;

		_logger.LogInformation($"Deleting {nameof(DomainObjectForm)} with ID {{objectId}}.", form.ObjectId);

		form.FormClosed -= form_Disposed;

		var scope = _scopes[form];

		_scopes.Remove(form);

		scope.Dispose();
	}
}
