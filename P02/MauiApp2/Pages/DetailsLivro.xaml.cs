using P02.Models;
using P02.Repositories;

namespace P02.Pages;

public partial class DetailsLivro : ContentPage
{
    private Livro currenteLivro;
    private readonly ILivroRepository livroRepository;

    public DetailsLivro(Livro livro)
    {
        InitializeComponent();

        currenteLivro = livro;
        BindingContext = livro;

        livroRepository = LivroRepository.getInstance();
    }

    private async void OnEditarClick(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new EditPage(currenteLivro));
    }

    private async void OnExcluirClick(object sender, EventArgs e)
    {
        bool remove = await DisplayAlert("Excluir item",
                                        "Deseja realmente remover o item:\n" + currenteLivro.Nome,
                                        "Sim",
                                        "Não");

        if (currenteLivro != null && remove)
        {
            livroRepository.Delete(currenteLivro.Id);
        }

        await Navigation.PopAsync();
    }

    protected async override void OnAppearing()
    {
        currenteLivro = await livroRepository.GetById(currenteLivro.Id);
        BindingContext = currenteLivro;
        base.OnAppearing();
    }
}