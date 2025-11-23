using AdminPanel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.Infrastructure.Data.Configurations;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.ToTable("Restaurants");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(r => r.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(r => r.Address)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(r => r.City)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(r => r.State)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(r => r.ZipCode)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(r => r.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(r => r.Email)
            .HasMaxLength(255);

        builder.Property(r => r.Website)
            .HasMaxLength(500);

        builder.Property(r => r.LogoUrl)
            .HasMaxLength(500);

        builder.Property(r => r.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(r => r.Rating)
            .HasPrecision(3, 2)
            .HasDefaultValue(0);

        builder.Property(r => r.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(r => r.CreatedAt)
            .IsRequired();

        builder.Property(r => r.UpdatedAt);
    }
}
