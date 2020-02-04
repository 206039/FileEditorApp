using FileEditorApp.Shared.Domain;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetSingleAsync(string username);
        Task AddAsync(User user);
    }
}
