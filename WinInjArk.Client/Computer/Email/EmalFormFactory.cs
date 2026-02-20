using Microsoft.Extensions.DependencyInjection;
using WinInjArk.Forms;

namespace WinInjArk.Client.Computer.Email;

internal class EmalFormFactory : IFormFactory<EmailForm>
{
    public EmailForm Create(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<EmailForm>();
    }
}
