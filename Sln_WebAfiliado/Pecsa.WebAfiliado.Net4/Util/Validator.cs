using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IU.WebCondominios.Net4.Util
{
    public class Validator
    {

      

      
        public static bool IsNull(Object obj)
        {
            if ((obj == null))
            {
                return true;
            }
            return false;
        }

        public static bool IsEmpty(Object obj)
        {
            if ((obj == null) || (obj.ToString().Trim().Length == 0))
            {
                return true;
            }
            return false;
        }

        public static String Cstr(Object xobjObject)
        {
            if (xobjObject == null || xobjObject == DBNull.Value) return "";
            else return (string)xobjObject.ToString() == "&nbsp;" ? "" : xobjObject.ToString();
        }

        public static Int32 CInt32(Object xobjObject)
        {
            Int32 result;
            if (xobjObject == null || !Int32.TryParse(xobjObject.ToString(), out result) || xobjObject == DBNull.Value || xobjObject.ToString() == "")
                return 0;
            else return Convert.ToInt32(xobjObject);
        }

        public static Int64 CInt64(Object xobjObject)
        {
            Int64 result;
            if (xobjObject == null || !Int64.TryParse(xobjObject.ToString(), out result) || xobjObject == DBNull.Value || xobjObject.ToString() == "")
                return 0;
            else return (Int64)xobjObject;
        }

        public static DateTime CDate(Object xobjObject)
        {
            DateTime result;
            if (xobjObject == null || !DateTime.TryParse(xobjObject.ToString(), out result) || xobjObject == DBNull.Value || xobjObject.ToString() == "")
                throw new Exception("Fecha invalida");
            else return Convert.ToDateTime(xobjObject);
        }

        public static double CDbl(Object xobjObject)
        {
            double result;
            if (xobjObject == null || !double.TryParse(xobjObject.ToString(), out result) || xobjObject == DBNull.Value || xobjObject.ToString() == "")
                return 0;
            else return Convert.ToDouble(xobjObject);
        }

        public static decimal CDcml(Object xobjObject)
        {
            decimal result;
            if (xobjObject == null || !decimal.TryParse(xobjObject.ToString(), out result) || xobjObject == DBNull.Value || xobjObject.ToString() == "")
                return 0;
            else return Convert.ToDecimal(xobjObject);
        }

        public static bool CBool(object xobjObject)
        {
            if (xobjObject == DBNull.Value)
                return false;
            else
                try
                {
                    if (xobjObject.Equals("1") || xobjObject.ToString().ToUpper().Equals("TRUE")) return true;
                    if (xobjObject.Equals("0") || xobjObject.ToString().ToUpper().Equals("FALSE")) return false;
                    return (bool)xobjObject;
                }
                catch (Exception)
                {
                    return false;
                }
        }
    }
}