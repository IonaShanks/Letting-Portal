namespace Letting_Portal.Migrations
{
    using Letting_Portal.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Letting_Portal.Models.RentalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Letting_Portal.Models.RentalContext";
        }

        protected override void Seed(Letting_Portal.Models.RentalContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Rental.AddOrUpdate(
              p => p.RentalID,
              new Rental { RentalID = "12345a", Title = "2 Bedroom Flat Edinburgh", Address = "123 Street", Town = "Edinburgh", Postcode = "EH1 4RS", Region = "Lothian", Description = "2 Bedroom 1 Bathroom flat in central Edinburgh Well-presented and recently decorated, bright and spacious, two-bedroom, ground-floor flat with a well-maintained communal rear garden. \n Well - presented, furnished, just redecorated, bright and spacious, two - bedroom, ground - floor flat with a well - maintained communal rear garden, north - east of the city centre. Light and well - maintained, the accommodation is entered via the entrance hallway providing access to all main rooms, featuring a built -in cupboard and entryphone.Spacious open plan living room and kitchen.The kitchen features laminate worktops, incorporating a stainless - steel sink and drainer, splash back tiling, and vinyl flooring, with appliances including a gas hob and oven, washing machine and fridge / freezer.There is a generously - sized, carpeted double bedroom set to the rear of the property with ample space for freestanding bedroom furniture. Good sized second bedroom to the front of the property. \n Fully tiled bathroom with Shower and WC. With views to the front of the Hibernian Football Club Stadium, the property features, gas central heating, TV and telephone points, a secure entry system, and good integrated storage provision.Externally, the property benefits from a communal rear garden, as well as ample, unrestricted on - street parking to the front and on surrounding streets.", PhoneNumber = "01315485858", Email = "email@email.com", Bedroom = 2, Bathroom = 1, PricePerMonth = 500.00, Shower = true, SecureEntry = true, Pets = true, Smoking = true, EnSuite = false, Dishwasher = true, Alarm = true, Furnished = true},
              new Rental { RentalID = "23456a", Title = "1 Bedroom Flat Glasgow", Address = "457 Road", Town = "Glasgow", Postcode = "G1 1HF", Region = "Glasgow", Description = "Well presented FURNISHED ground floor 1 bedroom flat (property faces out to the back of the building). \n The property compromises of a large living room / kitchen,double bedroom, bathroom with a shower over bath and large box room / cupboard. Further benefits to the property are free on street parking, double glazing, gas central heating and access to a private communal garden. \n This property is in a great location with local shops and bars nearby and multiple bus routes.", PhoneNumber = "01415487878", Email = "email @email.com", Bedroom = 1, Bathroom = 1, PricePerMonth = 750.00, Shower = true, SecureEntry = true, Pets = false, Smoking = false, EnSuite = false, Dishwasher = false, Alarm = false, Furnished = true},
              new Rental { RentalID = "34567a", Title = "5 Bedroom House Fife", Address = "3 Place", Town = "Kinghorn", Postcode = "KY3 4SD", Region = "Fife", Description = "5 Bedroom House for rent in the lovely town of Kinghorn. \n This house comes unfurnished with a large garden to the rear and a small front garden. The property also has a driveway and a garage. \n The town of Kinghorn has views over the Firth of Forth to Edinburgh.", PhoneNumber = "01592584789", Email = "email@email.com", Bedroom = 5, Bathroom = 3, PricePerMonth = 1000.00, Shower = true, SecureEntry = true, Pets = true, Smoking = false, EnSuite = true, Dishwasher = true, Alarm = true, Furnished = false }
            );

        }
    }
}
