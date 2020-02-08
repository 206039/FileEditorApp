using FileEditorApp.Shared.Domain;
using FileEditorApp.Shared.Events.Auth;

namespace FileEditorApp.Server.Services
{
    public interface IJwtHandler : IService
    {
        UserLoggedInEvent CreateToken(User user);
    }
}
