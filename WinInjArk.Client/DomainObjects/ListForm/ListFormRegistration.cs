using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace WinInjArk.Client.DomainObjects.ListForm;

internal static class ListFormRegistration
{
	public static IServiceCollection AddListForm(
		this IServiceCollection services)
	{
		services.AddTransient<ListForm>();

		services.AddSingleton<ListFormOpener>(
			implementationFactory: serviceProvider =>
				new ListFormOpener(
					logger: serviceProvider.GetRequiredService<ILogger<ListFormOpener>>(),
					formFactory: serviceProvider2 => serviceProvider2.GetRequiredService<ListForm>(),
					serviceScopeFactory: serviceProvider.GetRequiredService<IServiceScopeFactory>()));

		services.TryAddSingleton<IDomainObjectService, DomainObjectService>();

		return services;
	}
}
