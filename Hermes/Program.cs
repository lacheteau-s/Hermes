using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			var app = new App();
			var window = new MainWindow();

			app.Run(window);
		}
	}
}
