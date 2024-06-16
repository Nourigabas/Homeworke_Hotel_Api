using Homeworke_Hotel_Api.Models;
using HotelDomin;
using Microsoft.EntityFrameworkCore;
using static Homeworke_Hotel_Api.Models.RoomStatus;

namespace Homeworke_Hotel_Api.Data
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> option) : base(option) { }
        //انشاء الكيانات التي سوف يتم تخزينها في 
        //DataBase
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<RoomType> RoomType { get; set; }


        //وضع بعض الخواص لتخزين البيانات 
        //كعلاقات 
        //شروط
        //مفاتيح 
        //تحويل قيمة status الى int
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                        .HasOne(b => b.Room)
                        .WithMany(r => r.Bookings)
                        .HasForeignKey(b => b.RoomId)
                        .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Booking>()
                        .HasOne(b => b.Guest)
                        .WithMany(g => g.Bookings)
                        .HasForeignKey(g => g.GuestId)
                        .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Room>()
                        .Property(r => r.Status)
                        .HasConversion<int>();

            modelBuilder.Entity<Room>()
                        .Property(r => r.Status)
                        .IsRequired();
            modelBuilder.Entity<Hotel>().HasData(new Hotel
            {
                Id = 1,
                Name = "5 star",
                Email="noury@aboalnour",
                Phone = "00352681609145",
                Address = "syria-idleb",
            });
            modelBuilder.Entity<RoomType>().HasData(new RoomType
            {
                Id=1,
                TypeName="anything",
                NumOfBeds=5
            });
            modelBuilder.Entity<Room>().HasData(new Room
            {
                Id=1,
                Number=1,
                FloorNumber=1,
                Status=(EStatus)1,
                HotelId=1,
                RoomTypeId=1
                
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id=1,
                FirstName="nouri",
                LastName="gabas",
                Title="mager",
                DOB=DateTime.Now,
                Email="anything@gmail.com",
                StartDate= new DateTime(2021, 6, 14),
                HotelId=1
            });
            modelBuilder.Entity<Guest>().HasData(new Guest
            {
                Id=1,
                FirstName = "nouri",
                LastName = "gabas",
                DOB = DateTime.Now,
                Email = "anything@gmail.com",
                Phone="4477889966"
            });
            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                Id=1,
                CheckinAt=DateTime.Now,
                CheckoutAt=DateTime.MaxValue,
                Price=100,
                EmployeeId=1,
                RoomId=1,
                GuestId=1,
            });
            modelBuilder.Entity<Payment>().HasData(new Payment
            {
                Id=1,
                TotalAmount=5,
                CreatedDate=DateTime.Now,
                BookingId=1,
            });

        }
    }
}

