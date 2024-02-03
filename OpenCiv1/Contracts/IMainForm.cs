using Avalonia.Input;
using Point = System.Drawing.Point;


namespace OpenCiv1.Contracts;

public interface IMainForm
{
    MouseButton ScreenMouseButtons { get; }

    Point ScreenMouseLocation { get; }

    void OnScreenCountChange();
}