using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WinInjArk.Client.Logging;

namespace WinInjArk.Client;

internal static class WinInjArkRegistration
{
	public static IServiceCollection AddWinInjArkClientServices(
		this IServiceCollection services)
	{
		services.AddTransient<MainForm>();
		services.AddSingleton<IFormLogSink, FormLogSink>();

		return services;
	}
}
