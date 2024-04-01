using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using GenHTTP.Engine;
using GenHTTP.Modules.IO;
using GenHTTP.Modules.Layouting;
using GenHTTP.Modules.Practices;
using GenHTTP.Modules.Security;
using GenHTTP.Modules.StaticWebsites;
using Microsoft.Extensions.DependencyInjection;
using UkiRandomizer.Configuration;
using UkiRandomizer.Core;
using UkiRandomizer.Repository;
using UkiRandomizer.Service;

namespace UkiRandomizer;

public partial class App
{
    private readonly ServiceProvider _diProvider;

    public App()
    {
        _diProvider = DIConfig.Init();

        var tree = ResourceTree.FromDirectory("www/");

        var resourceTree = ResourceTree.FromDirectory("Resources/");

        var app = Layout.Create()
            .Add("resources", GenHTTP.Modules.IO.Resources.From(resourceTree))
            .AddControllers(_diProvider)
            .Add(CorsPolicy.Permissive())
            .Fallback(StaticWebsite.From(tree));

        Host.Create()
            .Handler(app)
            .Defaults()
            .Port(18234)
            .Start();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var bw = new BackgroundWorker();
        bw.DoWork += BwOnDoWork;
        bw.WorkerSupportsCancellation = true;
        bw.WorkerReportsProgress = true;

        //This line here is what starts the asynchronous work
        bw.RunWorkerAsync();
    }

    private async void BwOnDoWork(object? sender, DoWorkEventArgs e)
    {
        InitDefaultData();
        await LoadRepositoriesAsync();
    }

    private void InitDefaultData()
    {
        _diProvider.GetService<IInitService>().Init();
    }

    private async Task LoadRepositoriesAsync()
    {
        var platformRepository = _diProvider.GetService<IPlatformRepository>();
        var genreRepository = _diProvider.GetService<IGenreRepository>();

        await Task.WhenAll(new List<Task>
        {
            platformRepository.LoadAsync(),
            genreRepository.LoadAsync()
        });
    }
}