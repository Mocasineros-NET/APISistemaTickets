using APISistemaTickets.Modules.KnowledgeBase.Domain.Entities;
using APISistemaTickets.Modules.Tickets.Domain.Entities;

namespace APISistemaTickets.Modules.Tags.Domain.Entities;

public class Tag
{
    public long TagId { get; set; }

    public string Name { get; set; }

    public long KnowledgeBaseArticleId { get; set; }
    
    public virtual KnowledgeBaseArticle? KnowledgeBaseArticle { get; set; }
    
    public virtual ICollection<Ticket>? Tickets { get; set; }
}