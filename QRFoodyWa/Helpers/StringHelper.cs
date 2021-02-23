using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRFoodyWa.Helpers
{
    public static class StringHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpaceAny(params string[] strs)
        {
            if (strs == null)
                return true;

            foreach (string s in strs)
                if (string.IsNullOrWhiteSpace(s))
                    return true;

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEqualsIgnoreCase(string value, string str)
        {
            return IsEqualsIgnoreCaseAny(value, str);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static bool IsEqualsIgnoreCaseAny(string value, params string[] strs)
        {
            if (strs == null)
                return true;

            foreach (string s in strs)
                if (string.Equals(s, value, StringComparison.InvariantCultureIgnoreCase))
                    return true;

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static bool IsIntegerAny(params string[] strs)
        {
            if (strs == null)
                return false;

            foreach (string s in strs)
                if (!string.IsNullOrWhiteSpace(s) && s.IsInteger())
                    return true;

            return false;
        }

        #region Extension methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsInteger(this string s)
        {
            int output;
            return Int32.TryParse(s, out output);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsLong(this string s)
        {
            long output;
            return Int64.TryParse(s, out output);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return false;

            foreach (var c in s)
                if (c != '0' && c != '1' && c != '2' &&
                    c != '3' && c != '4' && c != '5' &&
                    c != '6' && c != '7' && c != '8' &&
                    c != '9')
                    return false;

            return true;
        }

        #endregion
    }
}
