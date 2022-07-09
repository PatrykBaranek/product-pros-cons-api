using AutoMapper;
using IsThatGoodDecision.Entities;
using IsThatGoodDecision.Services.UserService;

namespace IsThatGoodDecision.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, UserEntity>();
        }
    }
}
