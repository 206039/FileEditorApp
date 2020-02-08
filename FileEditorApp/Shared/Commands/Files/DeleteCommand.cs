namespace FileEditorApp.Shared.Commands.Files
{
    public class DeleteCommand : ICommand
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
