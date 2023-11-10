using FLuentAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FLuentAPI.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .IsRequired(false);
            builder.Property(x => x.FullName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Salary)
                .HasDefaultValue(100)
                .IsRequired(true);
                
        }
    }
}
