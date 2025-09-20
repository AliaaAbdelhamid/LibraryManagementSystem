﻿using LibraryManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Contexts
{
	internal class LibraryDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server =.; Database = LibraryManagementSystem; Trusted_Connection =true ; TrustServerCertificate =true");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		#region DbSets 
		public DbSet<Author> Authors { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Loan> Loans { get; set; }
		public DbSet<Member> Members { get; set; }
		public DbSet<Fine> Fines { get; set; }
		public DbSet<MemberLoans> MemberLoans { get; set; } 
		#endregion
	}
}
