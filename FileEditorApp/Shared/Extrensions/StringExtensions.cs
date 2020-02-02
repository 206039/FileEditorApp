namespace FileEditorApp.Shared.Extrensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string username)
        {
            return string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username);
        }
    }
}
