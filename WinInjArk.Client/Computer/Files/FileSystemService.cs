namespace WinInjArk.Client.Computer.Files;

public record File(string Name);

public interface IFileSystemService
{
    public List<File> GetAllFiles();
    public string ReadAllText(File file);
}

internal class FileSystemService : IFileSystemService
{
    private readonly Dictionary<File, string> _files = new()
    {
        [new File("Något.txt")] = "Lite text.",
        [new File("markdown.md")] = "# HEJ!!!",
        [new File("gömt.zip")] = "dk43,m40fkslkdf",
    };

    public List<File> GetAllFiles() => [.. _files.Keys];

    public string ReadAllText(File file) => _files[file];
}
