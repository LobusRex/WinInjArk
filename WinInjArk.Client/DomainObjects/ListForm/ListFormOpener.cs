namespace WinInjArk.Client.DomainObjects.ListForm;

internal class ListFormOpener
{
	private readonly Func<ListForm> _formFactory;

	public ListFormOpener(Func<ListForm> formFactory)
	{
		_formFactory = formFactory;
	}

	public void Open()
	{
		var listForm = _formFactory();
		listForm.Show();
	}
}
