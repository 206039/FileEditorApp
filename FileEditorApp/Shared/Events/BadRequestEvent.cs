namespace FileEditorApp.Shared.Events
{
    public class BadRequestEvent : IEvent
    {
        public string Code { get; set; }
    }
}
