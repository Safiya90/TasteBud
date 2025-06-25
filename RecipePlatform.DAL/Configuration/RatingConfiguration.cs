using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipePlatform.Models.Entities;

namespace RecipePlatform.DAL.Configuration
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            //Properties
            builder.Property(r => r.RatingStar)
                .IsRequired()
                .HasDefaultValue(0); // Default rating star value
            builder.Property(r => r.CreatedDate)
                .HasDefaultValueSql("GETDATE()"); // Default to current date
            builder.Property(r => r.UpdatedDate)
                .HasDefaultValueSql("GETDATE()"); // Default to current date
            // Relationships
            builder.HasOne(r => r.Recipe)
                .WithMany(r => r.Ratings)
                .HasForeignKey(r => r.RecipeId)
                .OnDelete(DeleteBehavior.NoAction); // Cascade delete if the Recipe is deleted
        }
    }
}
