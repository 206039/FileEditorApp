using FileEditorApp.Server.Services;
using FileEditorApp.Shared.Commands;
using FileEditorApp.Shared.Commands.Files;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Handlers.Files
{
    public class UpdateFileHandler : ICommandHandler<UpdateFileCommand>
    {
        private readonly IFileService _fileService;
        public UpdateFileHandler(IFileService fileService)
        {
            _fileService = fileService;
        }
        public async Task HandleAsync(UpdateFileCommand command)
        {
            await _fileService.UpdateFileAsync(command.Id, command.Filename, command.Content);
        }
    }
}
