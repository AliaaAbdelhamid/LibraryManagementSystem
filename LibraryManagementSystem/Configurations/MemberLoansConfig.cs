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
	internal class MemberLoansConfig : IEntityTypeConfiguration<MemberLoans>
	{
		public void Configure(EntityTypeBuilder<MemberLoans> builder)
		{
			builder.HasKey(X => new { X.MemberId, X.LoanId, X.BookId });
		}
	}
}
