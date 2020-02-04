using FileEditorApp.Shared.Extrensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FileEditorApp.Shared.Domain
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Hash { get; private set; }
        public string Salt { get; private set; }
        public virtual ICollection<DatabaseFile> DatabaseFiles { get; private set; }
        public User(string username, string hash, string salt)
        {
            SetUsername(username);
            SetPassword(hash, salt);
        }

        public void SetUsername(string username)
        {
            if(username.IsNullOrEmpty())
            {
                throw new DomainException(ExceptionCodes.UsernameHasNotBeenGiven);
            }

            if (!Regex.IsMatch(username, @"^[a-z0-9_-]{4,30}$"))
            {
                throw new DomainException(ExceptionCodes.InvalidUsername);
            }
            Username = username;
        }

        public void SetPassword(string hash, string salt)
        {
            if(hash.IsNullOrEmpty() || salt.IsNullOrEmpty())
            {
                throw new ArgumentNullException();
            }
            Hash = hash;
            Salt = salt;
        }

        protected User()
        {
        }
    }
}
