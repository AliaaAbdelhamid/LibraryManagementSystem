using LibraryManagementSystem.Contexts;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LibraryManagementSystem
{
    internal class Program
	{
		static void Main(string[] args)
		{
			using LibraryDbContext dbContext = new LibraryDbContext();
			LibraryDbContextSeed.SeedData(dbContext);

			#region CRUD Operations 

			#region Retrieve the book title, its category title , and the author’s full name for all books whose price is greater than 300

			//var Books = dbContext.Books.Where(B => B.Price > 300).Select(B => new
			//{
			//	BookTitle = B.Title,
			//	Category = B.BookCategory.Title,
			//	Author = (B.BookAuthor.FirstName ?? "") + " " + (B.BookAuthor.LastName ?? "")
			//}).ToList();


			//foreach (var item in Books)
			//	Console.WriteLine(item);


			#endregion

			#region Retrieve All Authors And His/Her Books if Exists. 

			//var Authors = dbContext.Authors.Include(X => X.AuthorBooks).ToList();

			//foreach (var author in Authors)
			//{
			//	Console.WriteLine($"Author Name = {author.FirstName} {author.LastName}");
			//	foreach (var book in author.AuthorBooks)
			//	{
			//		Console.WriteLine($"\t{book.Title}");
			//	}
			//	Console.WriteLine("====================================================");
			//}


			//var authors = dbContext.Authors.Select(a => new
			//                                       	{
			//                                       		Name = a.FirstName + " " + a.LastName,
			//                                       		Books = a.AuthorBooks.Select(b => b.Title)
			//                                       	}).ToList();

			//foreach (var a in authors)
			//{
			//	Console.WriteLine($"Author Name = {a.Name}");
			//	foreach (var title in a.Books)
			//		Console.WriteLine($"\t{title}");
			//	Console.WriteLine("====================================================");
			//}

			#endregion

			#region Member with id 1 Want To Borrow The Book With Id 2 And He Will Return it After 5 Days 

			//int MemberId = 1;
			//int BookId = 2;
			//int BorrowDays = 5;

			//bool Done = LoanManagement.BorrowingBook(MemberId, BookId, BorrowDays, dbContext);

			//if (Done)
			//{
			//	Console.WriteLine($"Member {MemberId} successfully borrowed Book {BookId} for {BorrowDays} days");
			//}
			//else
			//{
			//	Console.WriteLine("Borrowing failed. Check member status, book availability");
			//}

			#endregion

			#region After 10 Days Member with id 1 Returned The Book
			//int MemberId = 10;
			//int BookId = 2;

			//bool Returned = LoanManagement.ReturnBook(MemberId, BookId, dbContext);
			//if (Returned)
			//{
			//	Console.WriteLine("Book returned successfully.");
			//}
			//else
			//{
			//	Console.WriteLine("Return failed. Maybe already returned or no matching loan");
			//}

			#endregion

			#region Retrieve all members who currently have active loans 

			//var membersWithActiveLoans = dbContext.Members
			// .Where(m => dbContext.MemberLoans.Any(ml => ml.MemberId == m.Id && ml.ReturnDate == null))
			// .ToList();

			//foreach (var item in membersWithActiveLoans)
			//	Console.WriteLine(item.Name);

			#endregion

			#endregion
		}
	}
}
