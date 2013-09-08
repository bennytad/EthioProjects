using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRS.Models
{

    public class DefaultDBContext : DbContext
    {
        public DefaultDBContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<RoomTypes> RoomTypes { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }

        public DbSet<Hotels> Hotels { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
    }

    public class HRSDao
    {
        private DefaultDBContext db = new DefaultDBContext();
        public HRSDao()
        {
        }

        public bool isHotelUserValid(string UserName, Int64 HotelID)
        {

            List<string> users = db.Database.SqlQuery<string>("EXEC hrs_get_hotel_user {0},{1}", new Object[] { UserName, HotelID }).ToList();

            if (users != null && users.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public bool isRoomTypeValid(Int64 RoomType, Int64 HotelID)
        {
            List<int> validation = db.Database.SqlQuery<int>("EXEC hrs_validate_new_room_type {0},{1}", new Object[] { RoomType, HotelID }).ToList();

            if (validation != null && validation[0] == 1)
            {
                return true;
            }
            return false;
        }
    }
}