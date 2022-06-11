using APISistemaTickets.Modules.KnowledgeBase.Domain.Entities;

namespace APISistemaTickets.Modules.KnowledgeBase.Domain.Abstractions;

public interface IArticleService
{
    Task<IEnumerable<KnowledgeBaseArticle>?> GetAll();
    Task<KnowledgeBaseArticle?> GetById(long id);
    Task<KnowledgeBaseArticle> Create(KnowledgeBaseArticle article);
    Task<KnowledgeBaseArticle> Update(KnowledgeBaseArticle article);
    Task Delete(long id);
}