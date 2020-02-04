using System;
using System.Collections.Generic;
using System.Text;

namespace FileEditorApp.Shared.Events.Auth
{
    public class UserLoggedInEvent : IEvent
    {
        public string Username { get; set; }
        public string JwtToken { get; set; }
    }
}
