using APISistemaTickets.Data.Models.App;
using APISistemaTickets.Helpers;

namespace APISistemaTickets.Data.Services;

class ArticleService : IArticleService
{
    private DataContext _context;
    
    public ArticleService(DataContext context)
    {
        _context = context;
    }
    
    public IEnumerable<KnowledgeBaseArticle> GetAll()
    {
        return _context.KnowledgeBaseArticles;
    }

    public KnowledgeBaseArticle GetById(int id)
    {
        var knowledgeBaseArticle = _context.KnowledgeBaseArticles.Find(id);
        if (knowledgeBaseArticle == null)
        {
            throw new KeyNotFoundException("Article not found");
        }
        return knowledgeBaseArticle;
    }

    public KnowledgeBaseArticle Create(KnowledgeBaseArticle article)
    {
        _context.KnowledgeBaseArticles.Add(article);
        _context.SaveChanges();
        return article;
    }

    public KnowledgeBaseArticle Update(KnowledgeBaseArticle article)
    {
        _context.KnowledgeBaseArticles.Update(article);
        _context.SaveChanges();
        return article;
    }

    public KnowledgeBaseArticle Delete(int id)
    {
        var knowledgeBaseArticle = _context.KnowledgeBaseArticles.Find(id);
        if (knowledgeBaseArticle == null)
        {
            throw new KeyNotFoundException("Article not found");
        }
        _context.KnowledgeBaseArticles.Remove(knowledgeBaseArticle);
        _context.SaveChanges();
        return knowledgeBaseArticle;
    }
}