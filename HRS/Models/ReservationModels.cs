using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRS.Models
{
    [Table("Reservations")]
    public class Reservation
    {
        [Key]
        public Int64 reservation_id { get; set; }
        [Display(Name = "Start Date")]
        public string start_date { get; set; }
        [Display(Name = "End Date")]
        public string end_date { get; set; }
        [Display(Name = "Room ID")]
        [ForeignKey("Rooms")]
        public Int64 room_id { get; set; }
        [Display(Name = "Hotel ID")]
        public Int64 HotelID { get; set; }
        [Display(Name = "Status")]
        public int reservation_status { get; set; }

       // public virtual Hotels Hotels { get; set; }
        public virtual Rooms Rooms { get; set; }
    }
}