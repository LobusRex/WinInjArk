using Microsoft.Extensions.DependencyInjection;
using WinInjArk.Forms;

namespace WinInjArk.Client.Computer.Email;

internal static class EmailRegistration
{
    public static IServiceCollection AddEmail(
        this IServiceCollection services)
    {
        services.AddScoped<EmailForm>();
        services.AddSingleton<IFormFactory<EmailForm>, EmalFormFactory>();
        services.AddSingleton<OnlyOne_FormOpener<EmailForm>>();

        return services;
    }
}
