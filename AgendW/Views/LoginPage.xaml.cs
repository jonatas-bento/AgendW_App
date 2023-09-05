using AgendW.Services;
using AgendW.ViewModels;

namespace AgendW.Views;

public partial class LoginPage : ContentPage
{
    private readonly IAuthenticationService _authenticationService;

    private bool continueAnimating = true;

    public LoginPage(IAuthenticationService authenticationService)
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        _authenticationService = authenticationService;

        var viewModel = new IdentityViewModel(_authenticationService);

        viewModel.NavigateToAgendamentoPageAction = async () =>
        {
            await Navigation.PushAsync(new AfterLogon());
        };

        BindingContext = viewModel;
    }

    private async void OnLabelTapped(object sender, EventArgs e)
    {
        var authenticationService = DependencyService.Get<IAuthenticationService>();
        await Navigation.PushAsync(new SignupPage(authenticationService));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        continueAnimating = true;
        AnimateCircle();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        continueAnimating = false; // Stop the animation loop
    }

    async void AnimateCircle()
    {
        while (continueAnimating) // Loop will break if continueAnimating is set to false
        {
            await Frame1.ScaleTo(1.2, 1000, Easing.SinInOut); // Expand
            await Frame1.ScaleTo(1.0, 1000, Easing.SinInOut); // Contract
        }
    }

}