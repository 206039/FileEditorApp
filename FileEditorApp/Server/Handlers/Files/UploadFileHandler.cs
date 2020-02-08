using FileEditorApp.Server.Services;
using FileEditorApp.Shared.Commands;
using FileEditorApp.Shared.Commands.Files;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Handlers.Files
{
    public class UploadFileHandler : ICommandHandler<UploadFileCommand>
    {
        private readonly IFileService _fileService;
        public UploadFileHandler(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task HandleAsync(UploadFileCommand command)
        {
            await _fileService.UploadFileAsync(command.UserId, command.Filename, command.MemoryStream);
        }
    }
}
