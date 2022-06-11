using APISistemaTickets.Modules.Tags.Domain.Entities;

namespace APISistemaTickets.Modules.Tags.Domain.Abstractions;

public interface ITagService
{
    Task<IEnumerable<Tag>?> GetTags();
    Task<Tag?> GetById(long id);
    Task<Tag> Create(Tag tag);
    Task<Tag> Update(Tag tag);
    Task Delete(long id);
}