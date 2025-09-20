using LibraryManagementSystem.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
	internal class Loan : BaseEntity
	{
		#region Properties
		public DateTime LoanDate { get; set; }
		public LoanStatus Status { get; set; }
		#endregion

		#region Relationships
		public Fine? LoadFine { get; set; }
		public ICollection<MemberLoans> Loans { get; set; } = new HashSet<MemberLoans>(); 
		#endregion
	}
}
