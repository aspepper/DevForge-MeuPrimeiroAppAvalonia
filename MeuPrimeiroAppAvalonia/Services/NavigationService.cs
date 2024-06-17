using System;
using Avalonia;
using Avalonia.Controls;
using MeuPrimeiroAppAvalonia.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MeuPrimeiroAppAvalonia.Services;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void NavigateTo<TViewModel>() where TViewModel : class
    {
        var viewModel = _serviceProvider.GetRequiredService<TViewModel>();
        var viewType = ViewLocator.ResolveViewType(viewModel.GetType());
        var view = (Window)_serviceProvider.GetRequiredService(viewType);
        view.DataContext = viewModel;
        view.Show();
    }

    public void NavigateToRoot<TViewModel>() where TViewModel : class
    {
        /*foreach (var window in Application.Current)
        {       
            window.Close();
        }*/
        NavigateTo<TViewModel>();
    }
}