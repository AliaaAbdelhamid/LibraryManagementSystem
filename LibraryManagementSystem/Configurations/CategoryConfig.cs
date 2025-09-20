using LibraryManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Configurations
{
	internal class CategoryConfig : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Property(X => X.Title)
				   .HasColumnType("varchar")
				   .HasMaxLength(50);

			builder.Property(X => X.Description)
				   .HasColumnType("varchar")
				   .HasMaxLength(100);
		}
	}
}
