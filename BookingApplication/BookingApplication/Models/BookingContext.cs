using BookingApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
public class BookingContext : IdentityDbContext<IdentityUser>

{
    public BookingContext(DbContextOptions<BookingContext> options)

    : base(options)

    { }

    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Barbershop> Barbershops { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet <Review> Reviews { get; set; }
    public DbSet<Hotel> Hotels{ get; set; }
    public DbSet<Contact> ContactMessages { get; set; }
    public IEnumerable<object> Contact { get; internal set; }
    public DbSet<BarbershopReservation> BarbershopReservations { get; set; }
    public DbSet<CinemaReservation> CinemaReservations { get; set; }
    public DbSet<RestaurantReservation> RestaurantReservations { get; set; }
    public DbSet<HotelReservation> HotelReservations { get; set; }

}