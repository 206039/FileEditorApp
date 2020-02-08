using FileEditorApp.Shared.Commands;
using FileEditorApp.Shared.Commands.Auth;
using FileEditorApp.Shared.Events.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IMemoryCache _memoryCache;
        public AuthController(ICommandDispatcher commandDispatcher, IMemoryCache memoryCache) : base(commandDispatcher)
        {
            _memoryCache = memoryCache;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody]LoginCommand command)
        {
            command.CommandId = Guid.NewGuid();
            await CommandDispatcher.DispatchAsync(command);
            var @event = _memoryCache.Get<UserLoggedInEvent>(command.CommandId);
            return Ok(@event);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterCommand command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return StatusCode(201);
        }
    }
}
