using Avalonia.Controls;

using OpenCiv1.UI.ViewModels;

namespace OpenCiv1.UI.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContextChanged += (s, e) =>
        {
            if (DataContext is MainViewModel mainVm)
            {
                mainVm.InvalidateBitmap += Image.InvalidateVisual;
                Image.PointerMoved += (s, e) => mainVm.OnPointerMoved(e, Image);
                Image.PointerPressed += (s, e) => mainVm.OnPointerPressed(e, Image);
                Image.PointerReleased += (s, e) => mainVm.OnPointerReleased(e, Image);
                KeyDown += (s, e) => mainVm.OnKeyDown(e);
            }
        };
    }
}