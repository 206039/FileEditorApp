using FileEditorApp.Shared.Commands;
using FileEditorApp.Shared.Commands.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        public AuthController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody]LoginCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [Route("test")]
        [HttpGet]
        public async Task<IActionResult> TestAsync()
        {
            await _commandDispatcher.DispatchAsync(new LoginCommand());
            return Ok();
        }
    }
}
