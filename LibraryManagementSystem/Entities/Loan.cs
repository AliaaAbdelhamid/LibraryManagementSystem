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
		public DateTime LoanDate { get; set; }
		public LoanStatus Status { get; set; }
	}
}
