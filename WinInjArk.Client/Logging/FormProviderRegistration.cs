using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace WinInjArk.Client.Logging;

internal static class FormProviderRegistration
{
	public static ILoggingBuilder AddFormLogging(
		this ILoggingBuilder builder)
	{
		builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, FormLoggerProvider>());

		return builder;
	}
}
