using LibraryManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LibraryManagementSystem.Configurations
{
	internal class AuthorConfig : IEntityTypeConfiguration<Author>
	{
		public void Configure(EntityTypeBuilder<Author> builder)
		{
			builder.Property(X => X.FirstName)
				   .HasColumnType("varchar")
				   .HasMaxLength(20);

			builder.Property(X => X.LastName)
				   .HasColumnType("varchar")
				   .HasMaxLength(20);
		}
	}
}
