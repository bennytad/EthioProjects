using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRS.Models
{

    [Table("Guest")]
    public class Guest
    {
        [Key, Column(Order = 0), DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int64 guest_id { get; set; }

        [Key, Column(Order = 1), Display(Name = "Hotel ID"), ForeignKey("Hotels")]
        public Int64 HotelID { get; set; }

        [Display(Name = "First Name")]
        public string first_name { get; set; }

        [Display(Name = "Last Name")]
        public string last_name { get; set; }

        [Display(Name = "Street Address")]
        public string street_address { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "Country")]
        public string country { get; set; }

        [Display(Name = "National ID")]
        public string national_id { get; set; }

        [Display(Name = "Nationality")]
        public string nationality { get; set; }

        public virtual Hotels Hotels { get; set; }
    }
}