using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digiturk.Core.Domain.Catalog;
using Digiturk.Services.Catalog;
using Microsoft.AspNetCore.Mvc;

namespace Digiturk.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET api/Article
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_articleService.GetAllArticles());
        }

        [Route("~/api/Article/GetAllArticles")]
        [HttpGet]
        public IEnumerable<Article> GetAllArticles()
        {
            return _articleService.GetAllArticles();
        }
    }
}