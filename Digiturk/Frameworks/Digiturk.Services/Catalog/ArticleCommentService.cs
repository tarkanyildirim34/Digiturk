using System;
using System.Linq;
using Digiturk.Core;
using Digiturk.Core.Data;
using Digiturk.Core.Domain.Catalog;

namespace Digiturk.Services.Catalog
{
    public class ArticleCommentService : IArticleCommentService
    {
        #region Fields

        //private readonly ICacheManager _cacheManager;
        private readonly IRepository<ArticleComment> _articlecommentRepository;


        #endregion

        #region Ctor

        public ArticleCommentService(IRepository<ArticleComment> articlecommentRepository)
        {
            //_cacheManager = cacheManager;
            _articlecommentRepository = articlecommentRepository;

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

        public IPagedList<ArticleComment> GetAllArticleComments(string articlecommentName = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var query = _articlecommentRepository.Table;

            if (!showHidden)
                query = query.Where(m => m.Published);

            query = query.Where(m => !m.Deleted);

            query = query.Distinct().OrderBy(m => m.Id);

            return new PagedList<ArticleComment>(query, pageIndex, pageSize);

        }

        public ArticleComment GetArticleCommentById(int articlecommentId)
        {
            if (articlecommentId == 0)
                return null;

            return _articlecommentRepository.GetById(articlecommentId);
        }

        public void InsertArticleComment(ArticleComment articlecomment)
        {
            if (articlecomment == null)
                throw new ArgumentNullException(nameof(articlecomment));

            _articlecommentRepository.Insert(articlecomment);
        }

        public void UpdateArticleComment(ArticleComment articlecomment)
        {
            if (articlecomment == null)
                throw new ArgumentNullException(nameof(articlecomment));

            _articlecommentRepository.Update(articlecomment);
        }

        #endregion
    }
}
