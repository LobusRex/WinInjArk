using Microsoft.Extensions.DependencyInjection;
using WinInjArk.Forms;

namespace WinInjArk.Client.Computer.TextEditor;

internal class TextEditorFormFactory : IIDentityFormFactory<TextEditorForm>
{
    public TextEditorForm Create(
        IServiceProvider serviceProvider,
        FormIdentity formIdentity)
    {
        return ActivatorUtilities.CreateInstance<TextEditorForm>(
            provider: serviceProvider,
            formIdentity);
    }
}