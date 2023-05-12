using Microsoft.EntityFrameworkCore;
using PracticalExam.Database_Models;

namespace PracticalExam.Database_Context
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> db) : base(db)
        {
            // Create the database if it doesn't exist
            Database.EnsureCreated();
        }


        // Create Table
        public DbSet<Book> tblBook => Set<Book>();



        // Connection with the SQL SERVER
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=BookDb;Trusted_Connection=True");
        }


        // Seed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(

                new Book
                {
                    Id = 1,
                    Date = new DateTime(2022, 1, 1),
                    BookName = "Man and Superman",
                    Author = "G B Shaw",
                    Quantity = 1
                },

                new Book
                {
                    Id = 2,
                    Date = new DateTime(2022, 1, 2),
                    BookName = "The Castle",
                    Author = "Franz Kalka",
                    Quantity = 1
                },

                new Book
                {
                    Id = 3,
                    Date = new DateTime(2022, 1, 3),
                    BookName = "A Woman's Life",
                    Author = "Guy the Manupassaul",
                    Quantity = 1
                },

                new Book
                {
                    Id = 4,
                    Date = new DateTime(2022, 1, 4),
                    BookName = "Bela Obela Kolbela",
                    Author = "Jibanananda Das",
                    Quantity = 1
                },

                new Book
                {
                    Id = 5,
                    Date = new DateTime(2022, 1, 5),
                    BookName = "The Sense of an Ending",
                    Author = "Julian Barnes",
                    Quantity = 1
                }

            );


        }
    }
}
