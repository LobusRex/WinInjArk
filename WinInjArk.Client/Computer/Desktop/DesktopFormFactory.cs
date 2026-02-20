using Microsoft.Extensions.DependencyInjection;
using WinInjArk.Forms;

namespace WinInjArk.Client.Computer.Desktop;

internal class DesktopFormFactory : IFormFactory<DesktopForm>
{
    public DesktopForm Create(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<DesktopForm>();
    }
}
