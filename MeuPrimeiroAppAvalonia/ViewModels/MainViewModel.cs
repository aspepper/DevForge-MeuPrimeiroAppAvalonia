using System.Windows.Input;
using MeuPrimeiroAppAvalonia.Interfaces;
using ReactiveUI;

namespace MeuPrimeiroAppAvalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "Dê um Like!!!!";
    private readonly INavigationService navigationService;

    public MainViewModel(INavigationService navigationService)
    {
        this.navigationService = navigationService;
        OpenPersonCommand = ReactiveCommand.Create(OpenPersonView);
    }

    public ICommand OpenPersonCommand { get; }

    public void OpenPersonView()
    {
        navigationService.NavigateTo<PersonViewModel>();
    }
}
