using FLuentAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FLuentAPI.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasDefaultValue("No name")
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            
            .IsRequired(false)
            .HasMaxLength(250);

        builder.HasOne(x => x.Author)
            .WithMany(x => x.Books);
    }
}
