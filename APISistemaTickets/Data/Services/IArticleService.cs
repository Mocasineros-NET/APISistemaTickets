using APISistemaTickets.Data.Models.App;

namespace APISistemaTickets.Data.Services;

public interface IArticleService
{
    IEnumerable<KnowledgeBaseArticle> GetAll();
    KnowledgeBaseArticle GetById(int id);
    KnowledgeBaseArticle Create(KnowledgeBaseArticle article);
    KnowledgeBaseArticle Update(KnowledgeBaseArticle article);
    KnowledgeBaseArticle Delete(int id);
}