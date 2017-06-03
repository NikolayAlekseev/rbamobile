using System;
using Rbauto.iOS.Services;
using Rbauto.Services;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(FileSystem))]
namespace Rbauto.iOS.Services
{
    public class FileSystem : IFileSystem
    {
        public async void WriteTextAsync(string fileName, string text)
        {
            var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(docsPath, fileName);
            using (var writer = File.CreateText(path))
            {
                await writer.WriteAsync(text);
            }
        }

        public string ReadTextAsync(string fileName)
        {
            var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(docsPath, fileName);
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            return null;
        }
    }
}