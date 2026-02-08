using Microsoft.Extensions.Logging;

namespace WinInjArk.Client.Logging;

internal class FormLoggerProvider : ILoggerProvider
{
	private readonly IFormLogSink _logProvider;

	public FormLoggerProvider(IFormLogSink logProvider)
	{
		_logProvider = logProvider;
	}

	public ILogger CreateLogger(string categoryName)
	{
		return new FormLogger(_logProvider);
	}

	public void Dispose()
	{
		
	}
}

internal class FormLogger : ILogger
{
	private readonly IFormLogSink _sink;

	public FormLogger(IFormLogSink formLogSink)
	{
		_sink = formLogSink;
	}

	private class Scope : IDisposable
	{
		public void Dispose()
		{
			
		}
	}

	public IDisposable? BeginScope<TState>(TState state) where TState : notnull
	{
		return new Scope();
	}

	public bool IsEnabled(LogLevel logLevel)
	{
		return true;
	}

	public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
	{
		if (!IsEnabled(logLevel))
			return;

		ArgumentNullException.ThrowIfNull(formatter);

		var formatted = formatter(state, exception);

		_sink.Push(new Log(formatted));
	}
}