using BookingApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

public class BookingContext : DbContext

{

    public BookingContext(DbContextOptions<BookingContext> options)

    : base(options)

    { }

    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<BarberShop> BarberShops { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet <Review> Reviews { get; set; } 
}