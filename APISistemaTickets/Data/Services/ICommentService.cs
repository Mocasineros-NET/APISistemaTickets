using APISistemaTickets.Data.Models.App;

namespace APISistemaTickets.Data.Services;

public interface ICommentService
{
    IEnumerable<Comment> GetAll();
    Comment GetById(int id);
    Comment Create(Comment comment);
    Comment Update(Comment comment);
    void Delete(int id);
}