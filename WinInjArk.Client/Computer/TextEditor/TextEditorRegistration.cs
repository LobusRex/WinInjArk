using Microsoft.Extensions.DependencyInjection;
using WinInjArk.Forms;

namespace WinInjArk.Client.Computer.TextEditor;

internal static class TextEditorRegistration
{
    public static IServiceCollection AddTextEditor(
        this IServiceCollection services)
    {
        services.AddScoped<TextEditorForm>();
        services.AddSingleton<IIDentityFormFactory<TextEditorForm>, TextEditorFormFactory>();
        services.AddSingleton<OneOfEach_FormOpener<TextEditorForm>>();

        return services;
    }
}
