using APISistemaTickets.Modules.Authorization;
using APISistemaTickets.Modules.Tags.Application.DTO;
using APISistemaTickets.Modules.Tags.Domain.Abstractions;
using APISistemaTickets.Modules.Tags.Domain.Entities;
using APISistemaTickets.Modules.UserAdministration.Domain.Entities;
using AutoMapper;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;

namespace APISistemaTickets.Modules.Tags.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ITagService _tagService;

        public TagsController(IMapper mapper, ITagService tagService)
        {
            _mapper = mapper;
            _tagService = tagService;
        }

        // GET: api/Tags/getAllTags
        [Authorize(Role.Manager)]
        [HttpGet("getAllTags")]
        public async Task<ActionResult<IEnumerable<Tag>>> GetAllTags()
        {
            var tags = await _tagService.GetTags();
            if (tags == null)
            {
                return NotFound();
            }

            return tags.ToList();
        }

        // GET: api/Tags/5
        [Authorize(Role.Manager)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTag(long id)
        {
            var tags = await _tagService.GetTags();
            if (tags.IsNullOrEmpty())
            {
                return NotFound();
            }

            var tag = await _tagService.GetById(id);

            if (tag == null)
            {
                return NotFound();
            }

            return tag;
        }

        // PUT: api/Tags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Role.Manager)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTag(long id, TagDTO tag)
        {
            var oldTag = await _tagService.GetById(id);
            if (oldTag == null)
            {
                return NotFound();
            }
            oldTag.Name = tag.Name;
            oldTag.KnowledgeBaseArticleId = tag.KnowledgeBaseArticleId;
            await _tagService.Update(oldTag);
            return NoContent();
        }

        // POST: api/Tags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Role.Manager)]
        [HttpPost]
        public async Task<ActionResult<Tag>> PostTag(TagDTO tag)
        {
            Tag newTag = _mapper.Map<Tag>(tag);
            await _tagService.Create(newTag);
            return CreatedAtAction("GetTag", new {id = newTag.TagId}, newTag);
        }

        // DELETE: api/Tags/5
        [Authorize(Role.Manager)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(long id)
        {
            if (await _tagService.GetById(id) == null)
            {
                return NotFound();
            }

            await _tagService.Delete(id);

            return NoContent();
        }
    }
}