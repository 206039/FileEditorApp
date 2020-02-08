using FileEditorApp.Shared.Commands;
using FileEditorApp.Shared.Commands.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Controllers
{
    public class FilesController : BaseController
    {
        public FilesController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateFileAsync([FromBody]CreateFileCommand command)
        {
            var userId = int.Parse(User.Claims.ElementAt(0).Value);
            command.UserId = userId;
            await CommandDispatcher.DispatchAsync(command);
            return StatusCode(201);
        }
    }
}
