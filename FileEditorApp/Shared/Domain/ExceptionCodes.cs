namespace FileEditorApp.Shared.Domain
{
    public static class ExceptionCodes
    {
        public static string UsernameHasNotBeenGiven => "Nie podano nazwy użytkownika.";
        public static string InvalidUsername => "Nazwa użytkownika może zawierać od 4 do 30 znaków litery, cyfry oraz znaki '_' i '-'.";
        public static string UserAlreadyExists => "Użytkownik o tej nazwie użytkownika już istnieje";
        public static string PasswordHasNotBeenGiven => "Hasło nie zostało podane.";
        public static string PasswordsAreNotEqual => "Hasła się nie zgadzają";
        public static string UserWithGivenIdDoesNotExists => "Użytkownik o takim identyfikatorze nie istnieje.";
        public static string FileNameHasNotBeenGiven => "Nie podano nazwy pliku.";
        public static string FileDoesNotExists => "Plik nie istnieje";
    }
}
