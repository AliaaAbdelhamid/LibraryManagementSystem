using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
	internal class Author : BaseEntity
	{
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public DateTime DateOfBirth { get; set; }
		public ICollection<Book> AuthorBooks { get; set; } = new HashSet<Book>();
	}
}
