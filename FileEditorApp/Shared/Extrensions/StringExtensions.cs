using System;
using System.Collections.Generic;
using System.Text;

namespace FileEditorApp.Shared.Extrensions
{
    static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string username)
        {
            return string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username);
        }
    }
}
