using System.Threading.Tasks;

namespace FileEditorApp.Shared.Queries
{
    public interface IQueryDispatcher
    {
        Task<IQueryResult> DispatchAsync<T>(T query) where T : IQuery;
    }
}
