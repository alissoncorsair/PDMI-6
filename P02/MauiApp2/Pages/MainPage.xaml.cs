using P02.Models;
using P02.Pages;
using P02.Repositories;
using System.Collections.ObjectModel;

namespace P02
{
    public partial class MainPage : ContentPage
    {
        private readonly ILivroRepository livroRepository;

        public MainPage()
        {
            InitializeComponent();
            this.livroRepository = LivroRepository.getInstance();
        }

        private async void OnAddLivro(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddLivro());
        }

        private async void OnCreditos(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Creditos());
        }

        private async void OnCoordenadas(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Coordenadas());
        }

        private async void OnOpenDetails(object sender, EventArgs e)
        {
            if (sender is TextCell textCell && textCell.BindingContext is Livro livro)
            {
                await Navigation.PushAsync(new DetailsLivro(livro));
            }
        }

        protected override async void OnAppearing()
        {
            await livroRepository.InitializeAsync();
            var livros = await livroRepository.GetAll();
            listLivros.ItemsSource = new ObservableCollection<Livro>(livros);
            base.OnAppearing();
        }
    }
}