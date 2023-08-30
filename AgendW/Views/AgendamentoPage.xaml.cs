using AgendW.ViewModels;

namespace AgendW.Views;

public partial class AgendamentoPage : ContentPage
{
	private readonly AtendimentoViewModel _viewModel;
	public AgendamentoPage()
	{
		InitializeComponent();
		// Set background for navigation bar
		NavigationPage.SetHasNavigationBar(this, true);
		NavigationPage.SetHasBackButton(this, true);
		NavigationPage.SetBackButtonTitle(this, "Voltar");
		NavigationPage.SetTitleIconImageSource(this, "logolargerbackground.png");

		_viewModel = new AtendimentoViewModel
		{
			Navigation = Navigation
		};
		_viewModel.InitializeWithUserData();
		BindingContext = _viewModel;

	}
}