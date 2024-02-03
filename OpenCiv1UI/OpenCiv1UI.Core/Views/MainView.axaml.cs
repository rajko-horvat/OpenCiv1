using Avalonia.Controls;
using Avalonia.Interactivity;
using OpenCiv1UI.Core.ViewModels;

namespace OpenCiv1UI.Core.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        Loaded += MainView_Loaded;
    }

    private async void MainView_Loaded(object? sender, RoutedEventArgs e)
    {
        if (this.DataContext is MainViewModel vm)
        {
            await vm.OnMainFormLoaded();
        }
    }
}