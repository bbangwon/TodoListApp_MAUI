using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TodoListApp.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    string? text;

    [RelayCommand]
    void Add()
    {
        // add our item
        Text = string.Empty;        
    }
}

