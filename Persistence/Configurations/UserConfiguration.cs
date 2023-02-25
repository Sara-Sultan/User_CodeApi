using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.Property(User => User.ID).ValueGeneratedNever();


            //builder.Property(User => User.ID)
            //      .HasComputedColumnSql("sys.fn_varbintohexsubstring(0, HashBytes('SHA1', [Email]), 1, 0)");

            builder.Property(User => User.Email).IsRequired();
            builder.Property(User => User.FirstName).HasMaxLength(60);
            builder.Property(User => User.lastName).HasMaxLength(60);
            builder.Property(User => User.Email).HasMaxLength(60);
            builder.Property(User => User.MarketingConsent).IsRequired();
        }
    }
}
