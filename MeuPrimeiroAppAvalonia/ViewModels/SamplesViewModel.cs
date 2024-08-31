using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MeuPrimeiroAppAvalonia.Interfaces;
using ReactiveUI;

namespace MeuPrimeiroAppAvalonia.ViewModels;

public class SamplesViewModel : ViewModelBase
{

    public SamplesViewModel (
        INavigationService navigationService)
    : base(navigationService)
    {
        this.navigationService = navigationService;
        GoAhead = ReactiveCommand.Create(() => { PosX += 10; });    
    }

    private readonly INavigationService navigationService;

    private string autocompleteresult = string.Empty;
    private DateTime selectedDate = DateTime.Now;

    public ObservableCollection<string> AutocompleteList { get; private set; } =
        [
            "Alexsandro",
            "Alessandro",
            "Alexandre",
            "Andre",
            "Andrea",
            "Andressa",
            "Bruna",
            "Bruno",
            "Breno",
        ];

    public string AutoCompleteResult
    {
        get => autocompleteresult;
        set => this.RaiseAndSetIfChanged(ref autocompleteresult, value);
    }

    private int posX = 250;
    public int PosX 
    {
        get => posX;
        set => this.RaiseAndSetIfChanged(ref posX, value);
    }

    private int posY = 30;
    public int PosY 
    {
        get => posY;
        set => this.RaiseAndSetIfChanged(ref posY, value);
    }

    public DateTime SelectedDate {
        get => selectedDate;
        set => this.RaiseAndSetIfChanged(ref selectedDate, value); 
    }

    public ICommand GoAhead { get; }

}
