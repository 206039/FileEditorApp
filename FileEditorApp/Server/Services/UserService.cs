using FileEditorApp.Server.Repositories;
using FileEditorApp.Shared.Events.Auth;
using System;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IJwtHandler _jwtHandler;

        public UserService(IUserRepository userRepository, IEncryptionService encryptionService, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _encryptionService = encryptionService;
            _jwtHandler = jwtHandler;
        }

        public async Task<UserLoggedInEvent> LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetSingleAsync(username);
            if (user == null)
                throw new UnauthorizedAccessException();
            var hash = _encryptionService.GetHash(password, user.Salt);
            if (user.Hash != hash)
                throw new UnauthorizedAccessException();
            return _jwtHandler.CreateToken(user);
        }
    }
}
