using IsThatGoodDecision.Entities;

namespace IsThatGoodDecision.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserResultDto> Create(UserDto userDto)
        {
            var newUser = new UserEntity()
            {
                Id = Guid.NewGuid(),
                Name = userDto.Name,
                WishListId = Guid.NewGuid()
            };

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            return new UserResultDto { Name = userDto.Name, Result = "User Created" };
        }

        public async Task<UserResultDto> Update(Guid id, UserDto userDto)
        {
            var userToUpdate = await _dbContext.Users.FindAsync(id);

            if (userToUpdate == null)
            {
                return new UserResultDto { Name = null, Result = "Cannot Find User" };
            }

            userToUpdate.Name = userDto.Name;

            _dbContext.Users.Update(userToUpdate);
            await _dbContext.SaveChangesAsync();

            return new UserResultDto { Name = userToUpdate.Name, Result = "User Updated" };

        }

        public async Task<UserResultDto> Delete(Guid id)
        {
            var userToDelete = await _dbContext.Users.FindAsync(id);

            if (userToDelete == null)
            {
                return new UserResultDto { Name = null, Result = "Cannot Find User" };
            }

            _dbContext.Users.Remove(userToDelete);
            await _dbContext.SaveChangesAsync();

            return new UserResultDto { Name = userToDelete.Name, Result = "User Deleted" };
        }
    }
}
