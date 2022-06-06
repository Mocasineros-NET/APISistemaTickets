using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISistemaTickets.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APISistemaTickets.Data.Models.App;
using APISistemaTickets.Data.Models.Auth;
using APISistemaTickets.Data.Models.DTO.App;
using APISistemaTickets.Data.Services;
using APISistemaTickets.Helpers;
using AutoMapper;

namespace APISistemaTickets.Controllers.App
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeBaseArticleController : ControllerBase
    {
      private readonly  IMapper _mapper;
      private IArticleService _articleService;
      
        public KnowledgeBaseArticleController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

      

        // GET: api/KnowledgeBaseArticle
        [Authorize(Role.Admin, Role.Engineer, Role.Manager)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnowledgeBaseArticle>>> GetKnowledgeBaseArticles()
        {
            var articles = await _articleService.GetAll();
          if (articles == null)
          {
              return NotFound();
          }

          return articles.ToList();
        }

        // GET: api/KnowledgeBaseArticle/5
        [Authorize(Role.Admin, Role.Engineer, Role.Manager)]
        [HttpGet("{id}")]
        public async Task<ActionResult<KnowledgeBaseArticle>> GetKnowledgeBaseArticle(long id)
        {
            var article = await _articleService.GetById(id);
          if (article == null)
          {
              return NotFound();
          }
          return article;
        }

        // PUT: api/KnowledgeBaseArticle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Role.Admin, Role.Engineer, Role.Manager)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnowledgeBaseArticle(long id, KnowledgeBaseArticleDTO article)
        {
            KnowledgeBaseArticle? oldArticle = await _articleService.GetById(id);
            if (oldArticle == null)
            {
                return BadRequest();
            }
            // oldArticle.UserId = article.UserId;
            // oldArticle.Title = article.Title;
            // oldArticle.Content = article.Content;
            _mapper.Map<KnowledgeBaseArticleDTO, KnowledgeBaseArticle>(article, oldArticle);
            await _articleService.Update(oldArticle);
            return NoContent();
        }

        // POST: api/KnowledgeBaseArticle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Role.Admin, Role.Engineer, Role.Manager)]
        [HttpPost]
        public async Task<ActionResult<KnowledgeBaseArticle>> PostKnowledgeBaseArticle(KnowledgeBaseArticleDTO article)
        {
         var userId = ((User) HttpContext.Items["User"]!).Id;
         var newArticle = _mapper.Map<KnowledgeBaseArticle>(article);
         newArticle.UserId = userId;
         await _articleService.Create(newArticle);
         return Created(userId.ToString(), newArticle);
        }

        // DELETE: api/KnowledgeBaseArticle/5
        [HttpDelete("{id}")]
        [Authorize(Role.Admin, Role.Engineer, Role.Manager)]
        public async Task<IActionResult> DeleteKnowledgeBaseArticle(long id)
        {
            if (await _articleService.GetById(id)== null)
            {
                return NotFound();
            }
            
            await _articleService.Delete(id);
            return NoContent();
        }
        
    }
}
