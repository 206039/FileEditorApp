using FileEditorApp.Shared.Commands;
using FileEditorApp.Shared.Commands.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Handlers.Auth
{
    public class LoginHandler : ICommandHandler<LoginCommand>
    {
        public async Task HandleAsync(LoginCommand command)
        {
            await Task.CompletedTask;
        }
    }
}
