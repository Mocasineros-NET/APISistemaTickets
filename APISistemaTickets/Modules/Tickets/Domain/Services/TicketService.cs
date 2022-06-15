using APISistemaTickets.Modules.Helpers;
using APISistemaTickets.Modules.Tags.Domain.Entities;
using APISistemaTickets.Modules.Tickets.Domain.Abstractions;
using APISistemaTickets.Modules.Tickets.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APISistemaTickets.Modules.Tickets.Domain.Services;

class TicketService : ITicketService
{
    private DataContext _context;

    public TicketService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Ticket>?> GetAll()
    {
        return await _context.Tickets.ToListAsync();
    }

    public async Task<Ticket?> GetById(long id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        return ticket;
    }

    public async Task<IEnumerable<Ticket>?> GetByUserId(long id)
    {
        var tickets = _context.Tickets.Where(t => t.UserId == id);
        if (tickets == null)
        {
            throw new KeyNotFoundException("Tickets not found");
        }
        return await tickets.ToListAsync();
    }

    public async Task<IEnumerable<Ticket>?> GetByEngineerId(long id)
    {
        var tickets = _context.Tickets.Where(t => t.EngineerId == id);
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

    public async Task<Ticket> AssignEngineer(long id, long engineerId)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        ticket.EngineerId = engineerId;
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

    public async Task<Ticket> AssignTag(long id, long tagId)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        ticket.Tags ??= new List<Tag>();
        ticket.Tags.Add((await _context.Tags.FindAsync(tagId))!);
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }
    
    public async Task<Ticket> UnassignTag(long id, long tagId)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        ticket.Tags!.Remove((await _context.Tags.FindAsync(tagId))!);
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }
    public async Task SetPriority(long id, Priority priority)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }
        ticket.Priority = priority;
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
    }
}