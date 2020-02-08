using System.Threading.Tasks;

namespace FileEditorApp.Shared.Queries
{
    public interface IQueryHandler<T> where T : IQuery
    {
        Task<IQueryResult> HandleAsync(T query);
    }
}
