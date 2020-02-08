using AutoMapper;
using FileEditorApp.Server.Repositories;
using FileEditorApp.Shared.Domain;
using FileEditorApp.Shared.DTO;
using FileEditorApp.Shared.Queries.Files;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Services
{
    public class FileService : IFileService
    {
        private readonly IDatabaseFileRepository _dbFileRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;

        public FileService(IDatabaseFileRepository dbFileRepository, IFileRepository fileRepository, IMapper mapper)
        {
            _dbFileRepository = dbFileRepository;
            _fileRepository = fileRepository;
            _mapper = mapper;
        }
        public async Task CreateFileAsync(int userId, string fileName)
        {
            var uriFileName = Guid.NewGuid().ToString();
            var uri = Path.Combine("Files", uriFileName);
            var dbFile = new DatabaseFile(userId, fileName, uri);
            await _dbFileRepository.AddAsync(dbFile);
            _fileRepository.CreateFile(dbFile.Uri);
        }

        public async Task DeleteAsync(int id, int userId)
        {
            var dbFile = await _dbFileRepository.GetSingleAsync(id);
            if (dbFile == null)
            {
                throw new ServiceException(ExceptionCodes.FileDoesNotExists);
            }
            if (dbFile.UserId != userId)
                throw new UnauthorizedAccessException();
            _fileRepository.Delete(dbFile.Uri);
            await _dbFileRepository.DeleteAsync(dbFile);
        }

        public async Task<IEnumerable<FileDto>> GetAsync(int userId)
            => _mapper.Map<IEnumerable<FileDto>>(await _dbFileRepository.GetAsync(userId));

        public async Task<SingleFileDto> GetSingleFileAsync(int id, int userId)
        {
            var dbFile = await _dbFileRepository.GetSingleAsync(id);
            if(dbFile==null)
            {
                throw new ServiceException(ExceptionCodes.FileDoesNotExists);
            }
            if (dbFile.UserId != userId)
                throw new UnauthorizedAccessException();
            var fileContent = _fileRepository.GetFileContent(dbFile.Uri);
            return new SingleFileDto { Content = fileContent, Id = id, Filename=dbFile.Name };
        }

        public async Task<DownloadFileQueryResult> SaveFileAsync(int id, string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var theToken = handler.ReadJwtToken(token);
            var userId = int.Parse(theToken.Claims.ElementAt(0).Value);
            var dbFile = await _dbFileRepository.GetSingleAsync(id);
            if (dbFile == null)
            {
                throw new ServiceException(ExceptionCodes.FileDoesNotExists);
            }
            if (dbFile.UserId != userId)
                throw new UnauthorizedAccessException();
            var fs = _fileRepository.SaveFile(dbFile.Uri);
            return new DownloadFileQueryResult { FileStream = fs, Filename = dbFile.Name };
        }

        public async Task UpdateFileAsync(int id, string name, string content, int userId)
        {
            var dbFile = await _dbFileRepository.GetSingleAsync(id);
            if (dbFile == null)
            {
                throw new ServiceException(ExceptionCodes.FileDoesNotExists);
            }
            if (dbFile.UserId != userId)
                throw new UnauthorizedAccessException();
            dbFile.Name = name;
            _fileRepository.UpdateFile(dbFile.Uri, content);
            await _dbFileRepository.UpdateAsync(dbFile);
        }

        public async Task UploadFileAsync(int userId, string fileName, MemoryStream memoryStream)
        {
            var uriFileName = Guid.NewGuid().ToString();
            var uri = Path.Combine("Files", uriFileName);
            var dbFile = new DatabaseFile(userId, fileName, uri);
            await _dbFileRepository.AddAsync(dbFile);
            _fileRepository.SendFile(dbFile.Uri, memoryStream);
        }
    }
}
