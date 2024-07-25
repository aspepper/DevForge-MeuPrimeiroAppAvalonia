using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using MeuPrimeiroAppAvalonia.Interfaces;
using Models;
using ReactiveUI;

namespace MeuPrimeiroAppAvalonia.ViewModels;

public class PersonViewModel : ViewModelBase
{
    private PersonModel person;

    public PersonViewModel(PersonModel personModel, INavigationService navigationService) : base(navigationService)
    {
        person = personModel;
        SendCommand = ReactiveCommand.Create(SendData);
    }

    public PersonModel Person
    {
        get => person;
        set => this.RaiseAndSetIfChanged(ref person, value);
    }

    public ObservableCollection<GenderDataList> Genders { get; private set; } =
        [
            GenderDataList.None,
            GenderDataList.Male,
            GenderDataList.Female,
            GenderDataList.Other
        ];

    public ObservableCollection<CityDataList> Cities { get; private set; } =
        [
            CityDataList.Santos,
            CityDataList.SaoPaulo,
            CityDataList.RioDeJaneiro,
            CityDataList.NewYrok,
            CityDataList.Londres,
            CityDataList.Tokio,
            CityDataList.Paris,
            CityDataList.Roma
        ];

    public ICommand SendCommand { get; }

    private void SendData()
    {
        Debug.WriteLine($"Id = {Person.Id}");
        Debug.WriteLine($"Name = {Person.Name}");
        Debug.WriteLine($"Age = {Person.Age}");
        Debug.WriteLine($"Gender = {Person.Gender}");
        Debug.WriteLine($"Is Organ Donor? {Person.IsOrganDonor}");
        Debug.WriteLine($"Birth City = {Person.BirthCity}");
    }
}
