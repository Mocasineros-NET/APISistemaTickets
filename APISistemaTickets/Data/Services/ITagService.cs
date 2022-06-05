using APISistemaTickets.Data.Models.App;

namespace APISistemaTickets.Data.Services;

public interface ITagService
{
    IEnumerable<Tag> GetTags();
    Tag GetById(int id);
    Tag Create(Tag tag);
    Tag Update(Tag tag);
    void Delete(int id);
}