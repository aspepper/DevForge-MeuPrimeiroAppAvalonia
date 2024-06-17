using Avalonia.Controls;
using MeuPrimeiroAppAvalonia.ViewModels;

namespace MeuPrimeiroAppAvalonia.Views;

public partial class PersonView : UserControl
{
    public PersonView(PersonViewModel viewModel)
    {
        InitializeComponent();
        this.DataContext = viewModel;
    }
}