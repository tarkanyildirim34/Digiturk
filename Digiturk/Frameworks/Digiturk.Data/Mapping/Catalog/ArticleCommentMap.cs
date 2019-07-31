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
            builder.Property(articlecomment => articlecomment.ArticleId).HasDefaultValue(0).IsRequired();
            builder.Property(articlecomment => articlecomment.Content).IsRequired();
            builder.Property(articlecomment => articlecomment.CreateDate).HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(articlecomment => articlecomment.CreateUserId).HasDefaultValue(0).IsRequired();
            builder.Property(articlecomment => articlecomment.Published).HasDefaultValue(1).IsRequired();
            builder.Property(articlecomment => articlecomment.Deleted).HasDefaultValue(0).IsRequired();


            base.Configure(builder);
        }

        #endregion
    }
}
