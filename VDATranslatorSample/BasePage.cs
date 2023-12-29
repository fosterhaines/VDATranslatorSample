using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic;

namespace WebApplication
{
    public class BasePage : System.Web.UI.Page
    {
        public string userName = string.Empty;

        protected override void OnLoad(EventArgs e)
        {

			
            base.OnLoad(e);
        }

   

       

        public int ToInt32(bool value)
        {
	        int returnValue = 0;
	        returnValue = Convert.ToInt32(value);

            return returnValue;
        }

        public bool ToBoolean(int value)
        {
	        bool returnValue = false;
	        returnValue = Convert.ToBoolean(value);

            return returnValue;
        }

        public string NullToBoolean(string value)
        {
	        string returnvalue = null;
	        if (string.IsNullOrEmpty(value.Trim()) | value == "Null") {
		        returnvalue = "False";
	        } else {
		        returnvalue = value;
	        }
	        return returnvalue;
        }

        public decimal NullToZero(string value)
        {
	        decimal returnvalue = default(decimal);
	        if (string.IsNullOrEmpty(value.Trim()) | value == "Null") {
		        returnvalue = 0;
	        } else {
		        returnvalue = Convert.ToDecimal(value);
	        }
	        return returnvalue;
        }

        public object IsNullString(string value)
        {
	        object returnvalue = null;
	        if (string.IsNullOrEmpty(value.Trim())) {
		        returnvalue = DBNull.Value;
	        } else {
		        returnvalue = value;
	        }
	        return returnvalue;
        }

        public bool MatchString(string str, string regexstr)
        {
	        str = str.Trim();
	        System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex(regexstr);
	        return pattern.IsMatch(str);
        }

        public bool IsValidPhone(string phone)
        {
	        if (phone == string.Empty) {
		        return true;
	        } else {
		        return (System.Text.RegularExpressions.Regex.IsMatch(phone, "^[01]?[- .]?(\\([2-9]\\d{2}\\)|[2-9]\\d{2})[- .]?\\d{3}[- .]?\\d{4}$"));
	        }
        }

        public bool IsValidZipCode(string zipcode)
        {
	        if (zipcode == string.Empty) {
		        return true;
	        } else {
		        string regExPattern = "^(\\d{5}-\\d{4}|\\d{5}|\\d{9})$|^([a-zA-Z]\\d[a-zA-Z] \\d[a-zA-Z]\\d)$";
		        return MatchString(zipcode, regExPattern);
	        }
        }

        public bool IsValidUSADate(string dt)
        {
	        DateTime dtnow = default(DateTime);
	        if (DateTime.TryParse(dt.Trim(), out dtnow) | dt == string.Empty) {
		        return true;
	        } else {
		        return false;
	        }
        }


    }
}