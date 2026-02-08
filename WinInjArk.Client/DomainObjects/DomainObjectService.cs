namespace WinInjArk.Client.DomainObjects;

internal interface IDomainObjectService
{
	public List<DomainObject> GetDomainObjects();
	public DomainObject GetDomainObject(string id);
}

internal class DomainObjectService : IDomainObjectService
{
	private readonly List<DomainObject> _domainObjects =
		[
			new DomainObject(Id: "1", Name: "First", Description: "The first domain object."),
			new DomainObject(Id: "2", Name: "Second", Description: "The second domain object."),
			new DomainObject(Id: "3", Name: "Third", Description: "The third domain object!"),
		];

	public DomainObject GetDomainObject(string id)
	{
		return _domainObjects
			.Single(o => o.Id == id);
	}

	public List<DomainObject> GetDomainObjects() => [.. _domainObjects];
}
