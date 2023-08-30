namespace AgendW.Views;

public partial class AfterLogon : ContentPage
{
	public AfterLogon()
	{
		InitializeComponent();
	}

    private async void Frame1_Tapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AgendamentoPage());
    }

    private async void Frame2_Tapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdministraAgendamentoPage());
    }
}