using FileEditorApp.Shared.Domain;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Repositories
{
    public interface IDatabaseFileRepository : IRepository
    {
        Task AddAsync(DatabaseFile databaseFile);
    }
}
