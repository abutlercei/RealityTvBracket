using DotNet.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace DotNet.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserRepository _repository;
        public UserProfileService(IUserRepository repository)
        {
            _repository = repository;
        }

        public UserProfile? GetUserProfile(string id)
        {
            return _repository.GetUserProfile(id);
        }

        public bool FindUserProfile(LoginModel model)
        {
            if (model == null || model.Username == null || model.Password == null)
            {
                return false;
            }
            return _repository.FindUserProfile(model);
        }

        public bool UpdateUserProfile(UserProfile profile)
        {
            if (profile == null)
            {
                return false;
            }
            _repository.UpdateUserProfile(profile);
            return true;
        }
    }
}