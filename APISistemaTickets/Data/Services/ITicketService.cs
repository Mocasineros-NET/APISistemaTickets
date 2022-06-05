using APISistemaTickets.Data.Models.App;
using APISistemaTickets.Data.Models.Auth;

namespace APISistemaTickets.Data.Services;

public interface ITicketService
{
    IEnumerable<Ticket> GetAll(); 
    Ticket GetById(long id);
    IEnumerable<Ticket> GetByUserId(long id);
    Ticket Create(Ticket ticket);
    Ticket Update(Ticket ticket);
    Ticket Delete(long id);
    Ticket Close(long id);
    Ticket Open(long id);
    Ticket AssignEngineer(long id, User user);
    Ticket UnassignEngineer(long id);
    Ticket AssignTag(long id, Tag tag);
    Ticket UnassignTag(long id, Tag tag);
}