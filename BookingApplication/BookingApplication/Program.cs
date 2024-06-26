using BookingApplication.Repositories;
using BookingApplication.Repositories.Interfeces;
using BookingApplication.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BookingApplication.Interfaces;
using BookingApplication.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<BookingContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BookingDb")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<BookingContext>();

builder.Services.AddScoped<BarbershopService>();
builder.Services.AddScoped<ContactService>();
builder.Services.AddScoped<BarbershopReservationService>();
builder.Services.AddScoped<CinemaService>();
builder.Services.AddScoped<RestaurantService>();
builder.Services.AddScoped<RestaurantReservationService>();
builder.Services.AddScoped<HotelService>();
builder.Services.AddScoped<ReservationService>();
builder.Services.AddScoped<HotelReservationService>();
builder.Services.AddScoped<CinemaReservationService>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
builder.Services.AddScoped<IBarbershopRepository, BarbershopRepository>();
builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<Microsoft.AspNetCore.Identity.UserManager<IdentityUser>>();
    DbInitializer.Initialize(services, userManager).Wait();
}

app.MapRazorPages();
app.Run();
