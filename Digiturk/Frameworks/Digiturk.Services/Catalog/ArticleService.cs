using System;
using System.Linq;
using Digiturk.Core;
using Digiturk.Core.Caching;
using Digiturk.Core.Data;
using Digiturk.Core.Domain.Catalog;

namespace Digiturk.Services.Catalog
{
    public class ArticleService : IArticleService
    {
        #region CacheKeys

        public static string ArticlesByIdCacheKey => "Digiturk.article.id-{0}";
        public static string ArticlesPrefixCacheKey => "Digiturk.article.";

        #endregion

        #region Fields

        //private readonly ICacheManager _cacheManager;
        private readonly IRepository<Article> _articleRepository;
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        public ArticleService(IRepository<Article> articleRepository,
            ICacheManager cacheManager)
        {
            //_cacheManager = cacheManager;
            _articleRepository = articleRepository;
            _cacheManager = cacheManager;
        }

        #endregion

        #region Methods

        public void DeleteArticle(Article article)
        {

            if (article == null)
                throw new ArgumentNullException("article");

            article.Deleted = true;
            UpdateArticle(article);
        }

        public IPagedList<Article> GetAllArticles(string articleName = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var query = _articleRepository.Table;

            if (!showHidden)
                query = query.Where(m => m.Published);

            query = query.Where(m => !m.Deleted);

            query = query.Distinct().OrderBy(m => m.Id);

            return new PagedList<Article>(query, pageIndex, pageSize);

        }

        public Article GetArticleById(int articleId)
        {
            if (articleId == 0)
                return null;

            var key = string.Format(ArticlesByIdCacheKey, articleId);
            return _cacheManager.Get(key, () => _articleRepository.GetById(articleId));
        }

        public void InsertArticle(Article article)
        {
            if (article == null)
                throw new ArgumentNullException(nameof(article));

            _articleRepository.Insert(article);

            //cache
            _cacheManager.RemoveByPrefix(ArticlesPrefixCacheKey);
        }

        public void UpdateArticle(Article article)
        {
            if (article == null)
                throw new ArgumentNullException(nameof(article));

            _articleRepository.Update(article);

            //cache
            _cacheManager.RemoveByPrefix(ArticlesPrefixCacheKey);
        }

        #endregion
    }
}
