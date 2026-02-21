using Microsoft.EntityFrameworkCore;
using SiteManagementApp.Entities.Concrete;

namespace SiteManagementApp.DataAccess.Concrete
{
    public class SiteManagementDbContext : DbContext
    {
        public SiteManagementDbContext(DbContextOptions<SiteManagementDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invoice>()
                .Property(i=>i.Amount)
                .HasPrecision(18,2);

            modelBuilder.Entity<Payment>()
                .Property(i=>i.Amount)
                .HasPrecision(18,2);

            modelBuilder.Entity<Message>()
                .HasOne(m=>m.Sender)
                .WithMany(u=>u.SentMessages)
                .HasForeignKey(m=>m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m=>m.Receiver)
                .WithMany(u=>u.ReceivedMessages)
                .HasForeignKey(m=>m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
