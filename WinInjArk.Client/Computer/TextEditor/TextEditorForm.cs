using Microsoft.Extensions.Logging;
using File = WinInjArk.Client.Computer.Files.File;

namespace WinInjArk.Client.Computer.TextEditor;

public partial class TextEditorForm : Form
{
    private readonly ILogger<TextEditorForm> _logger;
    private readonly File _file;

    public TextEditorForm(
        ILogger<TextEditorForm> logger,
        FormIdentity formIdentity)
    {
        InitializeComponent();
        _logger = logger;
        // TODO: Probably want to do this before initializing all components.
        _file = formIdentity.Value as File ?? throw new ArgumentException($"The {nameof(FormIdentity)} of {nameof(TextEditorForm)} must be a {nameof(File)}.", nameof(formIdentity));
    }

    private void textEditorForm_Load(object sender, EventArgs e)
    {
        _logger.LogInformation($"{nameof(TextEditorForm)} loading with {{fileName}}.", _file.Name);
        
        Text = _file.Name;
    }
}
