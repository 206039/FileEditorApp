using FileEditorApp.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Services
{
    public interface IFileService : IService
    {
        Task CreateFileAsync(int userId, string fileName);
        Task<IEnumerable<FileDto>> GetAsync(int userId);
        Task<SingleFileDto> GetSingleFileAsync(int id);
    }
}
