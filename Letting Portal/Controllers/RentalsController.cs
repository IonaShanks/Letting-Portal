using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Letting_Portal.Models;
using System.Globalization;
using System.Net.Mail;

namespace Letting_Portal.Controllers
{
    public class RentalsController : Controller
    {
        private RentalContext db = new RentalContext();
        
        public static TextInfo myTI = new CultureInfo("en-IE", false).TextInfo;
        public static string TitleCase(string q)
        {
            q = myTI.ToTitleCase(q);
            return q;
        }

        //For use in view
        private string regionResult = "";
        private string townResult = "";
        private string bedResult = "";
        private string sortResult = "";
        public string SetSearchResult()
        {
            string result = $"You have searched for: {regionResult}{townResult}{bedResult}{sortResult}";
            return result;
        }

        public IQueryable<Rental> SortBy(string sort)
        {
            IQueryable<Rental> rentals = db.Rental;
            //Orders the rental list based on the sort selected from the list.         
            if (sort == "Town (A-Z)")
            {
                rentals = rentals.OrderBy(r => r.Town);
            }
            else if (sort == "Town (Z-A)")
            {
                rentals = rentals.OrderByDescending(k => k.Town);
            }
            else if (sort == "Price per Month (H-L)")
            {
                rentals = rentals.OrderByDescending(k => k.PricePerMonth);
            }
            else /*if (sort == "Price per Month (L-H)")*/
            {
                rentals = rentals.OrderBy(k => k.PricePerMonth);
            }
            sortResult = "Sorted by: " + sort + ". ";
            return rentals;
        }

        public List<Rental> SearchByBeds(string searchBed)
        {
            var rentList = new List<Rental>();
            //Loops through every rental in the database
            foreach (Rental rent in db.Rental)
            {                
                int search = Convert.ToInt32(searchBed);
                //Adds to list if bedrooms >= search
                if (rent.Bedroom >= search)
                {
                    rentList.Add(rent);
                }
                
            }
            bedResult = "Bedrooms: " + searchBed + " and above. ";
            return rentList;
        }

        public List<string> GetRegionList()
        {
            //Creates a list of distinct regions that have rentals in them.
            var RegionList = new List<string>();
            var RegionQry = db.Rental.Select(c => c.Region.ToString());
            RegionList.AddRange(RegionQry.Distinct());
            return RegionList;
        }
        public List<int> GetBedList()
        {
            //Creates a list of bedrooms
            var BedList = new List<int>();
            var Beds = 0;
            if (db.Rental.Max(u => u.Bedroom) != 0)
            {
                Beds = db.Rental.Max(u => u.Bedroom);
                for (int i = 1; i <= Beds; i++)
                {
                    BedList.Add(i);
                }
            }
            else
            {
                BedList.Add(0);
            }
            return BedList;
        }

        public List<string> GetSortList()
        {
            //Select list to sort the table
            var SortList = new List<string>();
            SortList.Add("Town (A-Z)");
            SortList.Add("Town (Z-A)");
            SortList.Add("Price per Month (H-L)");
            SortList.Add("Price per Month (L-H)");
            return SortList;
        }

        // GET: Rentals
        [AllowAnonymous]
        public ActionResult Index(string region, string searchTown, string searchBed, string sort)
        {
            //Creating Select lists for each             
            ViewBag.region = new SelectList(GetRegionList());
            ViewBag.bed = new SelectList(GetBedList());
            ViewBag.sort = new SelectList(GetSortList());

            IQueryable<Rental> rentals = db.Rental;

            //Sort results
            if (!string.IsNullOrEmpty(sort))
            {
                rentals = SortBy(sort);
            }

            //Search by name
            if (!string.IsNullOrEmpty(searchTown))
            {
                //Adds the rentals to the list that include the name searched
                townResult = "Town includes: " + searchTown + ". ";
                rentals = rentals.Where(n => n.Town.Contains(searchTown));
            }

            //Search by region
            if (!string.IsNullOrEmpty(region))
            {
                //Adds the rentals to the list that are in the selected region
                regionResult = "Region: " + region + ". ";
                rentals = rentals.Where(c => c.Region.ToString() == region);
            }

            if (!string.IsNullOrEmpty(searchBed))
            {
                var rentList = new List<Rental>();
                rentList = SearchByBeds(searchBed);
                rentals = rentList.AsQueryable();
            }

            ViewBag.Result = SetSearchResult();
            //Displays the view from all the queries
            return View(rentals);
        }

        // GET: Rentals/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rental.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        //Function to send email 
        public void ContactEmail(string Message, string EmailFrom, string Name, string EmailTo, string id)
        {
            //Making email            
            var message = new MailMessage();
            message.To.Add(new MailAddress(EmailTo));
            message.From = new MailAddress(EmailFrom);
            message.Subject = "Contact Form";
            message.Body = string.Format("<p>RentalID:" + id + "</p><p>From: " + Name + "</p><p>Email: " + EmailFrom + "</p><p>Message: " + Message + "</p>");
            message.IsBodyHtml = true;

            //Sending email
            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                var credential = new NetworkCredential
                {
                    UserName = "IonaKennel@gmail.com",
                    Password = "Tallaght1"
                };
                smtp.Credentials = credential;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
        

        [HttpGet]
        public ActionResult Enquire(string id)
        {
            ViewBag.Message = "Enquire about a property";
            return View();
        }

        [HttpPost]
        public ActionResult Enquire(ContactViewModel vm, string id)
        {
            ViewBag.Message = "Enquire about a property";
            if (ModelState.IsValid)
            {
                try
                {
                    //Fills the function paramaters based on what the user inputs in the form
                    String Message = vm.Message;
                    String EmailFrom = vm.EmailFrom;
                    String Name = vm.Name;
                    String EmailTo = "ionakennel@gmail.com";  //throw away email from another project     
                    String RentalID = id;
                    //Calls the function to send the email 
                    ContactEmail(Message, EmailFrom, Name, EmailTo, RentalID);
                    ViewBag.Success = "Thank you for getting in contact, your message has been sent!";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    TempData["Error"] = $" Sorry we are facing Problem here {ex.Message}";
                }
            }
            else
            {
                ModelState.AddModelError("", "ModelState not valid");
                return View(vm);
            }
                       
            return View();
        }
    }
}

