using APISistemaTickets.Modules.Tags.Application.DTO;
using APISistemaTickets.Modules.Tags.Domain.Entities;
using AutoMapper;

namespace APISistemaTickets.Modules.Tags.Domain.Abstractions;

public class TagAdapter : Profile
{
    public TagAdapter()
    {
        CreateMap<TagDTO, Tag>();
    }
}