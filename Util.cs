using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWrapper
{
    public static class Util
    {
        /// <summary>        /// Returns string from front of "name - nbr"
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetStringFromFrontOfText(string text)
        {
            var ptr = text.IndexOf(" -");
            return ptr < 0 ? string.Empty : text.Substring(0, ptr);
        }

        /// <summary>
        /// Return (int)nbr from front of "nbr - string"
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int GetNbrFromFrontOfText(string text)
        {
            var ptr = text.IndexOf(" -");
            return int.Parse(text.Substring(0, ptr));
        }

        public static string GetStringFromEndOfText(string text)
        {
            var ptr = text.IndexOf("- ") + 2;
            return text.Substring(ptr);
        }

        /// <summary>
        /// Delimeter can only be one character, usually one space
        /// </summary>
        /// <param name="text"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string GetStringFromEndOfText(string text, string delimiter)
        {
            var ptr = text.IndexOf(delimiter) + 1;
            return text.Substring(ptr);
        }

        /// <summary>
        /// Delimeter can only be one character, usually one space
        /// </summary>
        public static string GetStringFromStatOfText(string text, string delimiter)
        {
            return text.Substring(0, text.IndexOf(delimiter));
        }

    }
}
