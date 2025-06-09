using FaceApi.Data;
using FaceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FaceApi.Services
{
    public class UserService
    {
        private readonly ApiDbContext _db;
        public UserService(ApiDbContext db) => _db = db;

        public async Task<User> CreateUserAsync(string name, List<int> schoolIds, string basePhotoUrl, string azurePersonId)
        {
            var user = new User
            {
                Name = name,
                BasePhotoUrl = basePhotoUrl,
                AzurePersonId = azurePersonId,
                UserSchools = new List<UserSchool>()
            };

            foreach (var schoolId in schoolIds)
            {
                user.UserSchools.Add(new UserSchool { SchoolId = schoolId, User = user });
            }

            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _db.Users
                .Include(u => u.UserSchools).ThenInclude(us => us.School)
                .ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _db.Users
                .Include(u => u.UserSchools).ThenInclude(us => us.School)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
