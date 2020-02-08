using Autofac;
using System;
using System.Threading.Tasks;

namespace FileEditorApp.Shared.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {

        private readonly IComponentContext _context;

        public QueryDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task<IQueryResult> DispatchAsync<T>(T query) where T : IQuery
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query), $"Command: '{typeof(T).Name}' can not be null.");
            }
            var handler = _context.Resolve<IQueryHandler<T>>();
            return await handler.HandleAsync(query);
        }
    }
}
