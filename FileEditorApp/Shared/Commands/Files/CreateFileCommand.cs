namespace FileEditorApp.Shared.Commands.Files
{
    public class CreateFileCommand : ICommand
    {
        public int UserId { get; set; }
        public string Filename { get; private set; }
    }
}
