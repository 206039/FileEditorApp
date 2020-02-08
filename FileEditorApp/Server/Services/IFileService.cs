using System.Threading.Tasks;

namespace FileEditorApp.Server.Services
{
    public interface IFileService : IService
    {
        Task CreateFileAsync(int userId, string fileName);
    }
}
