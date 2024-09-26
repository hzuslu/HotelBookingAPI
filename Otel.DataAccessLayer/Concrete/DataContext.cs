using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Otel.EntityLayer.Concrete;

namespace Otel.DataAccessLayer.Concrete
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MessageCategory> MessageCategories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;user=root;password=root;database=oteldb";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Bu satırı eklemeyi unutmayın

            // MessageCategory ve Contact arasındaki ilişki
            modelBuilder.Entity<Contact>()
                .HasOne(c => c.MessageCategory) // Contact'ın bir MessageCategory'ye ait olduğunu belirtin
                .WithMany(cat => cat.Contacts) // Bir MessageCategory'nin birçok Contact'ı olabilir
                .HasForeignKey(c => c.MessageCategoryId); // Yabancı anahtarın adını belirtin
        }



    }
}
