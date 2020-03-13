using Hermes.ViewModels;
using Hermes.Views;
using Microsoft.Extensions.DependencyInjection;
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
            var serviceProvider = BuildServiceProvider();

            try
            {
                var app = new App();
                var window = serviceProvider.GetService<MainWindow>();

                app.Run(window);
            }
            catch (Exception e)
            {

            }
        }

        private static IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
