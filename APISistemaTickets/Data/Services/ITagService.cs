using APISistemaTickets.Data.Models.App;

namespace APISistemaTickets.Data.Services;

public interface ITagService
{
    Task<IEnumerable<Tag>?> GetTags();
    Task<Tag?> GetById(long id);
    Task<Tag> Create(Tag tag);
    Task<Tag> Update(Tag tag);
    Task Delete(long id);
}