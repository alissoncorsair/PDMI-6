using P02.Models;
using P02.Repositories;

namespace P02.Pages;

public partial class EditPage : ContentPage
{
    private Livro currenteLivro;
    private readonly ILivroRepository livroRepository;

    public EditPage(Livro livro)
	{
		InitializeComponent();

        currenteLivro = livro;
        BindingContext = livro;

        livroRepository = LivroRepository.getInstance();
    }

    private async void onEdit(object sender, EventArgs e)
    {
        livroRepository.Update(currenteLivro.Id, currenteLivro);
        await Navigation.PopModalAsync();
    }

    private async void onCancel(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();

    }
}