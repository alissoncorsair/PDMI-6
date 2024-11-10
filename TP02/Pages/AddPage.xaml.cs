using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using TP02.Enums;
using TP02.Models;
using TP02.Repository;

namespace TP02.Pages;

public partial class AddPage : ContentPage
{
    public ObservableCollection<string> PriorityOptions { get; set; }
    public string SelectedPriority { get; set; }
    private readonly TaskRepository taskRepository;
    private TaskModel currentTask;
    public Dictionary<string, Priority> PriorityMapping { get; set; }

    public AddPage(TaskModel task)
    {
        InitializeComponent();
        currentTask = task;
        PriorityOptions = new ObservableCollection<string>
        {
            "Baixa",
            "Média",
            "Alta"
        };
        PriorityMapping = new Dictionary<string, Priority>
        {
            { "Baixa", Priority.baixa },
            { "Média", Priority.media },
            { "Alta", Priority.alta }
        };
        BindingContext = this;
        taskRepository = new TaskRepository();
    }

    private async void onAdd(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
            string.IsNullOrWhiteSpace(txtDescription.Text) ||
            txtCreated.Date == default(DateTime) ||
            string.IsNullOrWhiteSpace(SelectedPriority))
        {
            DisplayAlert("", "Preencha todos os campos!", "Ok");
            return;
        }

        currentTask.Title = txtTitle.Text;
        currentTask.Description = txtDescription.Text;
        currentTask.CreateAt = txtCreated.Date;

        if (PriorityMapping.TryGetValue(SelectedPriority, out var priority))
        {
            currentTask.TaskPriority = priority;
        }
        else
        {
            DisplayAlert("Erro", "Selecione uma prioridade válida!", "OK");
            return;
        }

        taskRepository.Add(currentTask);
        await Navigation.PopModalAsync();
    }

    private async void onCancel(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private string RemoveAccents(string input)
    {
        var normalizedString = input.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }
}