using FileEditorApp.Shared.Commands.Auth;
using FileEditorApp.Shared.Events.Auth;
using System.Net.Http;
using System.Threading.Tasks;

namespace FileEditorApp.Client.Services
{
    public class FileEditorAppContext
    {
        public UserLoggedInEvent LoggedUser { get; private set; }
        private readonly HttpClient _httpClient;
        public FileEditorAppContext(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task LoginAsync(LoginCommand loginCommand)
        {
            await Task.CompletedTask;
        }
    }
}
