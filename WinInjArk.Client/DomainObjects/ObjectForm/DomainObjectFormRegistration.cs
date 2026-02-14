using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace WinInjArk.Client.DomainObjects.ObjectForm;

internal static class DomainObjectFormRegistration
{
	public static IServiceCollection AddDomainObjectForm(
		this IServiceCollection services)
	{
		services.AddSingleton<DomainObjectFormOpener>(
			implementationFactory: serviceProvider =>
				new DomainObjectFormOpener(
					logger: serviceProvider.GetRequiredService<ILogger<DomainObjectFormOpener>>(),
					formFactory: (serviceProvider2, id) =>
					{
						var form = new DomainObjectForm(
							objectId: id,
							domainObjectService: serviceProvider2.GetRequiredService<IDomainObjectService>());
						return form;
					},
					serviceProvider.GetRequiredService<IServiceScopeFactory>()));
						

		services.TryAddSingleton<IDomainObjectService, DomainObjectService>();

		return services;
	}
}
