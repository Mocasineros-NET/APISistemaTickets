using APISistemaTickets.Data.Models.App;

namespace APISistemaTickets.Data.Services;

public interface IArticleService
{
    Task<IEnumerable<KnowledgeBaseArticle>?> GetAll();
    Task<KnowledgeBaseArticle?> GetById(long id);
    Task<KnowledgeBaseArticle> Create(KnowledgeBaseArticle article);
    Task<KnowledgeBaseArticle> Update(KnowledgeBaseArticle article);
    Task Delete(long id);
}