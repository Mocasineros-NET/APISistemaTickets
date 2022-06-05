using APISistemaTickets.Data.Models.App;
using APISistemaTickets.Helpers;
using Microsoft.EntityFrameworkCore;

namespace APISistemaTickets.Data.Services;

class ArticleService : IArticleService
{
    private DataContext _context;
    
    public ArticleService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<KnowledgeBaseArticle>> GetAll()
    {
        return await _context.KnowledgeBaseArticles.ToListAsync();
    }

    public async Task<KnowledgeBaseArticle> GetById(int id)
    {
        var knowledgeBaseArticle = await _context.KnowledgeBaseArticles.FindAsync(id);
        if (knowledgeBaseArticle == null)
        {
            throw new KeyNotFoundException("Article not found");
        }
        return knowledgeBaseArticle;
    }

    public async Task<KnowledgeBaseArticle> Create(KnowledgeBaseArticle article)
    {
        _context.KnowledgeBaseArticles.Add(article);
        await _context.SaveChangesAsync();
        return article;
    }

    public async Task<KnowledgeBaseArticle> Update(KnowledgeBaseArticle article)
    {
        _context.KnowledgeBaseArticles.Update(article);
        await _context.SaveChangesAsync();
        return article;
    }

    public async Task Delete(int id)
    {
        var knowledgeBaseArticle = await _context.KnowledgeBaseArticles.FindAsync(id);
        if (knowledgeBaseArticle == null)
        {
            throw new KeyNotFoundException("Article not found");
        }
        _context.KnowledgeBaseArticles.Remove(knowledgeBaseArticle);
        await _context.SaveChangesAsync();
    }
}