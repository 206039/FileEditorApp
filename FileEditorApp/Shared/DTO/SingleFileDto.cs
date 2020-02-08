using FileEditorApp.Shared.Queries;

namespace FileEditorApp.Shared.DTO
{
    public class SingleFileDto : IQueryResult
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Filename { get; set; }
    }
}
