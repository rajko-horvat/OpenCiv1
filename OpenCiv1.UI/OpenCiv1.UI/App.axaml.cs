using System;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using MsBox.Avalonia.Enums;
using MsBox.Avalonia;

using OpenCiv1.UI.ViewModels;
using OpenCiv1.UI.Views;

namespace OpenCiv1.UI;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var mainVm = new MainViewModel();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWindow = new MainWindow()
            {
                DataContext = mainVm
            };
            desktop.MainWindow = mainWindow;
            mainWindow.Closing += OnMainWindowClosing;
            desktop.Exit += (sender, e) => mainVm.Dispose();
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView()
            {
                DataContext = mainVm
            };
            singleViewPlatform.MainView.DetachedFromVisualTree += (sender, e) => mainVm.Dispose();
            // No automatic shutdown for single view applications
            // No windowing system for message boxes on single view applications
        }

        base.OnFrameworkInitializationCompleted();
    }

    private async void OnMainWindowClosing(object? sender, WindowClosingEventArgs e)
    {
        e.Cancel = true;
        var box = MessageBoxManager
                  .GetMessageBoxStandard("Exit", "Are you sure you want to exit?",
                      ButtonEnum.YesNo);

        var result = await box.ShowWindowDialogAsync((MainWindow)sender!);
        if (result == ButtonResult.Yes)
        {
            ((MainWindow)sender!).Closing -= OnMainWindowClosing;
            ((MainWindow)sender!).Close();
        }
    }
}