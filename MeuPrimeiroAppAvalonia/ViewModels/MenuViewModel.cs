using System.Windows.Input;
using MeuPrimeiroAppAvalonia.Interfaces;
using ReactiveUI;

namespace MeuPrimeiroAppAvalonia.ViewModels;

public class MenuViewModel : ViewModelBase
{
    public string Greeting => "Dê um Like!!!!";
    private readonly INavigationService navigationService;

    public MenuViewModel(INavigationService navigationService)
    {
        this.navigationService = navigationService;
        OpenPersonCommand = ReactiveCommand.Create(OpenPersonView);
        OpenSamplesCommand = ReactiveCommand.Create(OpenSamplesView);
    }

    public ICommand OpenPersonCommand { get; }

    public ICommand OpenSamplesCommand { get; }

    private void OpenPersonView()
    {
        navigationService.NavigateTo<PersonViewModel>();
    }

    private void OpenSamplesView()
    {
        navigationService.NavigateTo<SamplesViewModel>();
    }
}