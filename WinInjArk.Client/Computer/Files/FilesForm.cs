using Microsoft.Extensions.Logging;
using WinInjArk.Client.Computer.TextEditor;

namespace WinInjArk.Client.Computer.Files;

public partial class FilesForm : Form
{
    private readonly ILogger<FilesForm> _logger;
    private readonly IFileSystemService _fileSystemService;
    private readonly OneOfEach_FormOpener<TextEditorForm>? _textEditorFormOpener;

    public FilesForm(
        ILogger<FilesForm> logger,
        IFileSystemService fileSystemService,
        OneOfEach_FormOpener<TextEditorForm>? textEditorFormOpener = null)
    {
        InitializeComponent();
        _logger = logger;
        _fileSystemService = fileSystemService;
        _textEditorFormOpener = textEditorFormOpener;
        listBoxFiles.DisplayMember = nameof(File.Name);
    }

    private void filesForm_Load(object sender, EventArgs e)
    {
        var files = _fileSystemService.GetAllFiles();

        listBoxFiles.BeginUpdate();
        foreach (var file in files)
            listBoxFiles.Items.Add(file);
        listBoxFiles.EndUpdate();
    }

    private void listBoxFiles_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        var index = listBoxFiles.IndexFromPoint(e.Location);

        if (index == ListBox.NoMatches)
            return;

        var item = listBoxFiles.Items[index];

        if (item is not File file)
            return;

        if (_textEditorFormOpener is null)
        {
            _logger.LogInformation($"There is no {nameof(OneOfEach_FormOpener<TextEditorForm>)}.");
            return;
        }

        _textEditorFormOpener.Open(new FormIdentity(Value: file));
    }
}
