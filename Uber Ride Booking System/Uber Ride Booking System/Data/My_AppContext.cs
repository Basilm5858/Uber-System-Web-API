using Microsoft.EntityFrameworkCore;
using Uber_Ride_Booking_System.Models;

namespace Uber_Ride_Booking_System.Data
{
    public class My_AppContext : DbContext
    {
        public My_AppContext(DbContextOptions<My_AppContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Ride> Rides { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasOne(x => x.Vehicle)
                .WithOne(x => x.Driver)
                .HasForeignKey<Vehicle>(x => x.DriverId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(x => x.DriverRides)
                .WithOne(x => x.Driver)
                .HasForeignKey(x => x.DriverId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(x => x.RiderRides)
                .WithOne(x => x.Rider)
                .HasForeignKey(x => x.RiderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ride>()
                .HasOne(x => x.Driver)
                .WithMany(x => x.DriverRides)
                .HasForeignKey(x => x.DriverId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ride>()
                .HasOne(x => x.Rider)
                .WithMany(x => x.RiderRides)
                .HasForeignKey(x => x.RiderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ride>()
                .HasOne(x => x.Payment)
                .WithOne(x => x.Ride)
                .HasForeignKey<Payment>(x => x.RideId)
               .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Ride>()
               .HasOne(x => x.Rating)
               .WithOne(x => x.Ride)
               .HasForeignKey<Rating>(x => x.RideId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>().Property(x => x.Role).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Phone).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.FullName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();

            modelBuilder.Entity<Vehicle>().Property(x => x.Color).IsRequired();
            modelBuilder.Entity<Vehicle>().Property(x => x.Model).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Vehicle>().Property(x => x.PlateNumber).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Vehicle>().HasIndex(x => x.PlateNumber).IsUnique();


            modelBuilder.Entity<Ride>().Property(x => x.Status).IsRequired();
            modelBuilder.Entity<Ride>().Property(x => x.PickupLocation).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Ride>().Property(x => x.DropOffLocation).IsRequired().HasMaxLength(150);

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Email = "b@gmail.com", FullName = "Basil Mohamed", Password = "123456", Phone = "12345678910", Role = "Admin" });

            modelBuilder.Entity<Vehicle>().HasData(new Vehicle { Id = 1, Color = "red", DriverId = 1, Model = "s3", PlateNumber = "123" });

            modelBuilder.Entity<Ride>().HasData(new Ride { Id = 1, DriverId = 1, Status = "Pending", DropOffLocation = "test", Fare = 1, PickupLocation = "test", RiderId = 1 });

            modelBuilder.Entity<Rating>().HasData(new Rating { Id = 1, Comment = "test", RideId = 1 });

            modelBuilder.Entity<Payment>().HasData(new Payment { Id = 1, Status = "Pending", RideId = 1, Amount = 54, PaymentDate = new DateTime(2026, 2, 4), PaymentMethod = "Cash" });

            base.OnModelCreating(modelBuilder);
        }


    }
}
