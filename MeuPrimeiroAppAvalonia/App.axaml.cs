using Microsoft.Extensions.DependencyInjection;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MeuPrimeiroAppAvalonia.ViewModels;
using MeuPrimeiroAppAvalonia.Views;
using Models;
using MeuPrimeiroAppAvalonia.Interfaces;
using MeuPrimeiroAppAvalonia.Services;

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
       var serviceCollection = new ServiceCollection();

        // Registrar ViewModels
        serviceCollection.AddTransient<MainWindowViewModel>();
        serviceCollection.AddTransient<PersonViewModel>();

        // Registrar Views
        serviceCollection.AddTransient<MainWindow>();
        serviceCollection.AddTransient<PersonView>();

        // Registrar Serviço de Navegação
        serviceCollection.AddSingleton<INavigationService, NavigationService>();

        // Adicionar outras dependências
        serviceCollection.AddSingleton<PersonModel>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            serviceCollection.AddSingleton<ApplicationLifeTime<IClassicDesktopStyleApplicationLifetime>>();
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            serviceCollection.AddSingleton<ApplicationLifeTime<ISingleViewApplicationLifetime>>();
        }

        var mainWindow = serviceProvider.GetRequiredService<MainWindow>();

        mainWindow.DataContext = serviceProvider.GetRequiredService<MainWindowViewModel>();

        mainWindow.Show();

        base.OnFrameworkInitializationCompleted();
    }

}