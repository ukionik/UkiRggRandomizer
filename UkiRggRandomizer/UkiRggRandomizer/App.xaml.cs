using GenHTTP.Engine;
using GenHTTP.Modules.IO;
using GenHTTP.Modules.Layouting;
using GenHTTP.Modules.Practices;
using GenHTTP.Modules.Security;
using GenHTTP.Modules.StaticWebsites;
using GenHTTP.Modules.Webservices;
using UkiRggRandomizer.Controller;

namespace UkiRggRandomizer;

public partial class App
{
    public App()
    {
        var tree = ResourceTree.FromDirectory("www/");

        var app = Layout.Create()
            .AddService<TestResource>("test")
            .Add(CorsPolicy.Permissive())
            .Fallback(StaticWebsite.From(tree));

        var host = Host.Create()
            .Handler(app)
            .Defaults()
            .Port(18234)
            .Start();
    }
}