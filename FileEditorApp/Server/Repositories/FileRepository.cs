using System.IO;

namespace FileEditorApp.Server.Repositories
{
    public class FileRepository : IFileRepository
    {
        public void CreateFile(string uri)
        {
            File.Create(uri).Dispose();
        }

        public void Delete(string uri)
        {
            File.Delete(uri);
        }

        public string GetFileContent(string uri)
        {
            return File.ReadAllText(uri);
        }

        public void UpdateFile(string uri, string content)
        {
            File.WriteAllText(uri, content);
        }
    }
}
