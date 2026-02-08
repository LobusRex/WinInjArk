namespace WinInjArk.Client.Logging;

internal static class RichTextBoxExtensions
{
	/// <summary>
	/// Replace all the text in the <see cref="RichTextBox"/> with the provided logs.
	/// </summary>
	/// <param name="richTextBox">The GUI element to write logs to.</param>
	/// <param name="logs">The logs to write to the GUI element.</param>
	public static void WriteLogs(
		this RichTextBox richTextBox,
		IEnumerable<Log> logs)
	{
		richTextBox.Text = "";
		foreach (var log in logs)
		{
			richTextBox.AppendText(log.Text);
			richTextBox.AppendText(Environment.NewLine);
		}
	}
}
