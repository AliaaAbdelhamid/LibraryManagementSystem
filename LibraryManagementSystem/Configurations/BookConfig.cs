using LibraryManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LibraryManagementSystem.Configurations
{
	internal class BookConfig : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{

			#region Properties Configurations
			builder.Property(X => X.Title)
					   .HasColumnType("varchar")
					   .HasMaxLength(50);

			builder.Property(X => X.Price)
				  .HasPrecision(6, 2);

			builder.ToTable(Tb =>
			{
				Tb.HasCheckConstraint("PublicationYearCheck", "PublicationYear  BETWEEN 1950 AND YEAR(GETDATE())");
				Tb.HasCheckConstraint("BookAvailableCopiesCheck", "AvailableCopies <= TotalCopies");
			});
			#endregion

			#region Relationship Configurations 

			#region Assigned Relationship
			builder.HasOne(X => X.BookAuthor)
					   .WithMany(X => X.AuthorBooks)
					   .HasForeignKey(X => X.AuthorId);

			builder.HasIndex(X => X.AuthorId);
			#endregion

			#region Classified Relationship

			builder.HasOne(X => X.BookCategory)
				.WithMany(X => X.CategoryBooks)
				.HasForeignKey(X => X.CategoryId); 

			#endregion

			#endregion
		}
	}
}
