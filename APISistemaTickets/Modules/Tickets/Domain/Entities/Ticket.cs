using APISistemaTickets.Modules.Comments.Domain.Entities;
using APISistemaTickets.Modules.Tags.Domain.Entities;
using APISistemaTickets.Modules.UserAdministration.Domain.Entities;

namespace APISistemaTickets.Modules.Tickets.Domain.Entities;

public class Ticket
{
    public long Id { get; set; }
    
    public long UserId { get; set; }

    public virtual User? User { get; set; }
    
    public long? EngineerId { get; set; }
    
    public virtual User? Engineer { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public DateTime? ClosedAt { get; set; }
    
    public bool IsClosed => ClosedAt != null;
    
    public Priority Priority { get; set; }
    
    public virtual ICollection<Tag>? Tags { get; set; }
    
    public virtual ICollection<Comment>? Comments { get; set; }
}