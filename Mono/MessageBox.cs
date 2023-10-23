using System.Windows.Forms;

#if(__MonoCS__)
// ReSharper disable once CheckNamespace
namespace System.Windows
{
    public static class MessageBox
    {
        public static void Show(string message, string caption, MessageBoxButton buttons,
            MessageBoxImage icon, MessageBoxResult? ignored = null)
        {
            Forms.MessageBox.Show(message, caption, (MessageBoxButtons)buttons, (MessageBoxIcon)icon);
        }
    }

    public enum MessageBoxButton
    {
        // ReSharper disable once InconsistentNaming
        OK,
        // ReSharper disable once InconsistentNaming
        OKCancel,
        AbortRetryIgnore,
        YesNoCancel,
        YesNo,
        RetryCancel,
    }

    public enum MessageBoxImage
    {
        None = 0,
        Error = 16, // 0x00000010
        Hand = 16, // 0x00000010
        Stop = 16, // 0x00000010
        Question = 32, // 0x00000020
        Exclamation = 48, // 0x00000030
        Warning = 48, // 0x00000030
        Asterisk = 64, // 0x00000040
        Information = 64, // 0x00000040
    }

    public enum MessageBoxResult
    {
        // ReSharper disable once InconsistentNaming
        OK
    }
}
#endif