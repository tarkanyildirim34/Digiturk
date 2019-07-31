using System;
using System.Linq;
using Digiturk.Core;
using Digiturk.Core.Caching;
using Digiturk.Core.Data;
using Digiturk.Core.Domain.Catalog;

namespace Digiturk.Services.Catalog
{
    public class ArticleCommentService : IArticleCommentService
    {
        #region CacheKeys

        public static string ArticleCommentsByIdCacheKey => "Digiturk.articleComment.id-{0}";
        public static string ArticleCommentsPrefixCacheKey => "Digiturk.articleComment.";

        #endregion

        #region Fields

        private readonly IRepository<ArticleComment> _articlecommentRepository;
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        public ArticleCommentService(IRepository<ArticleComment> articlecommentRepository,
            ICacheManager cacheManager)
        {
            _articlecommentRepository = articlecommentRepository;
            _cacheManager = cacheManager;

        }

        #endregion

        #region Methods

        public void DeleteArticleComment(ArticleComment articlecomment)
        {

            if (articlecomment == null)
                throw new ArgumentNullException("articlecomment");

            articlecomment.Deleted = true;
            UpdateArticleComment(articlecomment);
        }

        public IPagedList<ArticleComment> GetAllArticleComments(int Id = 0, int ArticleId = 0, string Content = "", int UserId = 0, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var query = _articlecommentRepository.Table;

            if (!showHidden)
                query = query.Where(m => m.Published);
            if (Id > 0)
                query = query.Where(m => m.Id == Id);
            if (ArticleId > 0)
                query = query.Where(m => m.ArticleId == ArticleId);
            if (Content != "")
                query = query.Where(m => m.Content == Content);
            if (UserId > 0)
                query = query.Where(m => m.CreateUserId == UserId);


            query = query.Where(m => !m.Deleted);

            query = query.Distinct().OrderBy(m => m.Id);

            return new PagedList<ArticleComment>(query, pageIndex, pageSize);
        }

        public ArticleComment GetArticleCommentById(int articlecommentId)
        {
            if (articlecommentId == 0)
                return null;

            var key = string.Format(ArticleCommentsByIdCacheKey, articlecommentId);
            return _cacheManager.Get(key, () => _articlecommentRepository.GetById(articlecommentId));

        }

        public void InsertArticleComment(ArticleComment articlecomment)
        {
            if (articlecomment == null)
                throw new ArgumentNullException(nameof(articlecomment));

            _articlecommentRepository.Insert(articlecomment);

            //cache
            _cacheManager.RemoveByPrefix(ArticleCommentsPrefixCacheKey);
        }

        public void UpdateArticleComment(ArticleComment articlecomment)
        {
            if (articlecomment == null)
                throw new ArgumentNullException(nameof(articlecomment));

            _articlecommentRepository.Update(articlecomment);

            //cache
            _cacheManager.RemoveByPrefix(ArticleCommentsPrefixCacheKey);
        }

        #endregion
    }
}
