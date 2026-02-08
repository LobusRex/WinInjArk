using Microsoft.Extensions.Logging;
using WinInjArk.Client.Logging;

namespace WinInjArk.Client;

internal partial class MainForm : Form
{
	private readonly IFormLogSink _logProvider;
	private readonly ILogger<MainForm> _logger;

	public MainForm(
		IFormLogSink logProvider,
		ILogger<MainForm> logger)
	{
		InitializeComponent();

		_logProvider = logProvider;
		_logger = logger;

		_logger.LogInformation("MainForm constructor.");
	}

	private void mainForm_Load(object? sender, EventArgs e)
	{
		var logs = _logProvider.GetAllLogs();
		richTextBoxLogs.WriteLogs(logs);

		_logProvider.LogReceived += logProvider_LogReceived;

		_logger.LogInformation("MainForm load.");
	}

	private void logProvider_LogReceived(object? sender, EventArgs e)
	{
		var logs = _logProvider.GetAllLogs();
		richTextBoxLogs.WriteLogs(logs);
	}

	/// <summary>
	///  Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_logProvider.LogReceived -= logProvider_LogReceived;
		}

		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}
}
