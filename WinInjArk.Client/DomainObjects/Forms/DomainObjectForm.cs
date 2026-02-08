using WinInjArk.Client.DomainObjects;

namespace WinInjArk.Client;

internal partial class DomainObjectForm : Form
{
	private readonly string _objectId;
	private readonly IDomainObjectService _domainObjectService;

	public string ObjectId => _objectId;

	public DomainObjectForm(
		string objectId,
		IDomainObjectService domainObjectService)
	{
		InitializeComponent();

		_objectId = objectId;
		_domainObjectService = domainObjectService;
	}

	private void domainObjectForm_Load(object sender, EventArgs e)
	{
		var domainObject = _domainObjectService.GetDomainObject(id: _objectId);

		textBoxId.Text = domainObject.Id;
		textBoxName.Text = domainObject.Name;
		textBoxDescription.Text = domainObject.Description;
	}
}
