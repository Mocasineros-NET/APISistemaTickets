using APISistemaTickets.Data.Models.App;
using APISistemaTickets.Data.Models.Auth;
using APISistemaTickets.Helpers;
using Microsoft.EntityFrameworkCore;

namespace APISistemaTickets.Data.Services;

class TicketService : ITicketService
{
    private DataContext _context;

    public TicketService(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Ticket> GetAll()
    {
        return _context.Tickets;
    }

    public Ticket GetById(long id)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        return ticket;
    }

    public IEnumerable<Ticket> GetByUserId(long id)
    {
        var tickets = _context.Tickets.Where(t => t.UserId == id);
        if (tickets == null)
        {
            throw new KeyNotFoundException("Tickets not found");
        }
        return tickets;
    }

    public Ticket Create(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        _context.SaveChanges();
        return ticket;
    }

    public Ticket Update(Ticket ticket)
    {
        _context.Entry(ticket).State = EntityState.Modified;
        _context.SaveChanges();
        return ticket;
    }

    public Ticket Delete(long id)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        _context.Tickets.Remove(ticket);
        _context.SaveChanges();
        return ticket;
    }

    public Ticket Close(long id)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        ticket.ClosedAt = DateTime.Now;
        _context.Tickets.Update(ticket);
        _context.SaveChanges();
        return ticket;
    }

    public Ticket Open(long id)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        ticket.ClosedAt = null;
        _context.Tickets.Update(ticket);
        _context.SaveChanges();
        return ticket;
    }

    public Ticket AssignEngineer(long id, User user)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        ticket.EngineerId = user.Id;
        _context.Tickets.Update(ticket);
        _context.SaveChanges();
        return ticket;
    }

    public Ticket UnassignEngineer(long id)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        ticket.EngineerId = null;
        _context.Tickets.Update(ticket);
        _context.SaveChanges();
        return ticket;
    }

    public Ticket AssignTag(long id, Tag tag)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        ticket.Tags ??= new List<Tag>();
        ticket.Tags.Add(tag);
        _context.Tickets.Update(ticket);
        _context.SaveChanges();
        return ticket;
    }

    public Ticket UnassignTag(long id, Tag tag)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        ticket.Tags!.Remove(tag);
        _context.Tickets.Update(ticket);
        _context.SaveChanges();
        return ticket;
    }
}