using FileEditorApp.Server.EF;
using FileEditorApp.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Repositories
{
    public class DatabaseFileRepository : IDatabaseFileRepository
    {
        private readonly AppContext _dbContext;
        public DatabaseFileRepository(AppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(DatabaseFile databaseFile)
        {
            _dbContext.DatabaseFiles.Add(databaseFile);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(DatabaseFile databaseFile)
        {
            _dbContext.DatabaseFiles.Remove(databaseFile);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<DatabaseFile>> GetAsync(int userId)
            => await _dbContext.DatabaseFiles.Where(x => x.UserId == userId).ToListAsync();
        
        public async Task<DatabaseFile> GetSingleAsync(int id)
        {
            return await _dbContext.DatabaseFiles.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(DatabaseFile databaseFile)
        {
            _dbContext.DatabaseFiles.Update(databaseFile);
            await _dbContext.SaveChangesAsync();
        }
    }
}
