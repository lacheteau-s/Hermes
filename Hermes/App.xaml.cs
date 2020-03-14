using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Hermes
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ApplySkin();
        }

        private void ApplySkin()
        {
            var uri = new Uri(@".\Resources\Skins\Dark.xaml", UriKind.Relative);
            var skin = LoadComponent(uri) as ResourceDictionary;
            Resources.MergedDictionaries.Add(skin);
        }
    }
}
