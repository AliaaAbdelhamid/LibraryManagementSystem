using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Contexts
{
	internal class LibraryDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server =.; Database = LibraryManagementSystem; Trusted_Conecction =true ; TrustServerCertificate =true");
		}
	}
}
