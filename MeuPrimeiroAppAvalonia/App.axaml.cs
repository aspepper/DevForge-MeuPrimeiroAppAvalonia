using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MeuPrimeiroAppAvalonia.Interfaces;
using MeuPrimeiroAppAvalonia.Services;
using MeuPrimeiroAppAvalonia.ViewModels;
using MeuPrimeiroAppAvalonia.Views;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System;

namespace MeuPrimeiroAppAvalonia
{
    public partial class App : Application
    {
        // Initialize the application
        public override void Initialize()
        {
            // Load Avalonia XAML definitions for the application
            AvaloniaXamlLoader.Load(this);
        }

        // Method called when the framework initialization is completed
        public override void OnFrameworkInitializationCompleted()
        {
#if DEBUG
            // Attach development tools if in debug mode
            this.AttachDevTools();
#endif
            // Build the service provider for dependency injection
            var serviceProvider = DependencyInjectionConstructorBuilder();

            // Check if the application lifetime is for desktop applications
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Retrieve MainWindow and MainWindowViewModel from the service provider
                var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
                mainWindow.DataContext = serviceProvider.GetRequiredService<MainWindowViewModel>();
                // Set the main window of the desktop application
                desktop.MainWindow = mainWindow;
            }
            // Check if the application lifetime is for single view applications
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                // Retrieve MainView and MainViewModel from the service provider
                var mainView = serviceProvider.GetRequiredService<MainView>();
                mainView.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
                // Set the main view of the single view application
                singleViewPlatform.MainView = mainView;
            }

            // Call the base class method
            base.OnFrameworkInitializationCompleted();
        }

        // Method to build the service provider for dependency injection
        private IServiceProvider DependencyInjectionConstructorBuilder()
        {
            // Create a new service collection
            var serviceCollection = new ServiceCollection();

            // Register ViewModels
            serviceCollection.AddSingleton<MainWindowViewModel>();
            serviceCollection.AddTransient<ContainerViewModel>();
            serviceCollection.AddTransient<MainViewModel>();
            serviceCollection.AddTransient<PersonViewModel>();

            // Register Views
            serviceCollection.AddSingleton<MainWindow>();
            serviceCollection.AddTransient<ContainerView>();
            serviceCollection.AddTransient<MainView>();
            serviceCollection.AddTransient<PersonView>();

            // Register Navigation Service
            serviceCollection.AddSingleton<INavigationService, NavigationService>();

            // Add other dependencies
            serviceCollection.AddTransient<PersonModel>();

            // Build and return the service provider
            return serviceCollection.BuildServiceProvider();
        }
    }
}