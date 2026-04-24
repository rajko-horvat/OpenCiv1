using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using IRB.Collections.Generic;
using OpenCiv1.UI;
using System.Text.Json;

namespace OpenCiv1;

/// <summary>
/// A dialog box that manages game names and game saves.
/// The concept is divided into two sections: 1) a game name, 2) game saves associated with that game
/// </summary>
public partial class LoadGameDialog : Window
{
	private bool windowClosed = false;
	private OpenCiv1Game? parent = null;
	private string gameListPath = "";
	private BDictionary<string, string> gameList = new();
	private BDictionary<string, GameData?> saveGameList = new();

	public LoadGameDialog()
    {
        InitializeComponent();
	}

	public LoadGameDialog(OpenCiv1Game game)
	{
		InitializeComponent();

		this.parent = game;
		this.gameListPath = $"{this.parent.SavePath}{Path.DirectorySeparatorChar}GameList.json";

		this.Closed += this.LoadGameDialog_Closed;
		this.lstGameNames.SelectionChanged += this.LstGameNames_SelectionChanged;
		this.lstGameSaves.SelectionChanged += this.LstGameSaves_SelectionChanged;

		RefreshGameList();
	}

	private void LstGameNames_SelectionChanged(object? sender, SelectionChangedEventArgs e)
	{
		if (!this.windowClosed)
		{
			int selectedGameIndex = this.lstGameNames.SelectedIndex;

			if (selectedGameIndex >= 0 && selectedGameIndex < this.gameList.Count)
			{
				string saveGameDirectory = $"{this.gameListPath}{Path.DirectorySeparatorChar}{this.gameList[selectedGameIndex].Key}";

				this.txtSaveGameListStatus.Text = "Please wait, loading save game data...";
				this.lstGameSaves.IsEnabled = false;
				this.lstGameSaves.Items.Clear();

				// If the assigned Save Game path does not exist, we will create it later if needed,
				// We just don't want to make an exception here
				if (Path.Exists(saveGameDirectory))
				{
					try
					{
						string[] saveGameFiles = Directory.GetFiles(saveGameDirectory, "*.sav");


					}
					catch { }
				}
			}
		}
	}

	private void LstGameSaves_SelectionChanged(object? sender, SelectionChangedEventArgs e)
	{
		
	}

	private void RefreshGameList()
	{
		if (!this.windowClosed)
		{
			this.btnImport.IsEnabled = false;
			this.btnLoad.IsEnabled = false;

			this.txtGameNameListStatus.Text = "Please wait, loading game data...";
			this.lstGameNames.IsEnabled = false;
			this.lstGameNames.Items.Clear();

			this.txtSaveGameListStatus.Text = ""; // "Please wait, loading save game data..."
			this.lstGameSaves.IsEnabled = false;
			this.lstGameSaves.Items.Clear();

			Task.Run(() =>
			{
				if (this.parent != null)
				{
					if (File.Exists(this.gameListPath))
					{
						try
						{
							BDictionary<string, string>? tempGameList = null;

							using (FileStream gameListStream = new(this.gameListPath, FileMode.Open, FileAccess.Read))
							{
								tempGameList = JsonSerializer.Deserialize<BDictionary<string, string>>(gameListStream);
							}

							if (tempGameList != null)
							{
								this.gameList = tempGameList;
							}
						}
						catch (Exception e)
						{
							MessageBox.Show(this, $"Can't read a game list from '{this.gameListPath}'\n\n{e.Message}", "Error", MessageBoxIcon.Error, MessageBoxButtons.OK);

							try
							{
								using (FileStream gameListStream = new(this.gameListPath, FileMode.Create, FileAccess.ReadWrite))
								{
									JsonSerializer.Serialize(gameListStream, this.gameList);
								}
							}
							catch (Exception e1)
							{
								MessageBox.Show(this, $"Can't write a new game list to '{this.gameListPath}'\n\n{e1.Message}", "Error", MessageBoxIcon.Error, MessageBoxButtons.OK);
							}
						}
					}
					else
					{
						try
						{
							using (FileStream gameListStream = new(this.gameListPath, FileMode.Create, FileAccess.ReadWrite))
							{
								JsonSerializer.Serialize(gameListStream, this.gameList);
							}
						}
						catch (Exception e)
						{
							MessageBox.Show(this, $"Can't write a new game list to '{this.gameListPath}'\n\n{e.Message}", "Error", MessageBoxIcon.Error, MessageBoxButtons.OK);
						}
					}

					Dispatcher.UIThread.Invoke(() => { PopulateGameNames(); });
				}
			});
		}
	}

	private void PopulateGameNames()
	{
		if (!this.windowClosed)
		{
			this.txtGameNameListStatus.Text = (this.gameList.Count == 0) ? "The game list is empty" : "Choose a game from the list";
			this.txtSaveGameListStatus.Text = (this.gameList.Count != 0) ? "Please select a game first" : "";

			for (int i = 0; i < this.gameList.Count; i++)
			{
				string saveGameDirectory = $"{this.gameListPath}{Path.DirectorySeparatorChar}{this.gameList[i].Key}";
				int saveGameCount = 0;

				// If the assigned Save Game path does not exist, we will create it later if needed,
				// We just don't want to make an exception here
				if (Path.Exists(saveGameDirectory))
				{
					try
					{
						string[] saveGameFiles = Directory.GetFiles(saveGameDirectory, "*.sav");

						saveGameCount = saveGameFiles.Length;
					}
					catch { }
				}

				TextBlock textBlock = new TextBlock();
				textBlock.VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center;
				textBlock.Text = $"{this.gameList[i].Value} ({saveGameCount} saved games)";

				this.lstGameNames.Items.Add(textBlock);
			}

			this.lstGameNames.SelectedIndex = -1;
			this.lstGameNames.IsEnabled = this.gameList.Count != 0;

			this.btnImport.IsEnabled = true;

			/*
				<ListBoxItem>
					<TextBlock VerticalAlignment="Center">Emperor Yellow (20 saved games)</TextBlock>
				</ListBoxItem>*/

			/*
				<ListBoxItem>
					<StackPanel Orientation="Horizontal">
						<Border BorderBrush="DarkGray" BorderThickness="1" CornerRadius="3" Margin="0 0 5 0">
							<Image Width="80" Height="50"></Image>
						</Border>
						<TextBlock VerticalAlignment="Center">Year 1000BC, Turn 10</TextBlock>
					</StackPanel>
				</ListBoxItem>
			*/
		}
	}

	private void LoadGameDialog_Closed(object? sender, EventArgs e)
	{
		this.windowClosed = true;
	}

	public bool IsClosed
	{
		get => windowClosed;
	}
}