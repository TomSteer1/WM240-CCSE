using BlazorCCSE.Server.Models;
using BlazorCCSE.Shared;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorCCSE.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Hotel>().HasData(
                new Hotel
                {
                    name = "Hilton London Hotel",
                    singlePrice = 375,
                    doublePrice = 775,
                    familyPrice = 950
                },
                new Hotel
                {
                    name = "London Marriott Hotel",
                    singlePrice = 300,
                    doublePrice = 500,
                    familyPrice = 900
                },
                new Hotel
                {
                    name = "Travelodge Brighton Seafront",
                    singlePrice = 80,
                    doublePrice = 120,
                    familyPrice = 150
                },
                new Hotel
                {
                    name = "Kings Hotel Brighton",
                    singlePrice = 180,
                    doublePrice = 400,
                    familyPrice = 520
                },
                new Hotel
                {
                    name = "Leonardo Hotel Brighton",
                    singlePrice = 180,
                    doublePrice = 400,
                    familyPrice = 520
                },
                new Hotel
                {
                    name = "Nevis Bank Inn, Fort William",
                    singlePrice = 90,
                    doublePrice = 100,
                    familyPrice = 155
                }
                );
            builder.Entity<Tour>().HasData(
                new Tour
                {
                    name = "Real Britan",
                    length = 6,
                    cost = 1200,
                    spaces = 30
                },
                new Tour
                {
                    name = "Britain and Ireland Explorer",
                    length = 16,
                    cost = 2000,
                    spaces = 40,
                },
                new Tour
                {
                    name = "Best of Britain",
                    length = 12,
                    cost = 2900,
                    spaces = 30
                }
                );

                var customer = new IdentityRole("customer");
                customer.NormalizedName = "Customer";
                var admin = new IdentityRole("admin");
                admin.NormalizedName = "Admin";

                

                builder.Entity<IdentityRole>().HasData(customer, admin);
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelBooking> HotelBookings { get; set; }
        public DbSet<TourBooking> TourBookings { get; set; }
        public DbSet<PackageBooking> PackageBookings { get; set; }

        public DbSet<Tour> Tours { get; set; }
    }
}
