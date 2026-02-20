using Microsoft.Extensions.Logging;
using WinInjArk.Client.Computer.Email;
using WinInjArk.Client.Computer.Files;
using WinInjArk.Client.Computer.Settings;

namespace WinInjArk.Client.Computer.Desktop;

public partial class DesktopForm : Form
{
    private readonly ILogger<DesktopForm> _logger;
    private readonly TimeProvider _timeProvider;
    private readonly AnyNumberOf_FormOpener<FilesForm>? _filesFormOpener;
    private readonly OnlyOne_FormOpener<EmailForm>? _emailFormOpener;
    private readonly OnlyOne_FormOpener<SettingsForm>? _settingsFormOpener;

    public DesktopForm(
        ILogger<DesktopForm> logger,
        TimeProvider timeProvider,
        AnyNumberOf_FormOpener<FilesForm>? filesFormOpener = null,
        OnlyOne_FormOpener<EmailForm>? emailFormOpener = null,
        OnlyOne_FormOpener<SettingsForm>? settingsFormOpener = null)
    {
        InitializeComponent();
        _logger = logger;
        _timeProvider = timeProvider;
        _filesFormOpener = filesFormOpener;
        _emailFormOpener = emailFormOpener;
        _settingsFormOpener = settingsFormOpener;
    }

    private void desktopForm_Load(object sender, EventArgs e)
    {
        buttonFiles.Enabled = _filesFormOpener is not null;
        buttonEmail.Enabled = _emailFormOpener is not null;
        buttonSettings.Enabled = _settingsFormOpener is not null;
    }

    private void buttonFiles_Click(object sender, EventArgs e)
    {
        _logger.LogDebug($"Cliced {nameof(buttonFiles)}");

        _filesFormOpener?.Open();
    }

    private void buttonEmail_Click(object sender, EventArgs e)
    {
        _logger.LogDebug($"Cliced {nameof(buttonEmail)}");

        _emailFormOpener?.Open();
    }

    private void buttonSettings_Click(object sender, EventArgs e)
    {
        _logger.LogDebug($"Cliced {nameof(buttonSettings)}");

        _settingsFormOpener?.Open();
    }

    private void timerClock_Tick(object sender, EventArgs e)
    {
        var time = _timeProvider.GetLocalNow().TimeOfDay;
        var roundedTime = new TimeSpan(time.Hours, time.Minutes, time.Seconds);

        labelClock.Text = roundedTime.ToString();
    }
}
