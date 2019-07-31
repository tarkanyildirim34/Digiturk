using System.Collections.Generic;
using Digiturk.Core;
using Digiturk.Core.Domain.Catalog;

namespace Digiturk.Services.Catalog
{
    public interface IArticleService
    {
        /// <summary>
        /// Deletes a article
        /// </summary>
        /// <param name="article">Article</param>
        void DeleteArticle(Article article);

        /// <summary>
        /// Gets all articles
        /// </summary>
        /// <param name="articleName">Article name</param> 
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Articles</returns>
        IPagedList<Article> GetAllArticles(int userId = 0, string title="",string description="",
            int pageIndex = 0,
            int pageSize = int.MaxValue,
            bool showHidden = false);


        /// <summary>
        /// Gets a article
        /// </summary>
        /// <param name="articleId">Article identifier</param>
        /// <returns>Article</returns>
        Article GetArticleById(int articleId);

        /// <summary>
        /// Inserts a article
        /// </summary>
        /// <param name="article">Article</param>
        void InsertArticle(Article article);

        /// <summary>
        /// Updates the article
        /// </summary>
        /// <param name="article">Article</param>
        void UpdateArticle(Article article);
    }
}
