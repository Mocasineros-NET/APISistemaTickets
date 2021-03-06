using APISistemaTickets.Modules.Helpers;
using APISistemaTickets.Modules.Tags.Domain.Abstractions;
using APISistemaTickets.Modules.Tags.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APISistemaTickets.Modules.Tags.Domain.Services;

class TagService : ITagService
{
    private DataContext _context;
    
    public TagService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Tag>?> GetTags()
    {
        return await _context.Tags.ToListAsync();
    }

    public async Task<Tag?> GetById(long id)
    {
        var tag = await _context.Tags.FindAsync(id);
        if (tag == null)
        {
            throw new KeyNotFoundException("Tag not found");
        }
        return tag;
    }

    public async Task<Tag> Create(Tag tag)
    {
        _context.Tags.Add(tag);
        await _context.SaveChangesAsync();
        return tag;
    }

    public async Task<Tag> Update(Tag tag)
    {
        _context.Tags.Update(tag);
        await _context.SaveChangesAsync();
        return tag;
    }

    public async Task Delete(long id)
    {
        var tag = await _context.Tags.FindAsync(id);
        if (tag == null)
        {
            throw new KeyNotFoundException("Tag not found");
        }
        _context.Tags.Remove(tag);
        await _context.SaveChangesAsync();
    }
}