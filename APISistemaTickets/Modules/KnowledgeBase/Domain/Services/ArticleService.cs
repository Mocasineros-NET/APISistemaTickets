using APISistemaTickets.Modules.Helpers;
using APISistemaTickets.Modules.KnowledgeBase.Domain.Abstractions;
using APISistemaTickets.Modules.KnowledgeBase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APISistemaTickets.Modules.KnowledgeBase.Domain.Services;

class ArticleService : IArticleService
{
    private DataContext _context;
    
    public ArticleService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<KnowledgeBaseArticle>?> GetAll()
    {
        return await _context.KnowledgeBaseArticles.ToListAsync();
    }

    public async Task<KnowledgeBaseArticle?> GetById(long id)
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

    public async Task Delete(long id)
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