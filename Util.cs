using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
namespace AppWrapper
{
    public static class Util
    {
        /// <summary>
        /// Returns string from front of "name - nbr"
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
        const string eol = "\r\n";
        public static void LogError(Exception ex, bool showMsgBox, string moduleAndMethod)
        {
            try
            {
                string msg = $"Error Message from {moduleAndMethod}: " +
                            ex.Message + eol +
                           "Error Type: " + ex.GetType().ToString() + eol +
                           "Error Details: " + eol + ex.ToString();
                if (showMsgBox)
                    MessageBox.Show(msg, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                try
                {
                    StackTrace st = new StackTrace(true);
                    msg += "Stack Trace: " + eol + st.ToString();
                }
                catch (Exception)
                {
                }

                WriteErrorLog(new StringBuilder(msg));
            }
            catch (Exception)
            {
            }
        }

        public static void LogError(string err, bool showMsgBox, string moduleAndMethod)
        {
            string msg = $"Error Message from {moduleAndMethod}: " + err + eol;
            if (showMsgBox)
                MessageBox.Show(msg, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            WriteErrorLog(new StringBuilder(msg));
        }

        private static Tuple<string, string> SplitModuleFromMethod(string moduleAndMethod)
        {
            string[] s = moduleAndMethod.Split('.');
            return Tuple.Create(s[0], s.Length > 1 ? s[1] : string.Empty);
        }

        private static void WriteErrorLog(StringBuilder sb)
        {
            string fn = GetErrorFilename();
            if (fn == null) return;
            File.WriteAllText(fn, sb.ToString());
        }
        private static string GetErrorFilename()
        {
            try
            {
                string AppPath = Path.Combine(GetExePath(), "ErrLogs");
                var di = new DirectoryInfo(AppPath);
                if (!di.Exists)
                    di.Create();
                return AppPath + @"\ErrLog_" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".txt";
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static string GetExePath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }
}
