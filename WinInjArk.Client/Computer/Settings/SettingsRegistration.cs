using Microsoft.Extensions.DependencyInjection;
using WinInjArk.Forms;

namespace WinInjArk.Client.Computer.Settings;

internal static class SettingsRegistration
{
    public static IServiceCollection AddSettings(
        this IServiceCollection services)
    {
        services.AddScoped<SettingsForm>();
        services.AddSingleton<IFormFactory<SettingsForm>, SettingsFormFactory>();
        services.AddSingleton<OnlyOne_FormOpener<SettingsForm>>();

        return services;
    }
}
