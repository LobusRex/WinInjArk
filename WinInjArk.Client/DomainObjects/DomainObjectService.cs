namespace WinInjArk.Client.DomainObjects;

internal interface IDomainObjectService
{
	public List<DomainObject> GetDomainObjects();
}

internal class DomainObjectService : IDomainObjectService
{
	private readonly List<DomainObject> _domainObjects =
		[
			new DomainObject(Id: "1", Name: "First", Description: "The first domain object."),
			new DomainObject(Id: "2", Name: "Second", Description: "The second domain object."),
			new DomainObject(Id: "3", Name: "Third", Description: "The third domain object!"),
		];

	public List<DomainObject> GetDomainObjects() => [.. _domainObjects];
}
