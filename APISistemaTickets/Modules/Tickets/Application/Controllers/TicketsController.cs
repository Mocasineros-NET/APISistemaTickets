using APISistemaTickets.Modules.Authorization;
using APISistemaTickets.Modules.Tickets.Application.DTO;
using APISistemaTickets.Modules.Tickets.Domain.Abstractions;
using APISistemaTickets.Modules.Tickets.Domain.Entities;
using APISistemaTickets.Modules.UserAdministration.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APISistemaTickets.Modules.Tickets.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;
        
        public TicketsController(ITicketService ticketService, IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }
        
        // GET: api/Tickets
        [Authorize(Role.Admin, Role.Manager)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            var tickets = await _ticketService.GetAll();
            if (tickets == null)
            {
                return NotFound();
            }
            return tickets.ToList();
        }

        // GET: api/Tickets/5
        [Authorize(Role.Admin, Role.Manager)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(long id)
        {
            var ticket = await _ticketService.GetById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return ticket;
        }
        
        //GET: api/Tickets/GetByUserId/5
        [Authorize(Role.Admin, Role.Manager)]
        [HttpGet("GetByUserId/{id}")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetByUserId(long id)
        {
            var tickets = await _ticketService.GetByUserId(id);
            if (tickets == null)
            {
                return NotFound();
            }
            return tickets.ToList();
        }
        
        //GET: api/Tickets/GetMyTickets
        [Authorize]
        [HttpGet("GetMyTickets")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetMyTickets()
        {
            var userId = ((User) HttpContext.Items["User"]!).Id;
            var tickets = await _ticketService.GetByUserId(userId);
            if (tickets == null)
            {
                return NotFound();
            }
            return tickets.ToList();
        }
        
        //GET: api/Tickets/GetMyAssignedTickets
        [Authorize(Role.Engineer)]
        [HttpGet("GetMyAssignedTickets")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetMyAssignedTickets()
        {
            var userId = ((User) HttpContext.Items["User"]!).Id;
            var tickets = await _ticketService.GetByEngineerId(userId);
            if (tickets == null)
            {
                return NotFound();
            }
            return tickets.ToList();
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(long id, TicketDTO ticket)
        {
            Ticket? oldTicket = await _ticketService.GetById(id);
            if (oldTicket == null)
            {
                return BadRequest();
            }
            oldTicket.Title = ticket.Title;
            oldTicket.Description = ticket.Description;
            await _ticketService.Update(oldTicket);
            return NoContent();
        }

        // POST: api/Tickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(TicketDTO ticket)
        {
            var userId = ((User) HttpContext.Items["User"]!).Id;
            var newTicket = _mapper.Map<Ticket>(ticket);
            newTicket.UserId = userId;
            await _ticketService.Create(newTicket);
            return Created(userId.ToString(), newTicket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        [Authorize(Role.Admin, Role.Manager)]
        public async Task<IActionResult> DeleteTicket(long id)
        {
            if (await _ticketService.GetById(id) == null)
            {
                return NotFound();
            }
            
            await _ticketService.Delete(id);
            return NoContent();
        }
        
        //POST: api/Tickets/Close/5
        [Authorize(Role.Admin, Role.Manager, Role.Engineer)]
        [HttpPost("Close/{id}")]
        public async Task<IActionResult> CloseTicket(long id)
        {
            if (await _ticketService.GetById(id) == null)
            {
                return NotFound();
            }
            
            await _ticketService.Close(id);
            return NoContent();
        }
        
        //POST: api/Tickets/Open/5
        [Authorize(Role.Admin, Role.Manager, Role.Engineer)]
        [HttpPost("Open/{id}")]
        public async Task<IActionResult> OpenTicket(long id)
        {
            if (await _ticketService.GetById(id) == null)
            {
                return NotFound();
            }
            
            await _ticketService.Open(id);
            return NoContent();
        }
        
        //POST: api/Tickets/Assign/5
        [Authorize(Role.Admin, Role.Manager)]
        [HttpPost("Assign/{id}")]
        public async Task<IActionResult> AssignTicket(long id, [FromBody] long engineerId)
        {
            if (await _ticketService.GetById(id) == null)
            {
                return NotFound();
            }
            
            await _ticketService.AssignEngineer(id, engineerId);
            return NoContent();
        }
        
        //POST: api/Tickets/Unassign/5
        [Authorize(Role.Admin, Role.Manager)]
        [HttpPost("Unassign/{id}")]
        public async Task<IActionResult> UnassignTicket(long id)
        {
            if (await _ticketService.GetById(id) == null)
            {
                return NotFound();
            }
            
            await _ticketService.UnassignEngineer(id);
            return NoContent();
        }
        
        //POST: api/Tickets/AssignTag/5
        [Authorize(Role.Admin, Role.Manager, Role.Engineer)]
        [HttpPost("AssignTag/{id}")]
        public async Task<IActionResult> AssignTag(long id, [FromBody] long tagId)
        {
            if (await _ticketService.GetById(id) == null)
            {
                return NotFound();
            }
            
            await _ticketService.AssignTag(id, tagId);
            return NoContent();
        }
        
        //POST: api/Tickets/UnassignTag/5
        [Authorize(Role.Admin, Role.Manager, Role.Engineer)]
        [HttpPost("UnassignTag/{id}")]
        public async Task<IActionResult> UnassignTag(long id, [FromBody] long tagId)
        {
            if (await _ticketService.GetById(id) == null)
            {
                return NotFound();
            }
            
            await _ticketService.UnassignTag(id, tagId);
            return NoContent();
        }
    }
}
