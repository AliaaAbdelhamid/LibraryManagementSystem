using LibraryManagementSystem.Contexts;

namespace LibraryManagementSystem
{
    internal class Program
	{
		static void Main(string[] args)
		{
			using LibraryDbContext dbContext = new LibraryDbContext();

			bool Result = LibraryDbContextSeed.SeedData(dbContext);
			Console.WriteLine(Result ? "Data Seeded Successfully" : "Seeding Failed");
		}
	}
}
