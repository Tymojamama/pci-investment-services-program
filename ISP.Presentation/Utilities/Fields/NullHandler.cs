using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISP.Presentation.Utilities
{
    public partial class Fields
    {
        public static string NullHandler(object obj)
        {
            if (obj == null || String.IsNullOrWhiteSpace(obj.ToString()))
            {
                return "-";
            }

            if (obj is decimal?)
            {
                return ((decimal)obj).ToString("N2");
            }

            return obj.ToString();
        }
    }
}
