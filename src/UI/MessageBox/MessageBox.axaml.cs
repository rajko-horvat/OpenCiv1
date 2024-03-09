using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Threading;

namespace OpenCiv1.UI
{
	public partial class MessageBox : Window
	{
		private bool bHasReturnValue = false;
		private MessageBoxDefaultButton eReturnValue = MessageBoxDefaultButton.None;

		public MessageBox()
		{
			InitializeComponent();

			this.messageButton1.Click += this.MessageButton1_Click;
			this.messageButton2.Click += this.MessageButton2_Click;
			this.messageButton3.Click += this.MessageButton3_Click;
			this.KeyDown += this.MessageBox_KeyDown;
		}

		public bool HasValue
		{
			get => this.bHasReturnValue;
		}

		public MessageBoxDefaultButton ReturnValue
		{
			get => this.eReturnValue;
		}

		private void MessageBox_KeyDown(object? sender, Avalonia.Input.KeyEventArgs e)
		{
			if (e.KeyModifiers == KeyModifiers.None)
			{
				switch (e.Key)
				{
					case Key.Escape:
						this.eReturnValue = MessageBoxDefaultButton.None;
						this.bHasReturnValue = true;
						this.Close();
						break;

					case Key.Enter:
						if (this.messageButton1.IsDefault)
						{
							MessageButton1_Click(this, new RoutedEventArgs());
						}
						else if (this.messageButton2.IsDefault)
						{
							MessageButton2_Click(this, new RoutedEventArgs());
						}
						else if (this.messageButton3.IsDefault)
						{
							MessageButton3_Click(this, new RoutedEventArgs());
						}
						break;
				}
			}
		}

		private void MessageButton1_Click(object? sender, RoutedEventArgs e)
		{
			this.eReturnValue = MessageBoxDefaultButton.Button1;
			this.bHasReturnValue = true;
			this.Close();
		}

		private void MessageButton2_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
		{
			this.eReturnValue = MessageBoxDefaultButton.Button2;
			this.bHasReturnValue = true;
			this.Close();
		}

		private void MessageButton3_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
		{
			this.eReturnValue = MessageBoxDefaultButton.Button3;
			this.bHasReturnValue = true;
			this.Close();
		}

		#region No owner Window methods
		/// <summary>Displays a Message Box dialog with specified text</summary>
		public static MessageBoxResult Show(string text)
		{
			return MessageBox.Show(text, String.Empty, MessageBoxIcon.None, MessageBoxButtons.OK, MessageBoxDefaultButton.None);
		}

		/// <summary>Displays a Message Box dialog with specified text and title</summary>
		public static MessageBoxResult Show(string text, string title)
		{
			return MessageBox.Show(text, title, MessageBoxIcon.None, MessageBoxButtons.OK, MessageBoxDefaultButton.None);
		}

		/// <summary>Displays a Message Box dialog with specified text, title, and bitmap</summary>
		public static MessageBoxResult Show(string text, string title, MessageBoxIcon icon)
		{
			return MessageBox.Show(text, title, icon, MessageBoxButtons.OK, MessageBoxDefaultButton.None);
		}

		/// <summary>Displays a Message Box dialog with specified text, title, and custon bitmap</summary>
		public static MessageBoxResult Show(string text, string title, Bitmap icon)
		{
			return MessageBox.Show(text, title, icon, MessageBoxButtons.OK, MessageBoxDefaultButton.None);
		}

		/// <summary>Displays a Message Box dialog with specified text, title, and style</summary>
		public static MessageBoxResult Show(string text, string title, MessageBoxButtons buttons)
		{
			return MessageBox.Show(text, title, MessageBoxIcon.None, buttons, MessageBoxDefaultButton.None);
		}

		/// <summary>Displays a Message Box dialog with specified text, title, and style</summary>
		public static MessageBoxResult Show(string text, string title,
			MessageBoxIcon icon, MessageBoxButtons buttons)
		{
			return MessageBox.Show(text, title, icon, buttons, MessageBoxDefaultButton.None);
		}

		/// <summary>Displays a Message Box dialog with specified text, title, custom bitmap and style</summary>
		public static MessageBoxResult Show(string text, string title,
			Bitmap bitmap, MessageBoxButtons buttons)
		{
			return MessageBox.Show(text, title, bitmap, buttons, MessageBoxDefaultButton.None);
		}

		/// <summary>Displays a Message Box dialog with specified text, title and selected style</summary>
		public static MessageBoxResult Show(string text, string title,
			MessageBoxIcon icon, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
		{
			Bitmap? iconBitmap = null;
			WindowIcon? windowIcon = null;

			switch (icon)
			{
				case MessageBoxIcon.Stop:
					iconBitmap = new Bitmap(new MemoryStream(UI.MessageBoxResources.Stop_64));
					windowIcon = new WindowIcon(new MemoryStream(UI.MessageBoxResources.Stop));
					break;

				case MessageBoxIcon.Question:
					iconBitmap = new Bitmap(new MemoryStream(UI.MessageBoxResources.Question_64));
					windowIcon = new WindowIcon(new MemoryStream(UI.MessageBoxResources.Question));
					break;

				case MessageBoxIcon.Warning:
					iconBitmap = new Bitmap(new MemoryStream(UI.MessageBoxResources.Warning_64));
					windowIcon = new WindowIcon(new MemoryStream(UI.MessageBoxResources.Warning));
					break;

				case MessageBoxIcon.Information:
					iconBitmap = new Bitmap(new MemoryStream(UI.MessageBoxResources.Information_64));
					windowIcon = new WindowIcon(new MemoryStream(UI.MessageBoxResources.Information));
					break;
			}

			return MessageBox.ShowInternal(null, text, title, iconBitmap, windowIcon, buttons, defaultButton);
		}

		/// <summary>Displays a Message Box dialog with specified text, title, custom bitmap and selected style</summary>
		public static MessageBoxResult Show(string text, string title,
			Bitmap bitmap, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
		{
			return MessageBox.ShowInternal(null, text, title, bitmap, null, buttons, defaultButton);
		}
		#endregion

		#region Has parent Windows methods
		/// <summary>Displays a Message Box dialog with specified text</summary>
		public static MessageBoxResult Show(Window owner, string text)
		{
			return MessageBox.Show(owner, text, String.Empty, MessageBoxIcon.None, MessageBoxButtons.OK, MessageBoxDefaultButton.None);
		}

		/// <summary>Displays a Message Box dialog with specified text and title</summary>
		public static MessageBoxResult Show(Window owner, string text, string title)
		{
			return MessageBox.Show(owner, text, title, MessageBoxIcon.None, MessageBoxButtons.OK, MessageBoxDefaultButton.None);
		}

		/// <summary>Displays a Message Box dialog with specified text, title, and bitmap</summary>
		public static MessageBoxResult Show(Window owner, string text, string title, MessageBoxIcon icon)
		{
			return MessageBox.Show(owner, text, title, icon, MessageBoxButtons.OK, MessageBoxDefaultButton.None);
		}

		/// <summary>Displays a Message Box dialog with specified text, title, and custon bitmap</summary>
		public static MessageBoxResult Show(Window owner, string text, string title, Bitmap icon)
		{
			return MessageBox.Show(owner, text, title, icon, MessageBoxButtons.OK, MessageBoxDefaultButton.None);
		}

		/// <summary>Displays a Message Box dialog with specified text, title, and style</summary>
		public static MessageBoxResult Show(Window owner, string text, string title, MessageBoxButtons buttons)
		{
			return MessageBox.Show(owner, text, title, MessageBoxIcon.None, buttons, MessageBoxDefaultButton.None);
		}

		/// <summary>Displays a Message Box dialog with specified text, title, and style</summary>
		public static MessageBoxResult Show(Window owner, string text, string title,
			MessageBoxIcon icon, MessageBoxButtons buttons)
		{
			return MessageBox.Show(owner, text, title, icon, buttons, MessageBoxDefaultButton.None);
		}

		/// <summary>Displays a Message Box dialog with specified text, title, custom bitmap and style</summary>
		public static MessageBoxResult Show(Window owner, string text, string title,
			Bitmap bitmap, MessageBoxButtons buttons)
		{
			return MessageBox.Show(owner, text, title, bitmap, buttons, MessageBoxDefaultButton.None);
		}

		/// <summary>Displays a Message Box dialog with specified text, title and selected style</summary>
		public static MessageBoxResult Show(Window owner, string text, string title,
			MessageBoxIcon icon, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
		{
			Bitmap? bitmap = null;
			WindowIcon? windowIcon = null;

			switch (icon)
			{
				case MessageBoxIcon.Stop:
					bitmap = new Bitmap(new MemoryStream(UI.MessageBoxResources.Stop_64));
					windowIcon = new WindowIcon(new MemoryStream(UI.MessageBoxResources.Stop));
					break;

				case MessageBoxIcon.Question:
					bitmap = new Bitmap(new MemoryStream(UI.MessageBoxResources.Question_64));
					windowIcon = new WindowIcon(new MemoryStream(UI.MessageBoxResources.Question));
					break;

				case MessageBoxIcon.Warning:
					bitmap = new Bitmap(new MemoryStream(UI.MessageBoxResources.Warning_64));
					windowIcon = new WindowIcon(new MemoryStream(UI.MessageBoxResources.Warning));
					break;

				case MessageBoxIcon.Information:
					bitmap = new Bitmap(new MemoryStream(UI.MessageBoxResources.Information_64));
					windowIcon = new WindowIcon(new MemoryStream(UI.MessageBoxResources.Information));
					break;
			}

			return MessageBox.ShowInternal(owner, text, title, bitmap, windowIcon, buttons, defaultButton);
		}

		/// <summary>Displays a Message Box dialog with specified text, title, custom bitmap and selected style</summary>
		public static MessageBoxResult Show(Window owner, string text, string title,
			Bitmap icon, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
		{
			return MessageBox.ShowInternal(owner, text, title, icon, null, buttons, defaultButton);
		}

		private static MessageBoxResult ShowInternal(Window? owner, string text, string title,
			Bitmap? bitmap, WindowIcon? icon, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
		{
			MessageBox messageBox = new MessageBox();

			if (icon == null)
			{
				messageBox.Icon = new WindowIcon(new MemoryStream(UI.MessageBoxResources.Information));
			}
			else
			{
				messageBox.Icon = icon;
			}

			messageBox.Title = title;

			if (bitmap != null)
			{
				messageBox.messageIcon.Source = bitmap;
			}

			messageBox.messageText.Text = text;

			switch (buttons)
			{
				case MessageBoxButtons.OK:
					messageBox.messageButton1.IsVisible = false;
					messageBox.messageButton2.IsVisible = false;
					messageBox.messageButton3.Content = "OK";
					
					messageBox.messageButton3.IsDefault = true;
					break;

				case MessageBoxButtons.OKCancel:
					messageBox.messageButton1.IsVisible = false;
					messageBox.messageButton2.Content = "OK";
					messageBox.messageButton3.Content = "Cancel";

					switch(defaultButton)
					{
						case MessageBoxDefaultButton.Button1:
							messageBox.messageButton2.IsDefault = true;
							break;

						case MessageBoxDefaultButton.Button2:
							messageBox.messageButton3.IsDefault = true;
							break;
					}
					break;

				case MessageBoxButtons.AbortRetryIgnore:
					messageBox.messageButton1.Content = "Abort";
					messageBox.messageButton2.Content = "Retry";
					messageBox.messageButton3.Content = "Ignore";

					switch (defaultButton)
					{
						case MessageBoxDefaultButton.Button1:
							messageBox.messageButton1.IsDefault = true;
							break;

						case MessageBoxDefaultButton.Button2:
							messageBox.messageButton2.IsDefault = true;
							break;

						case MessageBoxDefaultButton.Button3:
							messageBox.messageButton3.IsDefault = true;
							break;
					}
					break;

				case MessageBoxButtons.YesNoCancel:
					messageBox.messageButton1.Content = "Yes";
					messageBox.messageButton2.Content = "No";
					messageBox.messageButton3.Content = "Cancel";

					switch (defaultButton)
					{
						case MessageBoxDefaultButton.Button1:
							messageBox.messageButton1.IsDefault = true;
							break;

						case MessageBoxDefaultButton.Button2:
							messageBox.messageButton2.IsDefault = true;
							break;

						case MessageBoxDefaultButton.Button3:
							messageBox.messageButton3.IsDefault = true;
							break;
					}
					break;

				case MessageBoxButtons.YesNo:
					messageBox.messageButton1.IsVisible = false;
					messageBox.messageButton2.Content = "Yes";
					messageBox.messageButton3.Content = "No";

					switch (defaultButton)
					{
						case MessageBoxDefaultButton.Button1:
							messageBox.messageButton2.IsDefault = true;
							break;

						case MessageBoxDefaultButton.Button2:
							messageBox.messageButton3.IsDefault = true;
							break;
					}
					break;

				case MessageBoxButtons.RetryCancel:
					messageBox.messageButton1.IsVisible = false;
					messageBox.messageButton2.Content = "Retry";
					messageBox.messageButton3.Content = "Cancel";
					
					switch (defaultButton)
					{
						case MessageBoxDefaultButton.Button1:
							messageBox.messageButton2.IsDefault = true;
							break;

						case MessageBoxDefaultButton.Button2:
							messageBox.messageButton3.IsDefault = true;
							break;
					}
					break;

				case MessageBoxButtons.CancelTryContinue:
					messageBox.messageButton1.Content = "Cancel";
					messageBox.messageButton2.Content = "Try Again";
					messageBox.messageButton3.Content = "Continue";

					switch (defaultButton)
					{
						case MessageBoxDefaultButton.Button1:
							messageBox.messageButton1.IsDefault = true;
							break;

						case MessageBoxDefaultButton.Button2:
							messageBox.messageButton2.IsDefault = true;
							break;

						case MessageBoxDefaultButton.Button3:
							messageBox.messageButton3.IsDefault = true;
							break;
					}
					break;
			}

			if (owner == null)
			{
				messageBox.WindowStartupLocation = WindowStartupLocation.CenterScreen;
				messageBox.Show();

				while (!messageBox.HasValue)
				{
					try
					{
						var s = new CancellationTokenSource();
						DispatcherTimer.RunOnce(() => s.Cancel(), TimeSpan.FromMilliseconds(20));
						Dispatcher.UIThread.MainLoop(s.Token);
					}
					catch { }
				}
			}
			else
			{
				Task task = messageBox.ShowDialog(owner);
				while (!task.IsCompleted)
				{
					var s = new CancellationTokenSource();
					DispatcherTimer.RunOnce(() => s.Cancel(), TimeSpan.FromMilliseconds(20));
					Dispatcher.UIThread.MainLoop(s.Token);
				}
			}

			MessageBoxDefaultButton result = messageBox.ReturnValue;

			switch (buttons)
			{
				case MessageBoxButtons.OK:
					switch (result)
					{
						case MessageBoxDefaultButton.Button3:
							return MessageBoxResult.OK;
					}
					return MessageBoxResult.None;

				case MessageBoxButtons.OKCancel:
					switch (result)
					{
						case MessageBoxDefaultButton.Button2:
							return MessageBoxResult.OK;

						case MessageBoxDefaultButton.Button3:
							return MessageBoxResult.Cancel;
					}
					return MessageBoxResult.None;

				case MessageBoxButtons.AbortRetryIgnore:
					switch (result)
					{
						case MessageBoxDefaultButton.Button1:
							return MessageBoxResult.Abort;

						case MessageBoxDefaultButton.Button2:
							return MessageBoxResult.Retry;

						case MessageBoxDefaultButton.Button3:
							return MessageBoxResult.Ignore;
					}
					return MessageBoxResult.None;

				case MessageBoxButtons.YesNoCancel:
					switch (result)
					{
						case MessageBoxDefaultButton.Button1:
							return MessageBoxResult.Yes;

						case MessageBoxDefaultButton.Button2:
							return MessageBoxResult.No;

						case MessageBoxDefaultButton.Button3:
							return MessageBoxResult.Cancel;
					}
					return MessageBoxResult.None;

				case MessageBoxButtons.YesNo:
					switch (result)
					{
						case MessageBoxDefaultButton.Button2:
							return MessageBoxResult.Yes;

						case MessageBoxDefaultButton.Button3:
							return MessageBoxResult.No;
					}
					return MessageBoxResult.None;

				case MessageBoxButtons.RetryCancel:
					switch (result)
					{
						case MessageBoxDefaultButton.Button2:
							return MessageBoxResult.Retry;

						case MessageBoxDefaultButton.Button3:
							return MessageBoxResult.Cancel;
					}
					return MessageBoxResult.None;

				case MessageBoxButtons.CancelTryContinue:
					switch (result)
					{
						case MessageBoxDefaultButton.Button1:
							return MessageBoxResult.Cancel;

						case MessageBoxDefaultButton.Button2:
							return MessageBoxResult.TryAgain;

						case MessageBoxDefaultButton.Button3:
							return MessageBoxResult.Continue;
					}
					return MessageBoxResult.None;
			}

			return MessageBoxResult.None;
		}
		#endregion
	}
}
