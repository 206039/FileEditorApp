namespace FileEditorApp.Shared.Commands.Files
{
    public class CreateFileCommand
    {
        public int UserId { get; set; }
        public string Filename { get; private set; }
    }
}
