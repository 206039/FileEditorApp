using FileEditorApp.Server.Repositories;
using FileEditorApp.Shared.Domain;
using FileEditorApp.Shared.Events.Auth;
using FileEditorApp.Shared.Extrensions;
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
            if(username.IsNullOrEmpty() || password.IsNullOrEmpty())
                throw new UnauthorizedAccessException();
            var user = await _userRepository.GetSingleAsync(username);
            if (user == null)
                throw new UnauthorizedAccessException();
            var hash = _encryptionService.GetHash(password, user.Salt);
            if (user.Hash != hash)
                throw new UnauthorizedAccessException();
            return _jwtHandler.CreateToken(user);
        }

        public async Task RegisterAsync(string username, string password)
        {
            if (password.IsNullOrEmpty())
            {
                throw new ServiceException(ExceptionCodes.PasswordHasNotBeenGiven);
            }
            var user = await _userRepository.GetSingleAsync(username);
            if(user!=null)
            {
                throw new ServiceException(ExceptionCodes.UserAlreadyExists);
            }

            var salt = _encryptionService.GetSalt();
            var hash = _encryptionService.GetHash(password, salt);

            var newUser = new User(username, hash, salt);
            await _userRepository.AddAsync(newUser);
        }
    }
}
