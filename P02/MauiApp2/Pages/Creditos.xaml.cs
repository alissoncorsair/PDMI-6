namespace P02.Pages;

public partial class Creditos : ContentPage
{
	public Creditos()
	{
		InitializeComponent();
	}

    private async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}