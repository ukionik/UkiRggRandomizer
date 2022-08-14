using GenHTTP.Engine;
using GenHTTP.Modules.IO;
using GenHTTP.Modules.Layouting;
using GenHTTP.Modules.Practices;
using GenHTTP.Modules.Security;
using GenHTTP.Modules.StaticWebsites;
using UkiRggRandomizer.Configuration;
using UkiRggRandomizer.Controller;
using UkiRggRandomizer.Core;

namespace UkiRggRandomizer;

public partial class App
{
    public App()
    {
        var diProvider = DIConfiguration.Init();

        var tree = ResourceTree.FromDirectory("www/");

        var resourceTree = ResourceTree.FromDirectory("Resources/");

        var app = Layout.Create()
            .Add("resources", GenHTTP.Modules.IO.Resources.From(resourceTree))
            .AddController<TestResource>(diProvider)
            .AddController<WheelResource>(diProvider)
            .Add(CorsPolicy.Permissive())
            .Fallback(StaticWebsite.From(tree));

        Host.Create()
            .Handler(app)
            .Defaults()
            .Port(18234)
            .Start();
    }

}