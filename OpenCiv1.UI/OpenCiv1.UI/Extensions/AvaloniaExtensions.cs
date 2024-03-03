using Avalonia;

using OpenCiv1.GPU;

namespace OpenCiv1.UI.Extensions;

internal static class AvaloniaExtensions
{
    public static GPoint ToGPoint(this Point point)
    {
        return new GPoint((int)point.X, (int)point.Y);
    }
}
