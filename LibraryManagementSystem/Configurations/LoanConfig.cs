using LibraryManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Configurations
{
	internal class LoanConfig : IEntityTypeConfiguration<Loan>
	{
		public void Configure(EntityTypeBuilder<Loan> builder)
		{
			builder.Property(l => l.LoanDate)
				   .HasDefaultValueSql("GETDATE()");

			builder.Property(l => l.Status)
				   .HasConversion<string>() 
				   .HasMaxLength(8);
		}
	}
}
