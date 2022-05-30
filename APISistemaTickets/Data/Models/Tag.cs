namespace APISistemaTickets.Data.Models;

public class Tag
{
    public long TagId { get; set; }

    public string Name { get; set; }

    public long KnowledgeBaseArticleId { get; set; }
    
    public virtual KnowledgeBaseArticle KnowledgeBaseArticle { get; set; }
    
    public virtual ICollection<Ticket> Tickets { get; set; }
}