using GenHTTP.Engine;
using GenHTTP.Modules.IO;
using GenHTTP.Modules.Layouting;
using GenHTTP.Modules.Layouting.Provider;
using GenHTTP.Modules.Practices;
using GenHTTP.Modules.Security;
using GenHTTP.Modules.StaticWebsites;
using GenHTTP.Modules.Webservices;
using Microsoft.Extensions.DependencyInjection;
using UkiRggRandomizer.Configuration;
using UkiRggRandomizer.Controller;
using UkiRggRandomizer.Core;
using UkiRggRandomizer.Service;

namespace UkiRggRandomizer;

public partial class App
{
    public App()
    {
        var diProvider = DIConfiguration.Init();

        var tree = ResourceTree.FromDirectory("www/");

        var app = Layout.Create()
            .AddController<TestResource>(diProvider)
            .Add(CorsPolicy.Permissive())
            .Fallback(StaticWebsite.From(tree));

        Host.Create()
            .Handler(app)
            .Defaults()
            .Port(18234)
            .Start();
    }

}