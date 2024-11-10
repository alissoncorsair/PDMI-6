using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TP02.Enums;

namespace TP02.Models;

public class TaskModel : INotifyPropertyChanged
{
    private string title;
    private string description;
    private DateTime createAt;
    private Priority taskPriority;

    public Guid Id { get; set; }

    public string Title
    {
        get => title;
        set
        {
            if (title != value)
            {
                title = value;
                OnPropertyChanged();
            }
        }
    }

    public string Description
    {
        get => description;
        set
        {
            if (description != value)
            {
                description = value;
                OnPropertyChanged();
            }
        }
    }

    public DateTime CreateAt
    {
        get => createAt;
        set
        {
            if (createAt != value)
            {
                createAt = value;
                OnPropertyChanged();
            }
        }
    }

    public Priority TaskPriority
    {
        get => taskPriority;
        set
        {
            if (taskPriority != value)
            {
                taskPriority = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TaskPriorityString));
            }
        }
    }

    public string TaskPriorityString => TaskPriority switch
    {
        Priority.baixa => "Baixa",
        Priority.media => "Média",
        Priority.alta => "Alta",
        _ => "Desconhecida"
    };

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
