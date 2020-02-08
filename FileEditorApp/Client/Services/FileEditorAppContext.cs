using FileEditorApp.Shared.Events.Auth;

namespace FileEditorApp.Client.Services
{
    public class FileEditorAppContext
    {
        public UserLoggedInEvent LoggedUser { get; set; }
    }
}
