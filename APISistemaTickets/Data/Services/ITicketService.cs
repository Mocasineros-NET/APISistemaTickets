using APISistemaTickets.Data.Models.App;
using APISistemaTickets.Data.Models.Auth;

namespace APISistemaTickets.Data.Services;

public interface ITicketService
{
    Task<IEnumerable<Ticket>?> GetAll(); 
    Task<Ticket?> GetById(long id);
    Task<IEnumerable<Ticket>?> GetByUserId(long id);
    Task<IEnumerable<Ticket>?> GetByEngineerId(long id);
    Task<Ticket> Create(Ticket ticket);
    Task<Ticket> Update(Ticket ticket);
    Task Delete(long id);
    Task<Ticket> Close(long id);
    Task<Ticket> Open(long id);
    Task<Ticket> AssignEngineer(long id, long engineerId);
    Task<Ticket> UnassignEngineer(long id);
    Task<Ticket> AssignTag(long id, long tagId);
    Task<Ticket> UnassignTag(long id, long tagId);
}