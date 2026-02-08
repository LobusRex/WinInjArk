using Microsoft.Extensions.Logging;

namespace WinInjArk.Client.DomainObjects.Forms;

internal class DomainObjectFormOpener
{
	private readonly ILogger<DomainObjectFormOpener> _logger;
	private readonly Func<string, DomainObjectForm> _formFactory;
	private readonly List<DomainObjectForm> _existingForms = [];

	public DomainObjectFormOpener(
		ILogger<DomainObjectFormOpener> logger,
		Func<string, DomainObjectForm> formFactory)
	{
		_logger = logger;
		_formFactory = formFactory;
	}

	public void Open(string id)
	{
		var form = _existingForms
			.FirstOrDefault(f => f.ObjectId == id);

		if (form is null)
		{
			_logger.LogInformation($"Creating new {nameof(DomainObjectForm)} with ID {{objectId}}.", id);

			form = _formFactory(id);
			_existingForms.Add(form);
			form.FormClosed += form_FormClosed;

			form.Show();
		}
		else
		{
			_logger.LogInformation($"{nameof(DomainObjectForm)} with ID {{objectId}} already exists.", id);

			form.Focus();
		}
	}

	private void form_FormClosed(object? sender, FormClosedEventArgs e)
	{
		if (sender is not DomainObjectForm form)
			return;

		_logger.LogInformation($"Deleting {nameof(DomainObjectForm)} with ID {{objectId}}.", form.ObjectId);

		_existingForms.Remove(form);
		form.FormClosed -= form_FormClosed;
	}
}
