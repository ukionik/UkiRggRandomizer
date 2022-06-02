using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using GenHTTP.Engine;
using GenHTTP.Modules.IO;
using GenHTTP.Modules.Practices;
using GenHTTP.Modules.StaticWebsites;

namespace UkiRggRandomizer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var tree = ResourceTree.FromDirectory("www/");
            var app = StaticWebsite.From(tree);
            
            var host = Host.Create()
                .Handler(app)
                .Defaults()
                .Port(18234)
                .Start();
            
            
        }
    }
}