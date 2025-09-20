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
	internal class FineConfig : IEntityTypeConfiguration<Fine>
	{
		public void Configure(EntityTypeBuilder<Fine> builder)
		{
			builder.Property(X => X.Amount)
				.HasPrecision(6, 2);

			builder.Property(X => X.IssuedDate)
				   .HasDefaultValueSql("GETDATE()");

			builder.Property(X => X.Status)
				   .HasConversion<string>()
				   .HasMaxLength(7);
		}
	}
}
