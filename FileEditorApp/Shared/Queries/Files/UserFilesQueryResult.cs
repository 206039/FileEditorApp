using FileEditorApp.Shared.DTO;
using System.Collections.Generic;

namespace FileEditorApp.Shared.Queries.Files
{
    public class UserFilesQueryResult : IQueryResult
    {
        public IEnumerable<FileDto> Files { get; set; }
    }
}
