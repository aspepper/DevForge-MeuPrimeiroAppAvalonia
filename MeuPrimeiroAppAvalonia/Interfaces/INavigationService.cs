namespace MeuPrimeiroAppAvalonia.Interfaces;

public interface INavigationService
{
    void NavigateTo<TViewModel>() where TViewModel : class;
    void NavigateToRoot<TViewModel>() where TViewModel : class;
}