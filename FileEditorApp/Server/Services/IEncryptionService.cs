namespace FileEditorApp.Server.Services
{
    public interface IEncryptionService : IService
    {
        string GetSalt();
        string GetHash(string value, string salt);
    }
}
