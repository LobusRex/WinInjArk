using Microsoft.Extensions.DependencyInjection;
using WinInjArk.Forms;

namespace WinInjArk.Client.Computer.Files;

internal static class FilesRegistration
{
    public static IServiceCollection AddFiles(
        this IServiceCollection services)
    {
        services.AddScoped<FilesForm>();
        services.AddSingleton<IFormFactory<FilesForm>, FilesFormFactory>();
        services.AddSingleton<AnyNumberOf_FormOpener<FilesForm>>();

        services.AddScoped<IFileSystemService, FileSystemService>();

        return services;
    }
}
