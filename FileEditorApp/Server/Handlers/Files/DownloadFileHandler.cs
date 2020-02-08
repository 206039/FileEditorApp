using FileEditorApp.Server.Services;
using FileEditorApp.Shared.Queries;
using FileEditorApp.Shared.Queries.Files;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Handlers.Files
{
    public class DownloadFileHandler : IQueryHandler<DownloadFileQuery>
    {
        private readonly IFileService _fileService;
        public DownloadFileHandler(IFileService fileService)
        {
            _fileService = fileService;
        }
        public async Task<IQueryResult> HandleAsync(DownloadFileQuery query)
        {
            return await _fileService.SaveFileAsync(query.Id, query.Token);
        }
    }
}
