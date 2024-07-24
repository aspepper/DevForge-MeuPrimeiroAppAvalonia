using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MeuPrimeiroAppAvalonia.DependencyInjection;
using MeuPrimeiroAppAvalonia.ViewModels;
using MeuPrimeiroAppAvalonia.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MeuPrimeiroAppAvalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
#if DEBUG
        //this.AttachDevTools();
#endif
        var serviceProvider = new AppServiceProviderBuilder().AppServiceProvider;

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWindow = serviceProvider!.GetRequiredService<MainWindow>();
            mainWindow.DataContext = serviceProvider!.GetRequiredService<MainWindowViewModel>();
            desktop.MainWindow = mainWindow;
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            var rootView = serviceProvider!.GetRequiredService<MainView>();
            rootView.DataContext = serviceProvider!.GetRequiredService<MainViewModel>();
            singleViewPlatform.MainView = rootView;
        }

        base.OnFrameworkInitializationCompleted();
    }

}