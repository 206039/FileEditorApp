namespace FileEditorApp.Shared.Domain
{
    public static class ExceptionCodes
    {
        public static string UsernameHasNotBeenGiven => "Nie podano nazwy użytkownika.";
        public static string InvalidUsername => "Nazwa użytkownika może zawierać od 4 do 30 znaków litery, cyfry oraz znaki '_' i '-'.";
    }
}
