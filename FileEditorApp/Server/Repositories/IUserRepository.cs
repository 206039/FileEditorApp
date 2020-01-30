using FileEditorApp.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetSingleAsync(string username);
    }
}
