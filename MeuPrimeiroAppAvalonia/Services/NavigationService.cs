using Avalonia;
using Avalonia.Controls;
using MeuPrimeiroAppAvalonia.Interfaces;
using MeuPrimeiroAppAvalonia.Views;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MeuPrimeiroAppAvalonia.Services;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider serviceProvider;
    private ContentControl contentControl;

    public NavigationService(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public void Initialize(ContentControl contentControl)
    {
        this.contentControl = contentControl;
    }

    public void NavigateTo<TViewModel>() where TViewModel : class
    {
        var viewModel = serviceProvider.GetRequiredService<TViewModel>();
        var viewType = ViewLocator.ResolveViewType(viewModel.GetType());
        if (viewType != null)
        {
            var view = (UserControl)serviceProvider.GetRequiredService(viewType);
            view.DataContext = viewModel;
            contentControl.Content = view;
        }
    }

    public void NavigateToRoot<TViewModel>() where TViewModel : class
    {
        NavigateTo<TViewModel>();
    }
}