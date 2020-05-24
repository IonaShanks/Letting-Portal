using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Letting_Portal.Models
{
    public class RentalContext : IdentityDbContext<ApplicationUser>
    {

            public RentalContext() : base("Rentals")
            {
                Database.SetInitializer(new CreateDatabaseIfNotExists<RentalContext>());
            }

            public static RentalContext Create()
            {
                return new RentalContext();
            }

            public DbSet<Rental> Rental { get; set; }        
    }
}