using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileEditorApp.Shared.Commands.Files
{
    public class UploadFileCommand : ICommand
    {
        public int UserId { get; set; }
        public string Filename { get; set; }
        public MemoryStream MemoryStream { get; set; }
    }
}
