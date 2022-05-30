using APISistemaTickets.Data.Models.Auth;

namespace APISistemaTickets.Data.Models;

public class Comment
{
    public long CommentId { get; set; }
    
    public long TicketId { get; set; }
    
    public virtual Ticket? Ticket { get; set; }
    
    public long UserId { get; set; }
    
    public virtual User? User { get; set; }
    
    public string Text { get; set; }
}