using Microsoft.Extensions.DependencyInjection;
using WinInjArk.Client.Computer.Desktop;
using WinInjArk.Client.Computer.Email;
using WinInjArk.Client.Computer.Files;
using WinInjArk.Client.Computer.Settings;
using WinInjArk.Client.Computer.TextEditor;

namespace WinInjArk.Client.Computer;

internal static class ComputerRegistration
{
    public static IServiceCollection AddComputer(this IServiceCollection services)
    {
        services.AddDesktop();
        services.AddFiles();
        services.AddEmail();
        services.AddSettings();
        services.AddTextEditor();

        return services;
    }
}
