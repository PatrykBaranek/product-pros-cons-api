namespace IsThatGoodDecision.Services.UserService
{
    public interface IUserService
    {
        Task<UserResultDto> Create(UserDto userDto);
        Task<UserResultDto> Update(Guid id, UserDto userDto);
        Task<UserResultDto> Delete(Guid id);
    }
}
