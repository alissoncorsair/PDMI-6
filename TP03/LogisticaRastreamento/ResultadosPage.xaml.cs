using LogisticaRastreamento.ViewModels;

namespace LogisticaRastreamento;

public partial class ResultadosPage : ContentPage
{
	public ResultadosPage()
	{
        BindingContext = new PacoteViewModel();
        InitializeComponent();
	}

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}