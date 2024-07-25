using MeuPrimeiroAppAvalonia.Interfaces;
using ReactiveUI;
using System.Windows.Input;

namespace MeuPrimeiroAppAvalonia.ViewModels;

public class ViewModelBase : ReactiveObject
{
    private readonly INavigationService navigationService;
    public ICommand? GoBackCommand { get; }

    internal ViewModelBase(INavigationService navigationService)
    {
        this.navigationService = navigationService;
        GoBackCommand = ReactiveCommand.Create(GoBack);
    }

    internal void GoBack()
    {
        navigationService.NavigateToBack();
    }

}
