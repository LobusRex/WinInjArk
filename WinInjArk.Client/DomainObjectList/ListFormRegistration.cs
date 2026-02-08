using Microsoft.Extensions.DependencyInjection;
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

		services.AddSingleton<DomainObjectService>();

		return services;
	}
}
