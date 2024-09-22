using TP01.Model;

namespace TP01;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent();
	}

    private async void OnOkClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Id.Text) || string.IsNullOrWhiteSpace(Pass.Text))
        {
            await DisplayAlert("", "Preencha os campos!", "Ok");
            return;
        }

        var user = new User()
        {
            Identifier = Id.Text,
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
        Id.Text = "";
        Id.Focus(); 
    }

    private async void OnAuthorsClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Créditos", "Desenvolvido por: \nAlisson de Sousa Vieira e Leonardo de Fontes.", "OK");
    }
}

