using System.Threading.Tasks;
using TP02.Models;
using TP02.Repository;

namespace TP02.Pages;

public partial class DetailsPage : ContentPage
{
    private TaskModel currentTask;
    private readonly TaskRepository taskRepository;

    public DetailsPage(TaskModel task)
    {
        InitializeComponent();
        currentTask = task;
        taskRepository = new TaskRepository();
        BindingContext = currentTask; // Set the BindingContext to the current task
    }

    private async void OnEditarClick(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new EditPage(currentTask));
    }

    private async void OnExcluirClick(object sender, EventArgs e)
    {
        bool remove = await DisplayAlert("Excluir item",
                                        "Deseja realmente remover o item:\n" + currentTask.Title,
                                        "Sim",
                                        "Não");

        if (currentTask != null && remove)
        {
            taskRepository.Remove(currentTask.Id);
        }

        await Navigation.PopAsync();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        currentTask = taskRepository.Get(currentTask.Id);
        BindingContext = currentTask; // Update the BindingContext
    }
}