using APISistemaTickets.Data.Models.Auth;

namespace APISistemaTickets.Data.Models.App;

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
    
    public bool IsClosed => ClosedAt == null;
    
    public virtual ICollection<Tag>? Tags { get; set; }
    
    public virtual ICollection<Comment>? Comments { get; set; }
}