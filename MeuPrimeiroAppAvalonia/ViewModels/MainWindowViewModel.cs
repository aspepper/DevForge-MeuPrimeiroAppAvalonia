using MeuPrimeiroAppAvalonia.Interfaces;

namespace MeuPrimeiroAppAvalonia.ViewModels;

public class MainWindowViewModel(INavigationService navigationService)
{
    private readonly INavigationService navigationService = navigationService;
}
