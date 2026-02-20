using Microsoft.Extensions.DependencyInjection;

namespace WinInjArk.Experimentation.Scopes;

[TestClass]
public sealed class AreScopesDistinguishable_Tests
{
	// Can't remember why I wanted to test this? Was this the original goal?
	// The tests below probably covered what I was after.
	// TODO: Clean this up. Move the real tests to a better place.
	[TestMethod]
	public void TestMethod1()
	{
		// Arrange.
		var serviceScopeFactory = new ServiceCollection()
			.BuildServiceProvider()
			.GetRequiredService<IServiceScopeFactory>();

		// Act.
		var scope1 = serviceScopeFactory.CreateScope();
		var scope2 = serviceScopeFactory.CreateScope();
		var scope3 = serviceScopeFactory.CreateScope();

		// Assert.
		Assert.AreNotSame(scope1.GetHashCode(), scope2.GetHashCode());
		Assert.AreNotSame(scope1.GetHashCode(), scope3.GetHashCode());
		Assert.AreNotSame(scope2.GetHashCode(), scope3.GetHashCode());
	}

	[TestMethod]
	public void GetScopeIdentities_ShouldNotBeSame()
	{
		// Arrange.
        var serviceScopeFactory = new ServiceCollection()
			.AddScopeIdentity()
            .BuildServiceProvider()
            .GetRequiredService<IServiceScopeFactory>();
        var scope1 = serviceScopeFactory.CreateScope();
        var scope2 = serviceScopeFactory.CreateScope();

		// Act.
		var scopeIdentity1 = scope1.ServiceProvider.GetRequiredService<ScopeIdentity>();
		var scopeIdentity2 = scope2.ServiceProvider.GetRequiredService<ScopeIdentity>();

		// Assert.
		Assert.AreNotEqual(scopeIdentity1.Id, scopeIdentity2.Id);
    }

    [TestMethod]
    public void GetNestedScopeIdentities_ShouldNotBeSame()
    {
		// Arrange.
		var serviceProvider = new ServiceCollection()
			.AddScopeIdentity()
			.BuildServiceProvider();
        var scope1 = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var scope2 = scope1.ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();

        // Act.
        var scopeIdentity1 = scope1.ServiceProvider.GetRequiredService<ScopeIdentity>();
        var scopeIdentity2 = scope2.ServiceProvider.GetRequiredService<ScopeIdentity>();

        // Assert.
        Assert.AreNotEqual(scopeIdentity1.Id, scopeIdentity2.Id);
    }
}
