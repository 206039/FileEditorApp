using FileEditorApp.Server.Repositories;
using FileEditorApp.Shared.Domain;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Services
{
    public class FileService : IFileService
    {
        private readonly IDatabaseFileRepository _dbFileRepository;
        private readonly IFileRepository _fileRepository;

        public FileService(IDatabaseFileRepository dbFileRepository, IFileRepository fileRepository)
        {
            _dbFileRepository = dbFileRepository;
            _fileRepository = fileRepository;
        }
        public async Task CreateFileAsync(int userId, string fileName)
        {
            var uriFileName = Guid.NewGuid().ToString();
            var uri = Path.Combine("Files", uriFileName);
            var dbFile = new DatabaseFile(userId, fileName, uri);
            await _dbFileRepository.AddAsync(dbFile);
            _fileRepository.CreateFile(dbFile.Uri);
        }
    }
}
