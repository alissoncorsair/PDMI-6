using System.Collections.ObjectModel;
using TP02.Enums;
using TP02.Models;
using TP02.Repository;

namespace TP02.Pages;

public partial class EditPage : ContentPage
{
    private TaskModel currentTask;
    private readonly TaskRepository taskRepository;

    public ObservableCollection<string> PriorityOptions { get; set; }
    public Dictionary<Priority, string> PriorityMapping { get; set; }

    private Priority selectedPriority;
    public Priority SelectedPriority
    {
        get => selectedPriority;
        set
        {
            if (selectedPriority != value)
            {
                selectedPriority = value;
                OnPropertyChanged(nameof(SelectedPriority));
                OnPropertyChanged(nameof(SelectedPriorityOption));
            }
        }
    }

    public string SelectedPriorityOption
    {
        get => PriorityMapping[SelectedPriority];
        set
        {
            var priority = PriorityMapping.FirstOrDefault(x => string.Equals(x.Value, value?.Trim(), StringComparison.OrdinalIgnoreCase)).Key;
            if (!PriorityMapping.ContainsKey(priority))
            {
                DisplayAlert("Erro", "Selecione uma prioridade válida!", "OK");
                return;
            }
            if (SelectedPriority != priority)
            {
                SelectedPriority = priority;
            }
        }
    }

    public string Title
    {
        get => currentTask.Title;
        set
        {
            if (currentTask.Title != value)
            {
                currentTask.Title = value;
                OnPropertyChanged();
            }
        }
    }

    public DateTime CreateAt
    {
        get => currentTask.CreateAt;
        set
        {
            if (currentTask.CreateAt != value)
            {
                currentTask.CreateAt = value;
                OnPropertyChanged();
            }
        }
    }

    public string Description
    {
        get => currentTask.Description;
        set
        {
            if (currentTask.Description != value)
            {
                currentTask.Description = value;
                OnPropertyChanged();
            }
        }
    }

    public EditPage(TaskModel task)
    {
        InitializeComponent();
        currentTask = task;
        taskRepository = new TaskRepository();

        PriorityOptions = new ObservableCollection<string> { "Baixa", "Média", "Alta" };
        PriorityMapping = new Dictionary<Priority, string>
        {
            { Priority.baixa, "Baixa" },
            { Priority.media, "Média" },
            { Priority.alta, "Alta" }
        };

        SelectedPriority = currentTask.TaskPriority;

        BindingContext = this;
    }

    private async void onEdit(object sender, EventArgs e)
    {
        if (SelectedPriorityOption != null)
        {
            currentTask.TaskPriority = SelectedPriority;
        }
        taskRepository.Update(currentTask.Id, currentTask);
        await Navigation.PopModalAsync();
    }

    private async void onCancel(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
