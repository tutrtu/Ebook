using System;
using System.Collections.Generic;
using EbookAPI.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EbookAPI.Models
{
    public partial class eBookStoreContext : DbContext
    {
        public eBookStoreContext()
        {
        }

        public eBookStoreContext(DbContextOptions<eBookStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookAuthor> BookAuthors { get; set; } = null!;
        public virtual DbSet<Publisher> Publishers { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .HasColumnName("city");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .HasColumnName("email_address");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .HasColumnName("state");

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .HasColumnName("zip");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.Advance)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("advance");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.PubId).HasColumnName("pub_id");

                entity.Property(e => e.PublishedDate)
                    .HasColumnType("date")
                    .HasColumnName("published_date");

                entity.Property(e => e.Royalty)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("royalty");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .HasColumnName("title");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");

                entity.Property(e => e.YtdSales).HasColumnName("ytd_sales");

                entity.HasOne(d => d.Pub)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PubId)
                    .HasConstraintName("FK__Book__pub_id__3B75D760");
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.HasKey(e => new { e.AuthorId, e.BookId })
                    .HasName("PK__BookAuth__82C1BA6113C86B04");

                entity.ToTable("BookAuthor");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.AuthorOrder).HasColumnName("author_order");

                entity.Property(e => e.RoyaltyPercentage)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("royalty_percentage");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookAutho__autho__4316F928");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookAutho__book___440B1D61");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.PubId)
                    .HasName("PK__Publishe__2515F222F046AB23");

                entity.ToTable("Publisher");

                entity.Property(e => e.PubId).HasColumnName("pub_id");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.PublisherName)
                    .HasMaxLength(100)
                    .HasColumnName("publisher_name");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .HasColumnName("state");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleDesc)
                    .HasMaxLength(100)
                    .HasColumnName("role_desc");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .HasColumnName("email_address");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hire_date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .HasColumnName("middle_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .HasColumnName("password");

                entity.Property(e => e.PubId).HasColumnName("pub_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Source)
                    .HasMaxLength(100)
                    .HasColumnName("source");

                entity.HasOne(d => d.Pub)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PubId)
                    .HasConstraintName("FK__User__pub_id__4AB81AF0");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__User__role_id__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
