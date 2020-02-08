using FileEditorApp.Server.Services;
using FileEditorApp.Shared.Queries;
using FileEditorApp.Shared.Queries.Files;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Handlers.Files
{
    public class UserFilesHandler : IQueryHandler<UserFilesQuery>
    {
        private readonly IFileService _fileService;
        public UserFilesHandler(IFileService fileService)
        {
            _fileService = fileService;
        }
        public async Task<IQueryResult> HandleAsync(UserFilesQuery query)
        {
            var result = await _fileService.GetAsync(query.UserId);
            return new UserFilesQueryResult { Files = result };
        }
    }
}
