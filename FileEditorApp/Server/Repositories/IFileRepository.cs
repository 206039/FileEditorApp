﻿namespace FileEditorApp.Server.Repositories
{
    public interface IFileRepository : IRepository
    {
        void CreateFile(string uri);
        string GetFileContent(string uri);
        void UpdateFile(string uri, string content);
    }
}
