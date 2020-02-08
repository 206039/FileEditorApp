using FileEditorApp.Server.Services;
using FileEditorApp.Shared.Commands;
using FileEditorApp.Shared.Commands.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Handlers.Files
{
    public class DeleteHandler : ICommandHandler<DeleteCommand>
    {
        private readonly IFileService _fileService;
        public DeleteHandler(IFileService fileService)
        {
            _fileService = fileService;
        }
        public async Task HandleAsync(DeleteCommand command)
        {
            await _fileService.DeleteAsync(command.Id, command.UserId);
        }
    }
}
