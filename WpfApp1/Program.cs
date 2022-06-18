using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			try
			{
				var app = new App();
				var window = new MainWindow();

				app.Run(window);
			}
			catch (Exception e)
			{

			}
		}
	}
}
