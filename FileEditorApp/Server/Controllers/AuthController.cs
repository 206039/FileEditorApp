using FileEditorApp.Shared.Commands;
using FileEditorApp.Shared.Commands.Auth;
using FileEditorApp.Shared.Events.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IMemoryCache _memoryCache;
        public AuthController(ICommandDispatcher commandDispatcher, IMemoryCache memoryCache)
        {
            _commandDispatcher = commandDispatcher;
            _memoryCache = memoryCache;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody]LoginCommand command)
        {
            command.CommandId = Guid.NewGuid();
            await _commandDispatcher.DispatchAsync(command);
            var @event = _memoryCache.Get<UserLoggedInEvent>(command.CommandId);
            return Ok(@event);
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
