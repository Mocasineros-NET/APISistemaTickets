using APISistemaTickets.Data.Models.App;
using APISistemaTickets.Helpers;

namespace APISistemaTickets.Data.Services;

class TagService : ITagService
{
    private DataContext _context;
    
    public TagService(DataContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Tag> GetTags()
    {
        return _context.Tags;
    }

    public Tag GetById(int id)
    {
        var tag = _context.Tags.Find(id);
        if (tag == null)
        {
            throw new KeyNotFoundException("Tag not found");
        }
        return tag;
    }

    public Tag Create(Tag tag)
    {
        _context.Tags.Add(tag);
        _context.SaveChanges();
        return tag;
    }

    public Tag Update(Tag tag)
    {
        _context.Tags.Update(tag);
        _context.SaveChanges();
        return tag;
    }

    public void Delete(int id)
    {
        var tag = _context.Tags.Find(id);
        if (tag == null)
        {
            throw new KeyNotFoundException("Tag not found");
        }
        _context.Tags.Remove(tag);
        _context.SaveChanges();
    }
}