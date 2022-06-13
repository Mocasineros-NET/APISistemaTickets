using APISistemaTickets.Modules.Tickets.Application.DTO;
using APISistemaTickets.Modules.Tickets.Domain.Entities;
using AutoMapper;

namespace APISistemaTickets.Modules.Tickets.Domain.Abstractions;

public class TicketAdapter : Profile
{
    public TicketAdapter()
    {
        CreateMap<TicketDTO, Ticket>()
            .ForMember(t => t.CreatedAt, o => o.MapFrom(_ => DateTime.Now))
            .ForMember(t => t.Priority, o => o.MapFrom(t => Priority.Low));
    }
}