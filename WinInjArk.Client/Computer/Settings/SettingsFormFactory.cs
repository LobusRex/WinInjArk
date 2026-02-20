using Microsoft.Extensions.DependencyInjection;
using WinInjArk.Forms;

namespace WinInjArk.Client.Computer.Settings;

public class SettingsFormFactory : IFormFactory<SettingsForm>
{
    public SettingsForm Create(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<SettingsForm>();
    }
}
