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
        public Int64 room_id { get; set; }
        [Display(Name = "Room Number")]
        public string room_number { get; set; }
        [Display(Name = "Hotel ID")]
        [ForeignKey("Hotels")]
        public Int64 HotelID { get; set; }
        [Display(Name = "Room Type")]
        [ForeignKey("RoomTypes")]
        public Int64 room_type_id { get; set; }
        [Display(Name = "Floor Number")]
        public int floor_level { get; set; }
        [Display(Name = "Note")]
        public string note { get; set; }


        public virtual Hotels Hotels { get; set; }
        public virtual RoomTypes RoomTypes { get; set; }
    }

    [Table("RoomSchedules")]
    public class RoomSchedules
    {
        public Int64 RoomID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int status { get; set; } //0 - checked-out, 1 - booked , 2 - checked-in
    }

    [Table("RoomTypes")]
    public class RoomTypes
    {
        [Key]
        public Int64 room_type_id { get; set; }
        [Display(Name = "Room Type")]
        public string room_type_name { get; set; }
        [Display(Name = "Hotel ID")]
        [ForeignKey("Hotels")]
        public Int64 HotelID { get; set; }
        [Display(Name="Description")]
        public string room_description { get; set; }

        public virtual Hotels Hotels { get; set; }
    }
}