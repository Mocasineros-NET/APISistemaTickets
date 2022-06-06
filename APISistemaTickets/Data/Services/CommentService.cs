using APISistemaTickets.Data.Models.App;
using APISistemaTickets.Helpers;
using Microsoft.EntityFrameworkCore;

namespace APISistemaTickets.Data.Services;

class CommentService : ICommentService
{
    private DataContext _context;
    
    public CommentService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Comment>?> GetAll()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetById(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if(comment == null)
        {
            throw new KeyNotFoundException("Comment not found");
        }
        return comment;
    }

    public async Task<Comment> Create(Comment comment)
    {
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment> Update(Comment comment)
    {
        _context.Comments.Update(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task Delete(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if(comment == null)
        {
            throw new KeyNotFoundException("Comment not found");
        }
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
    }
}