using ISP.Presentation.Forms;

using System;
using System.Windows.Forms;

namespace ISP
{
	internal sealed class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
		}
		
	}
}
