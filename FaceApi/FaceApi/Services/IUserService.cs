using FaceApi.Models;

namespace FaceApi.Services
{
    public interface IUserService
    {
        public Task<User> CreateUserAsync(string name, List<int> schoolIds, string basePhotoUrl, string azurePersonId);
        public Task<List<User>> GetAllAsync();
        public Task<User> GetByIdAsync(int id);
    }
}
