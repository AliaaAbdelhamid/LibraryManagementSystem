using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
	internal class Book : BaseEntity
	{
		public string Title { get; set; } = null!;
		public decimal Price { get; set; }
		public int PublicationYear { get; set; }
		public int AvailableCopies { get; set; }
		public int TotalCopies { get; set; }

	}
}
