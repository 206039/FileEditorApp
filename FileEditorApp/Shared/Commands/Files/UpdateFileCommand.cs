namespace FileEditorApp.Shared.Commands.Files
{
    public class UpdateFileCommand : ICommand
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public string Content { get; set; }
    }
}
