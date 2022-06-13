using APISistemaTickets.Modules.Comments.Application.DTO;
using APISistemaTickets.Modules.Comments.Domain.Entities;
using AutoMapper;

namespace APISistemaTickets.Modules.Comments.Domain.Abstractions;

public class CommentAdapter : Profile
{
    public CommentAdapter()
    {
        CreateMap<CommentDTO, Comment>();
    }
}