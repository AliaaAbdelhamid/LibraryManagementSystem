using LibraryManagementSystem.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
	internal class Member : BaseEntity
	{
		#region Properties
		public string Name { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public string Address { get; set; } = null!;
		public DateTime MembershipDate { get; set; }
		public MemberStatus Status { get; set; }
		#endregion

		#region Relationships
		public ICollection<MemberLoans> MemberLoans { get; set; } = new HashSet<MemberLoans>();

		#endregion
	}
}
