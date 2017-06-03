namespace Rbauto.Services
{
    public interface IFileSystem
    {
        void WriteTextAsync(string fileName, string text);
        string ReadTextAsync(string fileName);
    }
}
