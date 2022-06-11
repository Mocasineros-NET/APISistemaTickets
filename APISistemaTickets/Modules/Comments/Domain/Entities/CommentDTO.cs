namespace APISistemaTickets.Modules.Comments.Domain.Entities;

public class CommentDTO
{
    public long TicketId { get; set; }
    
    public string Text { get; set; }
}