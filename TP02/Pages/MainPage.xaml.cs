using System.Collections.ObjectModel;
using TP02.Pages;
using TP02.Models;
using TP02.Repository;
using System.Threading.Tasks;

namespace TP02;

public partial class MainPage : ContentPage
{
    private readonly TaskRepository taskRepository;

    public MainPage()
    {
        InitializeComponent();
        taskRepository = new TaskRepository();
    }

    private async void OnAddTask(object sender, EventArgs e)
    {
        var newTask = new TaskModel();
        await Navigation.PushModalAsync(new AddPage(newTask));
    }

    private async void OnOpenDetails(object sender, EventArgs e)
    {
        if (sender is TextCell textCell && textCell.BindingContext is TaskModel task)
        {
            await Navigation.PushAsync(new DetailsPage(task));
        }
    }

    protected override void OnAppearing()
    {
        listTasks.ItemsSource = new ObservableCollection<TaskModel>(taskRepository.List());
        base.OnAppearing();
    }
}