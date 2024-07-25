using MeuPrimeiroAppAvalonia.Interfaces;

namespace MeuPrimeiroAppAvalonia.ViewModels;

public class SamplesViewModel(INavigationService navigationService) : ViewModelBase(navigationService)
{
    private readonly INavigationService navigationService = navigationService;
}
