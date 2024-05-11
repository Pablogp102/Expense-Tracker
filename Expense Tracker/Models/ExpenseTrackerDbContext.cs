using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Models
{
    public class ExpenseTrackerDbContext : DbContext
    {
        public ExpenseTrackerDbContext(DbContextOptions<ExpenseTrackerDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Transaction
            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.TransactionId);  

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Note)
                .HasMaxLength(75)
                .HasDefaultValueSql("NULL");

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Date)
                .HasDefaultValueSql("getdate()"); 

            // Category
            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryId);

            modelBuilder.Entity<Category>()
                .Property(c => c.Title)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(c => c.Icon)
                .HasMaxLength(50); 

            modelBuilder.Entity<Category>()
                .Property(c => c.Type)
                .HasMaxLength(50);
            
        }
    }
}