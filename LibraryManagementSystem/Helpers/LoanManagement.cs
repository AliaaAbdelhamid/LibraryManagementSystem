using LibraryManagementSystem.Contexts;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Helpers
{
	internal static class LoanManagement
	{
		public static bool BorrowingBook(int MemberId, int BookId, int BorrowDays, LibraryDbContext dbContext)
		{
			try
			{
				var Member = dbContext.Members.Find(MemberId);
				if (Member is null || Member.Status == MemberStatus.Suspended) return false;

				var Book = dbContext.Books.Find(BookId);
				if (Book is null || Book.AvailableCopies == 0) return false;
				var Loan = new Loan();

				dbContext.Loans.Add(Loan);
				var memberLoan = new MemberLoans()
				{
					Loan = Loan, MemberId = MemberId, BookId = BookId,
					DueDate = DateTime.Now.AddDays(BorrowDays)
				};
				dbContext.MemberLoans.Add(memberLoan);
				Book.AvailableCopies -= 1;
				dbContext.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}

		}

		public static bool ReturnBook(int memberId, int bookId, LibraryDbContext dbContext)
		{
			try
			{
				var memberLoan = dbContext.MemberLoans
										  .Include(ml => ml.Loan)
										  .Include(ml => ml.Book)
										  .Include(ml => ml.Member)
										  .FirstOrDefault(ml => ml.MemberId == memberId && ml.BookId == bookId && ml.ReturnDate == null);
				if (memberLoan is null) return false;
				
				var Book = memberLoan.Book;
				var Member = memberLoan.Member;
				var Loan = memberLoan.Loan;
				memberLoan.ReturnDate = DateTime.Now;
				Book.AvailableCopies += 1;

				if (memberLoan.ReturnDate.Value.Date > memberLoan.DueDate.Date)
				{
					var overdueDays = (memberLoan.ReturnDate.Value - memberLoan.DueDate).Days;
					decimal dailyFine = 0.1M * Book.Price;
					var Fine = new Fine() { Amount = overdueDays * dailyFine, Loan = Loan };
					dbContext.Fines.Add(Fine);
					Member.Status = MemberStatus.Suspended;
					Loan.Status = LoanStatus.Overdue;
				}
				else
				{
					Loan.Status = LoanStatus.Returned;
				}

				dbContext.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
