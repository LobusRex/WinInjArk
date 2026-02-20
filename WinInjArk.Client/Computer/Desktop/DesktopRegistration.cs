using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WinInjArk.Forms;

namespace WinInjArk.Client.Computer.Desktop;

internal static class DesktopRegistration
{
    public static IServiceCollection AddDesktop(
        this IServiceCollection services)
    {
        services.TryAddSingleton<TimeProvider>(TimeProvider.System);
        
        // TODO: Can we move this section into WinInjArk.Forms?
        // Can we make it impossible for anyone outside of WinInjArk to request an IFormFactory?
        // Maybe by having FormOpeners ask for an IInternalFormFactory which inherits from IFormFactory.
        // OR: Maybe we can just make a generic class in the project.
        // Don't even need to force the programmer to make their own implemenetation.
        services.AddScoped<DesktopForm>();
        services.AddSingleton<IFormFactory<DesktopForm>, DesktopFormFactory>();
        services.AddSingleton<OnlyOne_FormOpener<DesktopForm>>();

        return services;
    }
}
