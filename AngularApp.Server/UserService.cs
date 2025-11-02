using AngularApp.Server.Models;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AngularApp.Server.Models;
using AngularApp.Server.Services;

namespace AngularApp.Server
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;

        public UserService(ILogger<UserService> logger, IUserRepository userRepository  )
        {
            _logger = logger;
            _userRepository = userRepository;

        }

        // Minimal, in-memory login stub. Replace with real user store & token generation.
        public async Task<bool> LoginAsync(UserViewModel model)
        {
            _logger.LogInformation("User logging in: {Email}", model.Username);
            return await _userRepository.GetUser(model);
        }

        // Very simple token check for demo purposes
        //public Task<bool> ValidateTokenAsync(string token)
        //{
        //    var valid = !string.IsNullOrEmpty(token); // placeholder
        //    return Task.FromResult(valid);
        //}
    }
}