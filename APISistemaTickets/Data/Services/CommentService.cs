using APISistemaTickets.Data.Models.App;
using APISistemaTickets.Helpers;

namespace APISistemaTickets.Data.Services;

class CommentService : ICommentService
{
    private DataContext _context;
    
    public CommentService(DataContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Comment> GetAll()
    {
        return _context.Comments;
    }

    public Comment GetById(int id)
    {
        var comment = _context.Comments.Find(id);
        if(comment == null)
        {
            throw new KeyNotFoundException("Comment not found");
        }
        return comment;
    }

    public Comment Create(Comment comment)
    {
        _context.Comments.Add(comment);
        _context.SaveChanges();
        return comment;
    }

    public Comment Update(Comment comment)
    {
        _context.Comments.Update(comment);
        _context.SaveChanges();
        return comment;
    }

    public void Delete(int id)
    {
        var comment = _context.Comments.Find(id);
        if(comment == null)
        {
            throw new KeyNotFoundException("Comment not found");
        }
        _context.Comments.Remove(comment);
        _context.SaveChanges();
    }
}