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

    public async Task<IEnumerable<Ticket>> GetAll()
    {
        return await _context.Tickets.ToListAsync();
    }

    public async Task<Ticket> GetById(long id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        return ticket;
    }

    public async Task<IEnumerable<Ticket>> GetByUserId(long id)
    {
        var tickets = _context.Tickets.Where(t => t.UserId == id);
        if (tickets == null)
        {
            throw new KeyNotFoundException("Tickets not found");
        }
        return await tickets.ToListAsync();
    }

    public async Task<Ticket> Create(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }

    public async Task<Ticket> Update(Ticket ticket)
    {
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }

    public async Task Delete(long id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync();
    }

    public async Task<Ticket> Close(long id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        ticket.ClosedAt = DateTime.Now;
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }

    public async Task<Ticket> Open(long id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        ticket.ClosedAt = null;
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }

    public async Task<Ticket> AssignEngineer(long id, User user)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        ticket.EngineerId = user.Id;
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }

    public async Task<Ticket> UnassignEngineer(long id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        ticket.EngineerId = null;
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }

    public async Task<Ticket> AssignTag(long id, Tag tag)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        ticket.Tags ??= new List<Tag>();
        ticket.Tags.Add(tag);
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }

    public async Task<Ticket> UnassignTag(long id, Tag tag)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        ticket.Tags!.Remove(tag);
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }
}