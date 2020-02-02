using FileEditorApp.Server.EF;
using FileEditorApp.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppContext _context;

        public UserRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<User> GetSingleAsync(string username)
            => await _context.Users.SingleOrDefaultAsync(x => x.Username.Equals(username));
    }
}
