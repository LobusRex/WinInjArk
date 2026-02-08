using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WinInjArk.Client.DomainObjects;

namespace WinInjArk.Client.DomainObjectList;

internal static class ListFormRegistration
{
	public static IServiceCollection AddListForm(
		this IServiceCollection services)
	{
		services.AddTransient<ListForm>();

		services.AddSingleton<ListFormOpener>(
			implementationFactory: serviceProvider =>
				new ListFormOpener(
					formFactory: () =>
						serviceProvider.GetRequiredService<ListForm>()));

		services.TryAddSingleton<IDomainObjectService, DomainObjectService>();

		return services;
	}
}
