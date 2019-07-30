using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Digiturk.Core.Domain.Catalog;

namespace Digiturk.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a user mapping configuration
    /// </summary>
    public partial class UserMap : DigiturkEntityTypeConfiguration<User>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Name).HasMaxLength(50).IsRequired();
            builder.Property(user => user.Surname).HasMaxLength(50).IsRequired();
            builder.Property(user => user.UserName).HasMaxLength(50).IsRequired();
            builder.Property(user => user.Password).HasMaxLength(50).IsRequired();
  

            base.Configure(builder);
        }

        #endregion
    }
}