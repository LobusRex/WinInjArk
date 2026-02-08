using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WinInjArk.Client.Logging;

namespace WinInjArk.Client;

internal static class Program
{
	/// <summary>
	///  The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main(string[] args)
	{
		// To customize application configuration such as set high DPI settings or default font,
		// see https://aka.ms/applicationconfiguration.
		ApplicationConfiguration.Initialize();

		var builder = Host.CreateApplicationBuilder(args);

		builder.Logging
			.AddDebug()
			.AddFormLogging();

		builder.Services.AddWinInjArkClientServices();

		using var host = builder.Build();

		var mainForm = host.Services.GetRequiredService<MainForm>();

		// TODO: Figure out what to do with the host.
		// ChatGPT suggested running host.Start() before Application.Run
		// and await host.StopAsync() after Application.Run.

		Application.Run(mainForm: mainForm);
	}
}
