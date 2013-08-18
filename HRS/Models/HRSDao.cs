using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRS.Models
{

    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<RoomTypeModel> RoomTypes { get; set; }
    }

    public class HRSDao
    {
        private UsersContext db = new UsersContext();
        public HRSDao()
        {
        }

        public bool isHotelUserValid(string UserName, string HotelID)
        {

            List<string> users = db.Database.SqlQuery<string>("EXEC hrs_get_hote_user {0},{1}", new Object[] { UserName, HotelID }).ToList();

            if (users != null && users.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public bool isRoomTypeValid(string RoomType, string HotelID)
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