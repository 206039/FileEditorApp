using FileEditorApp.Shared.DTO;
using FileEditorApp.Shared.Queries.Files;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Services
{
    public interface IFileService : IService
    {
        Task CreateFileAsync(int userId, string fileName);
        Task<IEnumerable<FileDto>> GetAsync(int userId);
        Task<SingleFileDto> GetSingleFileAsync(int id, int userId);
        Task UpdateFileAsync(int id, string name, string content, int userId);
        Task DeleteAsync(int id, int userId);
        Task<DownloadFileQueryResult> SaveFileAsync(int id, string token);
        Task UploadFileAsync(int userId, string fileName, MemoryStream memoryStream);
    }
}
