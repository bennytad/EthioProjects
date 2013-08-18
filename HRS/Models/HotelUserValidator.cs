using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRS.Models
{
    public class HotelUserValidator : ValidationAttribute
    {
        //we want to validate that such a username exists
        //in this hotel
        public override bool IsValid(object value)
        {
            LoginModel login_model = (LoginModel)value;
            HRSDao dao = new HRSDao();
            return dao.isHotelUserValid(login_model.UserName, login_model.HotelID);
        }

        //since we don't want to display why the model validation failed (i.e.
        //somethign like "LoginModel validation failed blah blah", we want to return
        //an empty string as an error message to the user
        public override string FormatErrorMessage(string name)
        {
            return "";
        }
    }
}