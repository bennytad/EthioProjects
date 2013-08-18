using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRS.Models
{
    public class RoomTypeValidator : ValidationAttribute
    {
        //we want to validate that such a username exists
        //in this hotel
        public override bool IsValid(object value)
        {
            RoomTypeModel room_type_model = (RoomTypeModel)value;
            HRSDao dao = new HRSDao();
            return dao.isRoomTypeValid(room_type_model.RoomType, room_type_model.HotelID);
        }

        //since we don't want to display why the model validation failed (i.e.
        //somethign like "Model validation failed blah blah", we want to return
        //an empty string as an error message to the user
        public override string FormatErrorMessage(string name)
        {
            return "";
        }
    }
}