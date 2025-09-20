using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Contexts
{
	internal static class LibraryDbContextSeed
	{
		public static bool SeedData(LibraryDbContext dbContext)
		{
			try
			{
				dbContext.Database.Migrate();

				bool hasAuthors = dbContext.Authors.Any();
				bool hasCategories = dbContext.Categories.Any();
				bool hasBooks = dbContext.Books.Any();

				if (hasAuthors && hasCategories && hasBooks) return false;

				if (!hasAuthors)
				{
					var authors = JsonSeeder.LoadFromJson<Author>("Files/Authors.json");
					dbContext.Authors.AddRange(authors);
				}

				if (!hasCategories)
				{
					var categories = JsonSeeder.LoadFromJson<Category>("Files/Categories.json");
					dbContext.Categories.AddRange(categories);
				}
				dbContext.SaveChanges();
				if (!hasBooks)
				{
					var books = JsonSeeder.LoadFromJson<Book>("Files/Books.json");
					dbContext.Books.AddRange(books);
				}

				int rows = dbContext.SaveChanges();
				return rows > 0;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Seeding failed: {ex}");
				return false;
			}
		}
	}
}
