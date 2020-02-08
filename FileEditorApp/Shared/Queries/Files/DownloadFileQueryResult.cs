using System.IO;

namespace FileEditorApp.Shared.Queries.Files
{
    public class DownloadFileQueryResult : IQueryResult
    {
        public FileStream FileStream { get; set; }
        public string Filename { get; set; }
    }
}
