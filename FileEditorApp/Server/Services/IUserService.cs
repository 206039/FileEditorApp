using FileEditorApp.Shared.Events.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Services
{
    public interface IUserService : IService
    {
        Task<UserLoggedInEvent> LoginAsync(string username, string password);
    }
}
