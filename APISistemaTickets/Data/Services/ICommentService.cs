using APISistemaTickets.Data.Models.App;

namespace APISistemaTickets.Data.Services;

public interface ICommentService
{
    Task<IEnumerable<Comment>?> GetAll();
    Task<Comment?> GetById(long id);
    Task<Comment> Create(Comment comment);
    Task<Comment> Update(Comment comment);
    Task Delete(long id);
}