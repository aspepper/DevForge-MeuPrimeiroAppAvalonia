using System;
using System.Windows.Input;
using MeuPrimeiroAppAvalonia.Interfaces;
using ReactiveUI;

namespace MeuPrimeiroAppAvalonia.ViewModels;

public class SamplesViewModel: ViewModelBase
{
    private readonly INavigationService navigationService;

    public SamplesViewModel(INavigationService navigationService) 
    { 
        GoBackCommand = ReactiveCommand.Create(GoBack);
        this.navigationService = navigationService;
    }
    public ICommand GoBackCommand { get; }

    private void GoBack() 
    {
        navigationService.NavigateToBack();
    }
}
