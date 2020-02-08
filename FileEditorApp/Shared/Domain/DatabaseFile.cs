using FileEditorApp.Shared.Extrensions;
using System;

namespace FileEditorApp.Shared.Domain
{
    public class DatabaseFile
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public virtual User User { get; set; }
        public string Name { get; set; }
        public string Uri { get; private set; }
        protected DatabaseFile()
        {
        }

        public DatabaseFile(int userId, string name, string uri)
        {
            SetUserId(userId);
            SetName(name);
            Uri = uri;
        }

        private void SetUserId(int userId)
        {
            if (userId == 0)
                throw new DomainException(ExceptionCodes.UserWithGivenIdDoesNotExists);
            UserId = userId;
        }

        public void SetName(string name)
        {
            if (name.IsNullOrEmpty())
                throw new DomainException(ExceptionCodes.FileNameHasNotBeenGiven);
            Name = name;
        }
    }
}
