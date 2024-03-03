namespace OpenCiv1.Contracts;

public interface IMainForm
{
    GPU.GPoint ScreenMouseLocation { get; }
    Input.MouseButtons ScreenMouseButtons { get; }

    object? GetObject(string name);
    void OnScreenCountChange();
}
