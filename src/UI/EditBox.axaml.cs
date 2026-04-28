using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using SkiaSharp;

namespace OpenCiv1;

public partial class EditBox : Window
{
	private bool windowClosed = false;
	private bool allowEmptyText = true;
	private string? defaultText = null;
	private string? textValue = null;
	private int maxTextLength = 0;

	public EditBox()
    {
        InitializeComponent();
    }

	public EditBox(string title, string? placeholderText, string? defaultText, int maxTextLength, bool allowEmptyText)
	{
		InitializeComponent();

		this.Icon = null;
		this.Title = null;

		this.KeyDown += this.EditBox_KeyDown; ;
		this.Closed += this.EditBox_Closed;
		this.txtInput.TextChanged += this.TxtInput_TextChanged;
		this.txtInput.KeyDown += this.TxtInput_KeyDown;

		this.lblDescription.Text = title;
		this.txtInput.Watermark = placeholderText;
		this.defaultText = defaultText;
		this.txtInput.Text = defaultText;
		this.maxTextLength = maxTextLength;
		this.allowEmptyText = allowEmptyText;

		if (maxTextLength > 0)
			this.txtInput.MaxLength = maxTextLength;

		this.txtInput.CaretIndex = (!string.IsNullOrEmpty(defaultText) ? defaultText.Length : 0);

		this.btnCancel.IsEnabled = this.allowEmptyText || !string.IsNullOrEmpty(defaultText);
		this.btnOk.IsEnabled = this.allowEmptyText || !string.IsNullOrEmpty(defaultText);

		this.btnOk.Click += this.BtnOk_Click;
		this.btnCancel.Click += this.BtnCancel_Click;

		this.Activated += this.EditBox_Activated;
	}

	private void TxtInput_KeyDown(object? sender, Avalonia.Input.KeyEventArgs e)
	{
		if (e.KeyModifiers == Avalonia.Input.KeyModifiers.None)
		{
			switch (e.Key)
			{
				case Avalonia.Input.Key.Escape:
					this.textValue = this.defaultText;
					this.Close();
					break;

				case Avalonia.Input.Key.Enter:
					this.Close();
					break;
			}
		}
	}

	private void EditBox_KeyDown(object? sender, Avalonia.Input.KeyEventArgs e)
	{
		if (e.KeyModifiers == Avalonia.Input.KeyModifiers.None && e.Key == Avalonia.Input.Key.Escape)
		{
			this.textValue = this.defaultText;
			this.Close();
		}
	}

	private void EditBox_Activated(object? sender, EventArgs e)
	{
		this.txtInput.Focus();
	}

	private void BtnCancel_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
		this.textValue = this.defaultText;
		this.Close();
	}

	private void BtnOk_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
		this.textValue = (string.IsNullOrEmpty(this.txtInput.Text) ? this.txtInput.Text : this.txtInput.Text.Trim());

		if (allowEmptyText || !string.IsNullOrEmpty(this.textValue))
		{
			this.Close();
		}
		else
		{
			this.txtInput.IsEnabled = false;
			this.txtInput.Text = this.textValue;
			this.txtInput.IsEnabled = true;
		}
	}

	private void TxtInput_TextChanged(object? sender, TextChangedEventArgs e)
	{
		this.textValue = (string.IsNullOrEmpty(this.txtInput.Text) ? this.txtInput.Text : this.txtInput.Text.Trim());

		this.textValue = 
			(this.textValue != null && this.maxTextLength > 0 && this.textValue.Length > this.maxTextLength) ? this.textValue.Substring(0, this.maxTextLength) : this.textValue;

		this.btnCancel.IsEnabled = this.allowEmptyText || !string.IsNullOrEmpty(this.defaultText);
		this.btnOk.IsEnabled = this.allowEmptyText || !string.IsNullOrEmpty(this.textValue);
	}

	private void EditBox_Closed(object? sender, EventArgs e)
	{
		this.windowClosed = true;
	}

	public static string? ShowEditBoxDialog(Window owner, string title, string? placeholderText, string? defaultValue, int maxTextLength, bool allowEmptyText)
	{
		EditBox? dialog = null;
		bool creatingWindow = true;

		Dispatcher.UIThread.Invoke(() => {
			try { dialog = new EditBox(title, placeholderText, defaultValue, maxTextLength, allowEmptyText); dialog.ShowDialog(owner); } finally { creatingWindow = false; }
		});

		while (creatingWindow) { Thread.Sleep(10); }
		while (dialog != null && !dialog.IsClosed) { Thread.Sleep(10); }

		return ((dialog != null) ? dialog.TextValue : defaultValue);
	}

	public bool IsClosed
	{
		get => windowClosed;
	}

	public string? TextValue { get => this.textValue; }
}