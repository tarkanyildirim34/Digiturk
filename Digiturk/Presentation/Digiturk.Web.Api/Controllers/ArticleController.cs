using System;
using System.Collections.Generic;
using App.Services.Logging;
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
        private readonly IArticleCommentService _articleCommentService;
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
            _articleCommentService = articleCommentService;
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

        [Route("~/api/Article/CreateArticleTest")]
        [HttpGet]
        public Article CreateArticleTest()
        {
            var article = new Article()
            {
                Body = "test22",
                Date = DateTime.Now,
                Deleted = false,
                Description = "testt3333",
                Image = "test444",
                Published = true,
                Title = "test555",
                UserId = 1
            };

            _articleService.InsertArticle(article);

            var user = _userService.GetUserById(1);

            _userActivityService.InsertActivity(user, "AddNewArticle",
                  string.Format("Yeni Makale Eklendi", article.Id), article);

            var articleComment = new ArticleComment()
            {
                ArticleId = 5,
                Content = "testttt",
                CreateDate = DateTime.Now,
                CreateUserId = 1,
                Deleted = false,
                Published = true

            };

            _articleCommentService.InsertArticleComment(articleComment);


            _userActivityService.InsertActivity(user, "AddNewArticleComment",
                  string.Format("Yeni Makale Yorumu Eklendi", article.Id), article);

            return article;
        }
    }
}