using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRS.Models
{
    [Table("RoomType")]
    public class RoomTypeModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RoomTypeID { get; set; }
        [Display(Name = "Hotel ID")]
        public string HotelID { get; set; }
        [Display(Name = "Room Type")]
        public string RoomType { get; set; }
        [Display(Name = "Room Description")]
        public string RoomDescription { get; set; }
    }
}