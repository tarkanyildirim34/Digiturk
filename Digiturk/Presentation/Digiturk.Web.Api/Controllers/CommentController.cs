using System.Collections.Generic;
using Digiturk.Core.Domain.Catalog;
using Digiturk.Services.Catalog;
using Microsoft.AspNetCore.Mvc;

namespace Digiturk.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IArticleCommentService _articlecommentService;

        public CommentController(IArticleCommentService articlecommentService)
        {
            _articlecommentService = articlecommentService;
        }

        // GET api/Article
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_articlecommentService.GetAllArticleComments());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ArticleComment> Get(int id)
        {
            return _articlecommentService.GetArticleCommentById(id);
        }

        [Route("~/api/Comment/GetAllArticleComments")]
        [HttpGet]
        public IEnumerable<ArticleComment> GetAllArticleComments()
        {
            return _articlecommentService.GetAllArticleComments();
        }
    }
}