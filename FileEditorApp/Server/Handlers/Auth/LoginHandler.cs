using FileEditorApp.Server.Services;
using FileEditorApp.Shared.Commands;
using FileEditorApp.Shared.Commands.Auth;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Handlers.Auth
{
    public class LoginHandler : ICommandHandler<LoginCommand>
    {
        private readonly IUserService _userService;
        private readonly IMemoryCache _memoryCache;
        public LoginHandler(IUserService userService, IMemoryCache memoryCache)
        {
            _userService = userService;
            _memoryCache = memoryCache;
        }

        public async Task HandleAsync(LoginCommand command)
        {
            var @event = await _userService.LoginAsync(command.Username, command.Password);
            _memoryCache.Set(command.CommandId, @event);
        }
    }
}
