using System.Collections.Generic;
using Digiturk.Core;
using Digiturk.Core.Domain.Catalog;

namespace Digiturk.Services.Catalog
{
    public interface IArticleCommentService
    {   /// <summary>
        /// Deletes a articlecomment
        /// </summary>
        /// <param name="articlecomment">ArticleComment</param>
        void DeleteArticleComment(ArticleComment articlecomment);

        /// <summary>
        /// Gets all articlecomments
        /// </summary>
        /// <param name="articlecommentName">ArticleComment name</param> 
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>ArticleComments</returns>
        IPagedList<ArticleComment> GetAllArticleComments(int Id = 0,int ArticleId = 0,string Content = "",int UserId = 0,
            int pageIndex = 0,
            int pageSize = int.MaxValue,
            bool showHidden = false);


        /// <summary>
        /// Gets a articlecomment
        /// </summary>
        /// <param name="articlecommentId">ArticleComment identifier</param>
        /// <returns>ArticleComment</returns>
        ArticleComment GetArticleCommentById(int articlecommentId);

        /// <summary>
        /// Inserts a articlecomment
        /// </summary>
        /// <param name="articlecomment">ArticleComment</param>
        void InsertArticleComment(ArticleComment articlecomment);

        /// <summary>
        /// Updates the articlecomment
        /// </summary>
        /// <param name="articlecomment">ArticleComment</param>
        void UpdateArticleComment(ArticleComment articlecomment);
    }
}
