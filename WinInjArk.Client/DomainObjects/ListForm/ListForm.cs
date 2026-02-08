using Microsoft.Extensions.Logging;
using WinInjArk.Client.DomainObjects.ObjectForm;

namespace WinInjArk.Client.DomainObjects.ListForm;

internal partial class ListForm : Form
{
	private readonly ILogger<ListForm> _logger;
	private readonly IDomainObjectService _domainObjectService;
	private readonly DomainObjectFormOpener? _domainObjectFormOpener;

	public ListForm(
		ILogger<ListForm> logger,
		IDomainObjectService domainObjectService,
		DomainObjectFormOpener? domainObjectFormOpener = null)
	{
		InitializeComponent();
		_logger = logger;
		_domainObjectService = domainObjectService;
		_domainObjectFormOpener = domainObjectFormOpener;
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

		if (item is not DomainObject domainObject)
			return;

		if (_domainObjectFormOpener is null)
		{
			_logger.LogInformation($"There is no {nameof(DomainObjectFormOpener)}.");
			return;
		}

		_domainObjectFormOpener.Open(domainObject.Id);
	}
}
