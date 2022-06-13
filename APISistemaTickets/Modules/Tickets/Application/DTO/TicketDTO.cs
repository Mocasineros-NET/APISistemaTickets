using APISistemaTickets.Modules.Tickets.Domain.Entities;

namespace APISistemaTickets.Modules.Tickets.Application.DTO;

public class TicketDTO
{   
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public Priority Priority { get; set; }
}