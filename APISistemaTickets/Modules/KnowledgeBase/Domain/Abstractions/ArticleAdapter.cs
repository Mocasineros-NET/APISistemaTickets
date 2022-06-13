using APISistemaTickets.Modules.KnowledgeBase.Application.DTO;
using APISistemaTickets.Modules.KnowledgeBase.Domain.Entities;
using AutoMapper;

namespace APISistemaTickets.Modules.KnowledgeBase.Domain.Abstractions;

public class ArticleAdapter : Profile
{
    public ArticleAdapter()
    {
        CreateMap<KnowledgeBaseArticleDTO, KnowledgeBaseArticle>();
    }
}