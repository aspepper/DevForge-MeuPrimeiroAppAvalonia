using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MeuPrimeiroAppAvalonia.Interfaces;
using MeuPrimeiroAppAvalonia.Services;
using MeuPrimeiroAppAvalonia.ViewModels;
using MeuPrimeiroAppAvalonia.Views;
using Microsoft.Extensions.DependencyInjection;
using Models;

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
        this.AttachDevTools();
#endif
        var serviceProvider = ConfigureContainerBuilder();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.DataContext = serviceProvider.GetRequiredService<MainWindowViewModel>();
            desktop.MainWindow = mainWindow;
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            var rootView = serviceProvider.GetRequiredService<MainView>();
            rootView.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            singleViewPlatform.MainView = rootView;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private ServiceProvider ConfigureContainerBuilder()
    {
        var serviceCollection = new ServiceCollection();

        // Registrar ViewModels
        serviceCollection.AddSingleton<MainWindowViewModel>();
        serviceCollection.AddTransient<MainViewModel>();
        serviceCollection.AddTransient<MenuViewModel>();
        serviceCollection.AddTransient<PersonViewModel>();
        serviceCollection.AddTransient<SamplesViewModel>();

        // Registrar Views
        serviceCollection.AddSingleton<MainWindow>();
        serviceCollection.AddTransient<MainView>();
        serviceCollection.AddTransient<MenuView>();
        serviceCollection.AddTransient<PersonView>();
        serviceCollection.AddTransient<SamplesView>();

        // Registrar Serviço de Navegação
        serviceCollection.AddSingleton<INavigationService, NavigationService>();

        // Adicionar outras dependências
        serviceCollection.AddTransient<PersonModel>();

        return serviceCollection.BuildServiceProvider();
    }

}