using FileEditorApp.Shared.Domain;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {

        }

        public async Task<User> GetSingleAsync(string username)
        {
            await Task.CompletedTask;
            return new User(username, "", "");
        }
    }
}
