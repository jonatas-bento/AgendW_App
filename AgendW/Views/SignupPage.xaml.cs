using AgendW.Services;
using AgendW.ViewModels;

namespace AgendW.Views;

public partial class SignupPage : ContentPage
{
    private readonly IAuthenticationService _authenticationService;

    public SignupPage(IAuthenticationService authenticationService)
	{
		InitializeComponent();
        _authenticationService = authenticationService;
		var _viewModel = new IdentityViewModel(_authenticationService);
		BindingContext = _viewModel;
    }
}