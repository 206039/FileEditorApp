using FileEditorApp.Shared.Events.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Services
{
    public class UserService : IUserService
    {
        public async Task<UserLoggedInEvent> LoginAsync(string username, string password)
        {
            await Task.CompletedTask;
            return new UserLoggedInEvent();
        }
    }
}
