using Avalonia.Controls;

namespace MeuPrimeiroAppAvalonia.Interfaces;

public interface INavigationService
{
    void NavigateTo<TViewModel>() where TViewModel : class;
    
    void NavigateToRoot<TViewModel>() where TViewModel : class;

    void NavigateToBack();

    void Initialize(ContentControl contentControl);
}
