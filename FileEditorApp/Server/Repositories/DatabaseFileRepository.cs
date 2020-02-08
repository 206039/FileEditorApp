using FileEditorApp.Server.EF;
using FileEditorApp.Shared.Domain;
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
    }
}
