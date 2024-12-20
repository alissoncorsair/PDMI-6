using P02.Models;
using P02.Repositories;

namespace P02.Pages;

public partial class AddLivro : ContentPage
{
    private readonly ILivroRepository livroRepository;

    public AddLivro()
	{
		InitializeComponent();
        this.livroRepository = LivroRepository.getInstance();
	}

    private async void onAdd(object sender, EventArgs e)
    {
        var livro = currentLivro();

        if (livro != null)
        {
            livroRepository.Create(livro);
            await Navigation.PopModalAsync();
        }
    }

    private async void onCancel(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();

    }

    private Livro currentLivro()
    {
        if (string.IsNullOrWhiteSpace(txtNome.Text) ||
            string.IsNullOrWhiteSpace(txtAutor.Text) ||
            string.IsNullOrWhiteSpace(txtEmail.Text) ||
            string.IsNullOrWhiteSpace(txtISBN.Text))
        {
            DisplayAlert("", "Preencha todos os campos!", "Ok");
            return null;
        }

        return new Livro(txtNome.Text, txtAutor.Text, txtEmail.Text, txtISBN.Text);
    }
}