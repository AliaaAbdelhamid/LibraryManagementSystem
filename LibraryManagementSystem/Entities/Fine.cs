using LibraryManagementSystem.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
	internal class Fine : BaseEntity
	{
		public decimal Amount { get; set; }
		public DateTime IssuedDate { get; set; }
		public DateTime? PaidDate { get; set; }
		public FineStatus Status { get; set; }
	}
}
