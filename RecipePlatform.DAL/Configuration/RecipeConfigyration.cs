using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipePlatform.Models.Entities;

namespace RecipePlatform.DAL.Configuration
{
    public class RecipeConfigyration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            //Properties configuration
            builder.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(r => r.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.HasMany(r => r.Ingredients)
               .WithOne(i => i.Recipe)
               .HasForeignKey(i => i.RecipeId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Instructions)
                   .WithOne(ins => ins.Recipe)
                   .HasForeignKey(ins => ins.RecipeId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
