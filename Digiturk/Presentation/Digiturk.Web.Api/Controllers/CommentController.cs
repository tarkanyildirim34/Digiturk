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
    public class CommentController : ControllerBase
    {
        private readonly IArticleCommentService _articlecommentService;
        private readonly IUserActivityService _userActivityService;
        private readonly IUserService _userService;

        public CommentController(IArticleCommentService articlecommentService, IUserActivityService userActivityService,
            IUserService userService)
        {
            _articlecommentService = articlecommentService;
            _userActivityService = userActivityService;
            _userService = userService;
        }

        // GET api/Article
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_articlecommentService.GetAllArticleComments());
        }

        // GET api/values/5
        [Route("~/api/Comment/Search")]
        [HttpGet]
        public IEnumerable<ArticleComment> Search(int id,int articleid,string content,int userid)
        {
            var query = _articlecommentService.GetAllArticleComments(Id:id,ArticleId:articleid,Content:content, UserId: userid);
            return query; 
        }

        [Route("~/api/Comment/GetAll")]
        [HttpGet]
        public IEnumerable<ArticleComment> GetAll()
        {
            return _articlecommentService.GetAllArticleComments();
        }

        [Route("~/api/Comment/Insert")]
        [HttpPost]
        public ActionResult Insert([FromBody]ArticleComment entity)
        {
            _articlecommentService.InsertArticleComment(entity);

            var user = _userService.GetUserById(1);

            _userActivityService.InsertActivity(user, "AddNewComment",
              string.Format("Yeni Makale Eklendi", entity.Id), entity);

            return Ok(new { ArticleComment = entity });
        }


        [Route("~/api/Comment/Update")]
        [HttpPost]
        public ActionResult Update([FromBody]ArticleComment entity)
        {
            _articlecommentService.UpdateArticleComment(entity);

            var user = _userService.GetUserById(1);

            _userActivityService.InsertActivity(user, "UpdateComment",
              string.Format("Yorum Güncellendi", entity.Id), entity);

            return Ok(new { ArticleComment = entity });
        }

        [Route("~/api/Comment/Delete")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var entity = _articlecommentService.GetArticleCommentById(id);
            _articlecommentService.DeleteArticleComment(entity);

            var user = _userService.GetUserById(1);

            _userActivityService.InsertActivity(user, "DeleteComment",
              string.Format("Yorum Silindi", id), entity);

            return Ok(new { ArticleComment = entity });
        }

    }
}