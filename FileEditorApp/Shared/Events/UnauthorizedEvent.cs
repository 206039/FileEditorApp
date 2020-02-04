namespace FileEditorApp.Shared.Events
{
    public class UnauthorizedEvent : IEvent
    {
        public string Message => "Brak dostępu do danych.";
    }
}
