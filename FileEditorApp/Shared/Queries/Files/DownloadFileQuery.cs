namespace FileEditorApp.Shared.Queries.Files
{
    public class DownloadFileQuery : IQuery
    {
        public int Id { get; set; }
        public string Token { get; set; }
    }
}
