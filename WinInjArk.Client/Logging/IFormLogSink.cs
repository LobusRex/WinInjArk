namespace WinInjArk.Client.Logging;

internal interface IFormLogSink
{
	public List<Log> GetAllLogs();
	public void Push(Log log);
	public event EventHandler? LogReceived;
}
