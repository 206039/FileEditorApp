using FileEditorApp.Server.Services;
using FileEditorApp.Shared.Commands;
using FileEditorApp.Shared.Commands.Files;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Handlers.Files
{
    public class CreateFileHandler : ICommandHandler<CreateFileCommand>
    {
        private readonly IFileService _fileService;
        public CreateFileHandler(IFileService fileService)
            => _fileService = fileService;

        public async Task HandleAsync(CreateFileCommand command)
            => await _fileService.CreateFileAsync(command.UserId, command.Filename);
    }
}
