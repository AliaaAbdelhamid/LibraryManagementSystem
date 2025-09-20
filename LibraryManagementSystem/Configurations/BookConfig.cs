using LibraryManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LibraryManagementSystem.Configurations
{
	internal class BookConfig : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{

			builder.Property(X => X.Title)
				   .HasColumnType("varchar")
				   .HasMaxLength(50);

			builder.Property(X => X.Price)
				  .HasPrecision(6, 2);

			builder.ToTable(Tb =>
			{
				Tb.HasCheckConstraint("PublicationYearCheck", "PublicationYear  BETWEEN 1950 AND YEAR(GETDATE())");
				Tb.HasCheckConstraint("BookAvailableCopiesCheck","AvailableCopies <= TotalCopies");
			});
		}
	}
}
