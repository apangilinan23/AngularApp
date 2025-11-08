using AngularApp.Server.Data;
using AngularApp.Server.Models;
using AngularApp.Server.Services;

namespace AngularApp.Server
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(ILogger<UserService> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;

        }

        // Minimal, in-memory login stub. Replace with real user store & token generation.
        public async Task<UserViewModel> LoginAsync(UserViewModel model)
        {
            _logger.LogInformation("User logging in: {Email}", model.Username);
            return await _unitOfWork.User.GetAsync(model);
        }

        // Very simple token check for demo purposes
        //public Task<bool> ValidateTokenAsync(string token)
        //{
        //    var valid = !string.IsNullOrEmpty(token); // placeholder
        //    return Task.FromResult(valid);
        //}
    }
}