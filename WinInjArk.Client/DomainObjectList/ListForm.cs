using Microsoft.Extensions.Logging;
using WinInjArk.Client.DomainObjects;

namespace WinInjArk.Client;

internal partial class ListForm : Form
{
	private readonly ILogger<ListForm> _logger;
	private readonly DomainObjectService _domainObjectService;

	public ListForm(
		ILogger<ListForm> logger,
		DomainObjectService domainObjectService)
	{
		InitializeComponent();
		_logger = logger;
		_domainObjectService = domainObjectService;
		_logger.LogInformation($"Constructed {nameof(ListForm)}");
	}

	private void listForm_Load(object sender, EventArgs e)
	{
		var domainObjects = _domainObjectService.GetDomainObjects();

		listBox1.BeginUpdate();
		foreach (var item in domainObjects)
			listBox1.Items.Add(item);
		listBox1.EndUpdate();
	}

	private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		var index = listBox1.IndexFromPoint(e.Location);

		if (index == ListBox.NoMatches)
			return;

		var item = listBox1.Items[index];

		// TODO: use item to open another form.
	}
}
