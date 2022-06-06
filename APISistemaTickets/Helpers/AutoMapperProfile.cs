using APISistemaTickets.Data.Models.App;
using APISistemaTickets.Data.Models.Auth;
using APISistemaTickets.Data.Models.DTO.App;
using AutoMapper;

namespace APISistemaTickets.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
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

        CreateMap<TagDTO, Tag>();

        CreateMap<TicketDTO, Ticket>()
            .ForMember(t => t.CreatedAt, o => o.MapFrom(_ => DateTime.Now));

        CreateMap<KnowledgeBaseArticleDTO, KnowledgeBaseArticle>();
        CreateMap<CommentDTO, Comment>();
    }
}