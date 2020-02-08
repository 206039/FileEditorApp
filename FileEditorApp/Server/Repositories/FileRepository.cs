using System.IO;

namespace FileEditorApp.Server.Repositories
{
    public class FileRepository : IFileRepository
    {
        public void CreateFile(string uri)
        {
            File.Create(uri).Dispose();
        }
    }
}
