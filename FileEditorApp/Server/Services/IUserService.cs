using FileEditorApp.Shared.Events.Auth;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Services
{
    public interface IUserService : IService
    {
        Task<UserLoggedInEvent> LoginAsync(string username, string password);
        Task RegisterAsync(string username, string password);
    }
}
