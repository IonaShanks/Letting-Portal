using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Letting_Portal.Models
{

        public class Rental
        {
            [Key, MaxLength(6, ErrorMessage = "{0} must be between 1 and 6 characters."), Display(Name = "Rental ID")]
            public String RentalID { get; set; }

            [Required]
            public String Title { get; set; }

            [Required]
            public String Address { get; set; }

            [Required, Display(Name = "Town/City")]
            public String Town { get; set; }

            [Required]
            public String Postcode { get; set; }

            [Required]
            public String Region { get; set; }

            [Required]
            public String Description { get; set; }

            [Required, Display(Name = "Phone Number")]
            public String PhoneNumber { get; set; }

            [Required, Display(Name = "Email")]
            public String Email { get; set; }

            [Required, Display(Name = "Bedrooms")]
            public int Bedroom { get; set; }

            [Required, Range(1, Int32.MaxValue, ErrorMessage = "{0} must be greater than 0."), Display(Name = "Bathrooms")]
            public int Bathroom { get; set; }

            [DisplayFormat(DataFormatString = "{0:C}"), Required, Display(Name = "Price per Month"), Range(0.01, Int32.MaxValue, ErrorMessage = "{0} must be greater than 0.")]
            public double PricePerMonth { get; set; }

            [Required]
            public bool Shower { get; set; }

            [Required, Display(Name = "Secure Entry")]
            public bool SecureEntry { get; set; }

            [Required]
            public bool Pets { get; set; }

            [Required]
            public bool Smoking { get; set; }

            [Required, Display(Name = "En-Suite")]
            public bool EnSuite { get; set; }

            [Required]
            public bool Dishwasher { get; set; }

            [Required, Display(Name = "Burglar Alarm")]
            public bool Alarm { get; set; }

            [Required]
            public bool Furnished { get; set; }

            public ApplicationUser User { get; set; }
            public virtual ApplicationUser ApplicationUser { get; set; }

        }
}
