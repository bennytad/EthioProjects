using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRS.Models
{
    [Table("Rooms")]
    public class Rooms
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RoomID { get; set; }
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }
        [Display(Name = "Hotel ID")]
        public string HotelID { get; set; }
        [Display(Name = "Room Type")]
        public string RoomType { get; set; }
        [Display(Name = "Floor Number")]
        public string FloorNumber { get; set; }
    }

    [Table("RoomSchedules")]
    public class RoomSchedules
    {
        public int RoomID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int status { get; set; } //0 - checked-out, 1 - booked , 2 - checked-in
    }

    public class RoomDetailModel
    {

    }
}