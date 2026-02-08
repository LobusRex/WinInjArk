using Microsoft.Extensions.DependencyInjection;
using WinInjArk.Client.DomainObjects.ListForm;
using WinInjArk.Client.DomainObjects.ObjectForm;
using WinInjArk.Client.Logging;

namespace WinInjArk.Client;

internal static class WinInjArkRegistration
{
	public static IServiceCollection AddWinInjArkClientServices(
		this IServiceCollection services)
	{
		// TODO: Look at this registration again.
		// Both the logging sink and MainForm requires this.
		// Maybe TryAddSingleton in both cases?
		services.AddSingleton<IFormLogSink, FormLogSink>();
		services.AddTransient<MainForm>();

		services.AddListForm();
		services.AddDomainObjectForm();

		return services;
	}
}
