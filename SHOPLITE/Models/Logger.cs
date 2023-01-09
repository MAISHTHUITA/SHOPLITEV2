using System;
using System.IO;
using System.Text;

namespace SHOPLITE.Models
{
    public class Logger
    {
        public static void Loggermethod(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            string filepath = AppDomain.CurrentDomain.BaseDirectory + @"\Shoplite-errors" + ".log";
            if (!File.Exists(filepath))
                File.Create(filepath).Dispose();

            do
            {
                sb.Append("Exception Type" + Environment.NewLine);
                sb.Append(ex.GetType().Name + Environment.NewLine);
                sb.Append("Date And Time " + DateTime.Now.ToString() + Environment.NewLine);
                sb.Append(Environment.NewLine);
                sb.Append("Message" + Environment.NewLine);
                sb.Append(ex.Message + Environment.NewLine);
                sb.Append("StackTrace" + Environment.NewLine);
                sb.Append(ex.StackTrace.ToString() + Environment.NewLine + Environment.NewLine);
                ex = ex.InnerException;
            } while (ex != null);

            File.AppendAllText(filepath, sb.ToString());
        }
    }
}
