using System.ComponentModel.DataAnnotations.Schema;
using APISistemaTickets.Data.Models.Auth;

namespace APISistemaTickets.Data.Models;

public class KnowledgeBaseArticle
{
    public long KnowledgeBaseArticleId { get; set; }
    
    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public virtual ICollection<Tag>? Tags { get; set; }
    
    public long UserId { get; set; }
    
    [ForeignKey("UserId")]
    public virtual User? Author { get; set; }
}