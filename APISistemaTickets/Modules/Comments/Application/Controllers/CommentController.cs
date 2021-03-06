using APISistemaTickets.Modules.Authorization;
using APISistemaTickets.Modules.Comments.Application.DTO;
using APISistemaTickets.Modules.Comments.Domain.Abstractions;
using APISistemaTickets.Modules.Comments.Domain.Entities;
using APISistemaTickets.Modules.UserAdministration.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APISistemaTickets.Modules.Comments.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly  IMapper _mapper;
        private ICommentService _commentService;
        
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }
        
        
        // PUT: api/Comment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(long id, CommentDTO comment)
        {
            Comment? oldComment = await _commentService.GetById(id);
            if (oldComment == null)
            {
                return BadRequest();
            }
            _mapper.Map<CommentDTO, Comment>(comment, oldComment);
            await _commentService.Update(oldComment);
            return NoContent();
        }

        // POST: api/Comment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Role.Admin, Role.Engineer,Role.Manager)]
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(CommentDTO comment)
        {
            var userId = ((User) HttpContext.Items["User"]!).Id;
            var newComment = _mapper.Map<Comment>(comment);
            newComment.UserId = userId;
            await _commentService.Create(newComment);
            return Created(userId.ToString(), newComment);
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        [Authorize(Role.Admin, Role.Engineer,Role.Manager)]
        public async Task<IActionResult> DeleteComment(long id)
        {
            
            if(await _commentService.GetById(id)==null)
            {
                return NotFound();
            }
            await _commentService.Delete(id);
            return NoContent();
        }

        
    }
}
