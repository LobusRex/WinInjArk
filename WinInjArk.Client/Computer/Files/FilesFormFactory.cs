using Microsoft.Extensions.DependencyInjection;
using WinInjArk.Forms;

namespace WinInjArk.Client.Computer.Files;

internal class FilesFormFactory : IFormFactory<FilesForm>
{
    public FilesForm Create(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<FilesForm>();
    }
}
