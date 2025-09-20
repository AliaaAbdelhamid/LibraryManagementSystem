using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
	internal class Book : BaseEntity
	{
		#region Properties
		public string Title { get; set; } = null!;
		public decimal Price { get; set; }
		public int PublicationYear { get; set; }
		public int AvailableCopies { get; set; }
		public int TotalCopies { get; set; } 
		#endregion

		#region Assigned Relationship
		public int AuthorId { get; set; }
		public Author BookAuthor { get; set; } = null!;
		#endregion

		#region Classified Relationship
		public int CategoryId { get; set; }
		public Category BookCategory { get; set; } = null!;
		#endregion

		#region Borrowing Relationship
		public ICollection<MemberLoans> BookLoans { get; set; } = new HashSet<MemberLoans>();
		#endregion
	}
}
