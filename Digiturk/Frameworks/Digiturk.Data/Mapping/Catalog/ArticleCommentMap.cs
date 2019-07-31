using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Digiturk.Core.Domain.Catalog;
using System;

namespace Digiturk.Data.Mapping.Catalog
{
    public class ArticleCommentCommentMap : DigiturkEntityTypeConfiguration<ArticleComment>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ArticleComment> builder)
        {
            builder.ToTable(nameof(ArticleComment));
            builder.HasKey(articlecomment => articlecomment.Id);
            builder.Property(articlecomment => articlecomment.ArticleId).IsRequired();
            builder.Property(articlecomment => articlecomment.Content).IsRequired();
            builder.Property(articlecomment => articlecomment.CreateDate).IsRequired();
            builder.Property(articlecomment => articlecomment.CreateUserId).IsRequired();
            builder.Property(articlecomment => articlecomment.Published).IsRequired();
            builder.Property(articlecomment => articlecomment.Deleted).IsRequired();


            base.Configure(builder);
        }

        #endregion
    }
}
