using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRS.Models
{

    [Table("Hotels")]
    public class Hotels
    {
        [Key]
        [ScaffoldColumn(true)]
        public Int64 HotelID { get; set; }
        [Display(Name = "Hotel Name")]
        public string HotelName { get; set; }
    }
}