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
	internal class MemberConfig : IEntityTypeConfiguration<Member>
	{
		public void Configure(EntityTypeBuilder<Member> builder)
		{
			builder.Property(X => X.Name)
				   .HasColumnType("varchar").HasMaxLength(50);

			builder.Property(X => X.Email)
				   .HasColumnType("varchar").HasMaxLength(100);

			builder.Property(m => m.PhoneNumber)
				   .HasMaxLength(11);

			builder.Property(X => X.Address)
				   .HasColumnType("varchar").HasMaxLength(100);

			builder.Property(m => m.MembershipDate)
				   .HasDefaultValueSql("GETDATE()");

			builder.Property(m => m.Status)
				   .HasConversion<string>()  // Store enum label name instead of integer
				   .HasMaxLength(9);

			builder.ToTable(tb =>
			{
				tb.HasCheckConstraint("ValidEmailCheck","Email LIKE '%_@_%._%'");
				tb.HasCheckConstraint("CK_Member_PhoneNumber","PhoneNumber LIKE '01%' AND PhoneNumber NOT LIKE '%[^0-9]%'");
			});
		}
	}
}
