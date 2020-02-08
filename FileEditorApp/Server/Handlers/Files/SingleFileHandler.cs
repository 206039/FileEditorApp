using FileEditorApp.Server.Services;
using FileEditorApp.Shared.Queries;
using FileEditorApp.Shared.Queries.Files;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Handlers.Files
{
    public class SingleFileHandler : IQueryHandler<SingleFileQuery>
    {
        private readonly IFileService _fileService;
        public SingleFileHandler(IFileService fileService)
        {
            _fileService = fileService;
        }
        public async Task<IQueryResult> HandleAsync(SingleFileQuery query)
        {
            return await _fileService.GetSingleFileAsync(query.Id, query.UserId);
        }
    }
}
