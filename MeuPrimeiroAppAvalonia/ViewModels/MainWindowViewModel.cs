using System.Windows.Input;
using MeuPrimeiroAppAvalonia.Interfaces;
using MeuPrimeiroAppAvalonia.ViewModels;
using ReactiveUI;

public class MainWindowViewModel
{
    private readonly INavigationService _navigationService;

    public MainWindowViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        OpenPersonCommand = ReactiveCommand.Create(OpenPersonView);
    }

    public ICommand OpenPersonCommand { get; }

    public void OpenPersonView()
    {
        _navigationService.NavigateTo<PersonViewModel>();
    }
}
