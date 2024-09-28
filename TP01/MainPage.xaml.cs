using TP01.Model;

namespace TP01;
public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent();
	}
    // Alisson de Sousa Vieira
    // Leonardo de Fontes
    private async void OnOkClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(UserId.Text) || string.IsNullOrWhiteSpace(Pass.Text))
        {
            await DisplayAlert("", "Preencha os campos!", "Ok");
            return;
        }

        var user = new User()
        {
            Identifier = UserId.Text,
            Password = Pass.Text
        };

        if (user.isAuthenticated())
            await DisplayAlert("Alerta", "Logou com sucesso!", "Ok");
        else
            await DisplayAlert("Alerta", "Login não autorizado!", "Ok");
    }


    private void OnCleanClicked(object sender, EventArgs e)
    {
        Pass.Text = "";
        UserId.Text = "";
        UserId.Focus(); 
    }

    private async void OnAuthorsClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Créditos", "Alisson de Sousa Vieira e Leonardo de Fontes", "OK");
    }
}

