using System.Threading.Tasks;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenCiv1UI.Core.Services.Contracts;

namespace OpenCiv1UI.Core.ViewModels;

public partial class MessageBoxViewModel : ViewModelBase, IDialogService
{
    [ObservableProperty]
    private string _message = "";
    
    [ObservableProperty]
    private bool _isDialogOpen = false;
    
    [ObservableProperty]
    private string _title = "Message";

    [RelayCommand]
    private void Close()
    {
        IsDialogOpen = false;
    }
    
    public async Task ShowAsync(string message, string title = "")
    {
        Message = message;
        Title = title;
        IsDialogOpen = true;
        while (IsDialogOpen)
        {
            await Task.Delay(100);
        }
    }
}