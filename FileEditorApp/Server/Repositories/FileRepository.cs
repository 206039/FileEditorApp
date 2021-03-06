﻿using System.IO;

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

        public FileStream SaveFile(string uri)
        {
            FileStream fs = File.OpenRead(uri);
            return fs;
        }

        public void SendFile(string uri, MemoryStream ms)
        {
            using (var fileStream = new FileStream(uri, FileMode.Create))
            {
                ms.Position = 0;
                ms.CopyTo(fileStream);
            }
            
        }

        public void UpdateFile(string uri, string content)
        {
            File.WriteAllText(uri, content);
        }
    }
}
