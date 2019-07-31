using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Digiturk.Core.Domain.Catalog;
using System;

namespace Digiturk.Data.Mapping.Catalog
{
    public partial class ArticleMap : DigiturkEntityTypeConfiguration<Article>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable(nameof(Article));
            builder.HasKey(article => article.Id);
            builder.Property(article => article.UserId).IsRequired();
            builder.Property(article => article.Body).IsRequired();
            builder.Property(article => article.Date).HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(article => article.Deleted).HasDefaultValue(0).IsRequired();
            builder.Property(article => article.Description).HasMaxLength(500).IsRequired();
            builder.Property(article => article.Image).HasMaxLength(500).IsRequired();
            builder.Property(article => article.Title).HasMaxLength(500).IsRequired();
            builder.Property(article => article.Published).HasDefaultValue(1).IsRequired();

            base.Configure(builder);
        }

        #endregion
    }
}
