using MeuPrimeiroAppAvalonia.Interfaces;
using MeuPrimeiroAppAvalonia.Services;
using MeuPrimeiroAppAvalonia.ViewModels;
using MeuPrimeiroAppAvalonia.Views;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System;

namespace MeuPrimeiroAppAvalonia.DependencyInjection;

public sealed class AppServiceProviderBuilder : IServiceProvider
{

    public ServiceProvider? AppServiceProvider { get; private set; }

    public object? GetService(Type serviceType)
    {
        AppServiceProvider = ConfigureContainerBuilder();
        return AppServiceProvider;
    }

    private static ServiceProvider ConfigureContainerBuilder()
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
