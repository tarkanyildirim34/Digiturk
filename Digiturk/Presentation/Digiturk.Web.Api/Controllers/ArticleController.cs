using System;
using System.Collections.Generic;
using App.Services.Logging;
using Digiturk.Core.Domain.Catalog;
using Digiturk.Services.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Digiturk.Web.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService; 
        private readonly IUserActivityService _userActivityService;
        private readonly IUserService _userService;
        public ArticleController(IArticleService articleService,
            IUserActivityService userActivityService,
            IUserService userService,
             IArticleCommentService articleCommentService)
        {
            _articleService = articleService;
            _userActivityService = userActivityService;
            _userService = userService; 
        }

        // GET api/Article
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_articleService.GetAllArticles());
        }

        [Route("~/api/Article/Search")]
        [HttpGet]
        public IEnumerable<Article> SearchArticle(string title,string description,int userid)
        {
           var query= _articleService.GetAllArticles(userId: userid,title: title,description:description);
            return query;
        }

        [Route("~/api/Article/GetAll")]
        [HttpGet]
        public IEnumerable<Article> GetAll()
        {
            return _articleService.GetAllArticles();
        }

        [Route("~/api/Article/Insert")]
        [HttpPost]
        public ActionResult Insert([FromBody]Article entity)
        {
            _articleService.InsertArticle(entity);

            var user = _userService.GetUserById(1);

            _userActivityService.InsertActivity(user, "AddNewArticle",
              string.Format("Yeni Makale Eklendi", entity.Id), entity);

            return Ok(new { Article = entity });
        }

        [Route("~/api/Article/Update")]
        [HttpPost]
        public ActionResult Update([FromBody]Article entity)
        {
            _articleService.UpdateArticle(entity);

            var user = _userService.GetUserById(1);

            _userActivityService.InsertActivity(user, "UpdateArticle",
              string.Format("Makale Güncellendi", entity.Id), entity);

            return Ok(new { Article = entity });
        }

        [Route("~/api/Article/Delete")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var entity = _articleService.GetArticleById(id);
            _articleService.DeleteArticle(entity);

            var user = _userService.GetUserById(1);

            _userActivityService.InsertActivity(user, "DeleteArticle",
              string.Format("Makale Silindi", id), entity);

            return Ok(new { Article = entity });
        }

    }
}