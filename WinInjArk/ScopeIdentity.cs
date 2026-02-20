using Microsoft.Extensions.DependencyInjection;

namespace WinInjArk;

/// <summary>
/// A <see cref="Guid"/> assigned to each scope.
/// Register this feature with <see cref="ScopeIdentityRegistration.AddScopeIdentity"/>.
/// </summary>
public record ScopeIdentity
{
	public Guid Id { get; } = Guid.NewGuid();

	/// <summary>
	/// A shorter version of <see cref="Id"/> to help quickly distinguishing different identities.
	/// </summary>
	public string Short => Id.ToString()[..8];
}

public static class ScopeIdentityRegistration
{
	public static IServiceCollection AddScopeIdentity(this IServiceCollection services)
	{
		return services.AddScoped<ScopeIdentity>();
	}
}
