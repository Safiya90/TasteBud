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
    public class InstructionConfiguration : IEntityTypeConfiguration<Instruction>
    {
        public void Configure(EntityTypeBuilder<Instruction> builder)
        {
            //properties
            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(500); // Assuming a maximum length for the instruction name
        }
    }
}
