using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace TodoListApp.ViewModel;

public partial class MainViewModel : ObservableObject
{
    IConnectivity connectivity;

    public MainViewModel(IConnectivity connectivity)
    {
        Items = [];
        this.connectivity = connectivity;
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string? text;

    [RelayCommand]
    async void Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        if(connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            // show error message
            await Shell.Current.DisplayAlert("앗!", "인터넷에 연결되어 있지 않아요!", "OK");
            return;
        }

        Items.Add(Text);

        // add our item
        Text = string.Empty;
    }

    [RelayCommand]
    void Delete(string s)
    {
        Items.Remove(s);
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
    }
}

