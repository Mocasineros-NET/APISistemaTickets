using APISistemaTickets.Modules.UserAdministration.Application;
using APISistemaTickets.Modules.UserAdministration.Application.DTO;
using APISistemaTickets.Modules.UserAdministration.Domain.Entities;
using AutoMapper;

namespace APISistemaTickets.Modules.UserAdministration.Domain.Abstractions;

public class UserAdapter : Profile
{
    public UserAdapter()
    {
        // User -> AuthenticateResponse
        CreateMap<User, AuthenticateResponse>();

        // RegisterRequest -> User
        CreateMap<RegisterRequest, User>()
            .ForMember(m => m.Role, o => o.MapFrom(_ => Role.User));

        // UpdateRequest -> User
        CreateMap<UpdateRequest, User>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));
    }
}