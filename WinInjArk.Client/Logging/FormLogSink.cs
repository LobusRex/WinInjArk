namespace WinInjArk.Client.Logging;

internal class FormLogSink : IFormLogSink
{
	private readonly List<Log> _logs = [new("Logs:")];

	public List<Log> GetAllLogs()
	{
		return [.. _logs];
	}

	public void Push(Log log)
	{
		_logs.Add(log);
		LogReceived?.Invoke(this, new EventArgs());
	}

	public event EventHandler? LogReceived;
}
