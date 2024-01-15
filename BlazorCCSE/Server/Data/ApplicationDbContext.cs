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
                    id = Guid.Parse("96d87c6f-6b19-4813-90b8-9dec2003012b"),
                    name = "Hilton London Hotel",
                    singlePrice = 375,
                    doublePrice = 775,
                    familyPrice = 950
                },
                new Hotel
                {
                    id = Guid.Parse("c1bd291c-66c7-4938-a786-e72ef6a749fb"),
                    name = "London Marriott Hotel",
                    singlePrice = 300,
                    doublePrice = 500,
                    familyPrice = 900
                },
                new Hotel
                {
                    id = Guid.Parse("a58f83f1-3efa-40f8-9bf4-a3a8dfc8e46a"),
                    name = "Travelodge Brighton Seafront",
                    singlePrice = 80,
                    doublePrice = 120,
                    familyPrice = 150
                },
                new Hotel
                {
                    id = Guid.Parse("a0f09f74-e316-4b3a-99cc-b504b779a309"),
                    name = "Kings Hotel Brighton",
                    singlePrice = 180,
                    doublePrice = 400,
                    familyPrice = 520
                },
                new Hotel
                {
                    id = Guid.Parse("60de2b64-fb96-4c98-8b16-9d7ac88dad49"),
                    name = "Leonardo Hotel Brighton",
                    singlePrice = 180,
                    doublePrice = 400,
                    familyPrice = 520
                },
                new Hotel
                {
                    id = Guid.Parse("48c30553-be75-4692-b47d-045875039dc2"),
                    name = "Nevis Bank Inn, Fort William",
                    singlePrice = 90,
                    doublePrice = 100,
                    familyPrice = 155
                }
                );
            builder.Entity<Tour>().HasData(
                new Tour
                {
                    id = Guid.Parse("fac3ae2a-fcf7-4442-b5d2-d358d3daf62b"),
                    name = "Real Britan",
                    length = 6,
                    cost = 1200,
                    spaces = 30
                },
                new Tour
                {
                    id = Guid.Parse("ab75ecd5-358c-45ca-b138-8e7a431993a8"),
                    name = "Britain and Ireland Explorer",
                    length = 16,
                    cost = 2000,
                    spaces = 40,
                },
                new Tour
                {
                    id = Guid.Parse("8d3cf0e3-8a06-4de3-8cf6-13165fbdfa58"),
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
        public DbSet<PackageBooking> PackaegBookings { get; set; }

        public DbSet<Tour> Tours { get; set; }
    }
}
