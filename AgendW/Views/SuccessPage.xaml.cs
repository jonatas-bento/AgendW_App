using AgendW.Models;
using AgendW.ViewModels;

namespace AgendW.Views;

public partial class SuccessPage : ContentPage
{
    private readonly Atendimento _atendimento;

    public SuccessPage(Atendimento atendimento)
    {
        InitializeComponent();
        // Set background for navigation bar
        _atendimento = atendimento;
        NavigationPage.SetHasNavigationBar(this, true);
        NavigationPage.SetHasBackButton(this, true);
        NavigationPage.SetBackButtonTitle(this, "Voltar");
        NavigationPage.SetTitleIconImageSource(this, "logolargerbackground.png");
        var _viewModel = new SuccessPageViewModel(_atendimento);
        BindingContext = _viewModel;
    }
}
