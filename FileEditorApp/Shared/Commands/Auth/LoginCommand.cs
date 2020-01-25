using System;
using System.Collections.Generic;
using System.Text;

namespace FileEditorApp.Shared.Commands.Auth
{
    public class LoginCommand : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
