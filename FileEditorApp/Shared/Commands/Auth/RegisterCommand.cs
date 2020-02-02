namespace FileEditorApp.Shared.Commands.Auth
{
    public class RegisterCommand : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
