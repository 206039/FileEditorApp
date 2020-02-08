using FileEditorApp.Shared.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Repositories
{
    public interface IDatabaseFileRepository : IRepository
    {
        Task AddAsync(DatabaseFile databaseFile);
        Task<IEnumerable<DatabaseFile>> GetAsync(int userId);
        Task<DatabaseFile> GetSingleAsync(int id);
        Task UpdateAsync(DatabaseFile databaseFile);
    }
}
