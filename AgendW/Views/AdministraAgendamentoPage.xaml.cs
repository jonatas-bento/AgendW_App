using AgendW.ViewModels;

namespace AgendW.Views;

public partial class AdministraAgendamentoPage : ContentPage
{
    private AtendimentoViewModel _viewModel;
	public AdministraAgendamentoPage()
	{
		InitializeComponent();
		_viewModel = new AtendimentoViewModel();
        BindingContext = _viewModel;
	}

	protected override async void OnAppearing()
	{
        base.OnAppearing();

        await _viewModel.GetAtendimentos();

    }
}