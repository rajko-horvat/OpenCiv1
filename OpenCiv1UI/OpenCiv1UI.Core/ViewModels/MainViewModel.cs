using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Size = System.Drawing.Size;
using Rectangle = System.Drawing.Rectangle;
using Point = System.Drawing.Point;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IRB.Collections.Generic;
using OpenCiv1;
using OpenCiv1.Contracts;
using OpenCiv1.Exceptions;
using OpenCiv1.GPU;
using OpenCiv1UI.Core.Services.Contracts;
using Brushes = Avalonia.Media.Brushes;
using FontFamily = Avalonia.Media.FontFamily;

namespace OpenCiv1UI.Core.ViewModels;

public partial class MainViewModel : ViewModelBase, IMainForm
{
    private DispatcherTimer _timerRefresh;

    [ObservableProperty]
    private IBrush _background = Brushes.Black;

    [ObservableProperty]
    private WriteableBitmap _bitmap;

    [ObservableProperty]
    private FontFamily _fontFamily = new FontFamily("Inter");

    private bool bClosing = false;
    private Thread? oGameThread = null;
    private OpenCiv1.OpenCiv1? oGame = null;
    private Size oScreenSize;
    private Rectangle oMouseRect = new();
    private Point oMouseLocation = default;
    private MouseButton oMouseButtons;
    private int iScreenColumns = 1;
    private int iScreenRows = 1;

    private const int Width = 320;
    private const int Height = 200;

    [ObservableProperty]
    private MessageBoxViewModel _messageBoxViewModel = new();
    
    public IDialogService DialogService { get; private set; }

    public MainViewModel(IDialogService dialogService)
    {
        DialogService = dialogService;
        Bitmap = new WriteableBitmap(new PixelSize(Width, Height), new Vector(96, 96), PixelFormat.Bgra8888, AlphaFormat.Opaque);
        _timerRefresh = new DispatcherTimer();
        _timerRefresh.Interval = TimeSpan.FromMilliseconds(50);
        _timerRefresh.Tick += tmrRefresh_Tick;
        _timerRefresh.IsEnabled = true;
        _timerRefresh.Start();
    }

    private void tmrRefresh_Tick(object? sender, EventArgs e)
    {
        if (this.oGame != null && this.oGame.VGADriver != null)
        {
            lock (this.oGame.VGADriver.VGALock)
            {
                RedrawScreens(Bitmap, false);
            }
        }
    }

    public Point ScreenMouseLocation
    {
        get { return this.oMouseLocation; }
    }

    public MouseButton ScreenMouseButtons
    {
        get { return this.oMouseButtons; }
    }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(PauseCommand))]
    private bool _canPause;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(RunCommand))]
    private bool _canRun;

    [ObservableProperty]
    private bool _AreScreensEnabled;

    private void InitializeControlsMethod()
    {
        ScreenCountChangeMethod();

        CanPause = true;
        CanRun = true;
        AreScreensEnabled = true;
    }

    public void OnScreenCountChange()
    {
        ScreenCountChangeMethod();
    }

    [ObservableProperty]
    private string _labelScreens = "";

    [ObservableProperty]
    private AvaloniaList<BKeyValuePair<int, VGABitmap>> _screens = new();

    [RelayCommand]
    private void Pause() {
        
    }
    
    [RelayCommand]
    private void Run() {
        
    }

    private void ScreenCountChangeMethod()
    {
        if (this.oGame != null && this.oGame.VGADriver != null)
        {
            lock (this.oGame.VGADriver.VGALock)
            {
                int iScreenCount = 0;
                // update screen list
                this.LabelScreens = $"Screens ({this.oGame.VGADriver.Screens.Count})";

                Screens.Clear();

                for (int i = 0; i < this.oGame.VGADriver.Screens.Count; i++)
                {
                    BKeyValuePair<int, VGABitmap> item = this.oGame.VGADriver.Screens[i];

                    //ToolStripMenuItem menuItem = new ToolStripMenuItem($"Screen ({item.Key})");
                    //menuItem.Checked = true;
                    //menuItem.CheckState = item.Value.Visible ? CheckState.Checked : CheckState.Unchecked;
                    //menuItem.Tag = item.Key;
                    //menuItem.CheckOnClick = true;
                    //menuItem.Click += MenuItem_Clicked;

                    //this.tsScreens.DropDownItems.Add(menuItem);

                    if (item.Value.Visible)
                    {
                        iScreenCount++;
                    }
                }

                switch (iScreenCount)
                {
                    case 1:
                        this.iScreenColumns = 1;
                        this.iScreenRows = 1;
                        this.oScreenSize = new Size(640, 400);
                        break;

                    case 2:
                        this.iScreenColumns = 2;
                        this.iScreenRows = 1;
                        this.oScreenSize = new Size(320, 200);
                        break;

                    case 3:
                        this.iScreenColumns = 2;
                        this.iScreenRows = 2;
                        this.oScreenSize = new Size(320, 200);
                        break;

                    case 4:
                        this.iScreenColumns = 2;
                        this.iScreenRows = 2;
                        this.oScreenSize = new Size(320, 200);
                        break;

                    case 5:
                        this.iScreenColumns = 3;
                        this.iScreenRows = 2;
                        this.oScreenSize = new Size(320, 200);
                        break;

                    case 6:
                        this.iScreenColumns = 3;
                        this.iScreenRows = 2;
                        this.oScreenSize = new Size(320, 200);
                        break;

                    case 7:
                        this.iScreenColumns = 3;
                        this.iScreenRows = 3;
                        this.oScreenSize = new Size(320, 200);
                        break;

                    case 8:
                        this.iScreenColumns = 3;
                        this.iScreenRows = 3;
                        this.oScreenSize = new Size(320, 200);
                        break;
                }
                // this.ClientSize = new Size(this.oScreenSize.Width * this.iScreenColumns + 1 + this.iScreenColumns,
                //     this.tsMain.Height + this.oScreenSize.Height * this.iScreenRows + 1 + this.iScreenRows);
                this.oMouseRect = new Rectangle(Point.Empty, this.oScreenSize);
            }
        }
        else
        {
            this.iScreenColumns = 1;
            this.iScreenRows = 1;
            this.oScreenSize = new Size(640, 400);

            //this.ClientSize = new Size(this.oScreenSize.Width * this.iScreenColumns + 1 + this.iScreenColumns,
            //    this.tsMain.Height + this.oScreenSize.Height * this.iScreenRows + 1 + this.iScreenRows);
            this.oMouseRect = new Rectangle(Point.Empty, this.oScreenSize);
        }
    }

    public event EventHandler CloseMainForm;

    private void MenuItem_Clicked(object? sender, EventArgs e)
    {
        if (sender != null)
        {
            //ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            //int iScreen = Convert.ToInt32(menuItem.Tag);

            if (this.oGame != null && this.oGame.VGADriver != null)
            {
                //if (this.oGame.VGADriver.Screens.ContainsKey(iScreen))
                //{
                //    VGABitmap screen = this.oGame.VGADriver.Screens.GetValueByKey(iScreen);
                //    screen.Visible = !screen.Visible;
                //    OnScreenCountChange();
                //}
            }
        }
    }

    private void RedrawScreens(WriteableBitmap bitmap, bool forceRedraw)
    {
        int iColumn = 0;
        int iRow = 0;

        if (this.oGame != null)
        {
            //g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.AssumeLinear;
            //bitmap.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            for (int i = 0; i < this.oGame.VGADriver.Screens.Count; i++)
            {
                BKeyValuePair<int, VGABitmap> item = this.oGame.VGADriver.Screens[i];

                if (item.Value.Visible)
                {
                    if (item.Value.Modified || forceRedraw)
                    {
                        //Rectangle rect = new Rectangle((iColumn * this.oScreenSize.Width) + (iColumn + 1),
                        //    this.tsMain.Height + (iRow * this.oScreenSize.Height) + (iRow + 1),
                        //    this.oScreenSize.Width, this.oScreenSize.Height);
                        //bitmap.DrawImage(item.Value.Bitmap, rect);
                        //bitmap.DrawString($"{item.Key}", this.oFont, Brushes.White, rect.Left + 5.0f, rect.Top + 5.0f);
                        //bitmap.DrawRectangle(Pens.Purple, (iColumn * this.oScreenSize.Width) + iColumn,
                        //    this.tsMain.Height + (iRow * this.oScreenSize.Height) + iRow,
                        //    this.oScreenSize.Width + 1, this.oScreenSize.Height + 1);

                        item.Value.Modified = false;
                    }

                    iColumn++;
                    if (iColumn >= this.iScreenColumns)
                    {
                        iColumn = 0;
                        iRow++;
                    }
                }
            }

            if (this.oGame.VGADriver.CPU.Pause)
            {
                string sTemp = "Game paused";
                //SizeF size = bitmap.MeasureString(sTemp, this.oLargeFont);
                //bitmap.DrawString(sTemp, this.oLargeFont, Brushes.White,
                //    (float)((this.oScreenSize.Width * this.iScreenColumns) - size.Width) / 2.0f,
                //    (float)((this.oScreenSize.Height * this.iScreenRows) - size.Height) / 2.0f);
            }
        }
    }

    private void Form_KeyPress(object sender, KeyEventArgs e)
    {
        if (this.oGame != null)
        {
            lock (this.oGame.VGADriver.VGALock)
            {
                this.oGame.VGADriver.Keys.Enqueue((int)e.PhysicalKey);
            }
        }
    }

    private void Form_KeyDown(object sender, KeyEventArgs e)
    {
        if (this.oGame != null)
        {
            lock (this.oGame.VGADriver.VGALock)
            {
                if (e.KeyModifiers == KeyModifiers.None)
                {
                    switch (e.Key)
                    {
                        case Key.NumPad0:
                            // for testing
                            this.oGame.VGADriver.Keys.Enqueue(0x475c);
                            break;

                        case Key.F1:
                            this.oGame.VGADriver.Keys.Enqueue(0x3b00);
                            break;

                        case Key.F2:
                            this.oGame.VGADriver.Keys.Enqueue(0x3c00);
                            break;

                        case Key.F3:
                            this.oGame.VGADriver.Keys.Enqueue(0x3d00);
                            break;

                        case Key.F4:
                            this.oGame.VGADriver.Keys.Enqueue(0x3e00);
                            break;

                        case Key.F5:
                            this.oGame.VGADriver.Keys.Enqueue(0x3f00);
                            break;

                        case Key.F6:
                            this.oGame.VGADriver.Keys.Enqueue(0x4000);
                            break;

                        case Key.F7:
                            this.oGame.VGADriver.Keys.Enqueue(0x4100);
                            break;

                        case Key.F8:
                            this.oGame.VGADriver.Keys.Enqueue(0x4200);
                            break;

                        case Key.F9:
                            this.oGame.VGADriver.Keys.Enqueue(0x4300);
                            break;

                        case Key.F10:
                            this.oGame.VGADriver.Keys.Enqueue(0x4400);
                            break;

                        case Key.Down:
                            this.oGame.VGADriver.Keys.Enqueue(0x5000);
                            break;

                        case Key.Left:
                            this.oGame.VGADriver.Keys.Enqueue(0x4b00);
                            break;

                        case Key.Right:
                            this.oGame.VGADriver.Keys.Enqueue(0x4d00);
                            break;

                        case Key.Up:
                            this.oGame.VGADriver.Keys.Enqueue(0x4800);
                            break;

                        case Key.Home:
                            this.oGame.VGADriver.Keys.Enqueue(0x4700);
                            break;

                        case Key.End:
                            this.oGame.VGADriver.Keys.Enqueue(0x4f00);
                            break;

                        case Key.PageUp:
                            this.oGame.VGADriver.Keys.Enqueue(0x4900);
                            break;

                        case Key.PageDown:
                            this.oGame.VGADriver.Keys.Enqueue(0x5100);
                            break;
                    }
                }
                else if ((e.KeyModifiers & KeyModifiers.Shift) == KeyModifiers.Shift)
                {
                    switch (e.Key)
                    {
                        case Key.Down:
                            this.oGame.VGADriver.Keys.Enqueue(0x5032);
                            break;

                        case Key.Left:
                            this.oGame.VGADriver.Keys.Enqueue(0x4b34);
                            break;

                        case Key.Right:
                            this.oGame.VGADriver.Keys.Enqueue(0x4d36);
                            break;

                        case Key.Up:
                            this.oGame.VGADriver.Keys.Enqueue(0x4838);
                            break;

                        case Key.Home:
                            this.oGame.VGADriver.Keys.Enqueue(0x4737);
                            break;

                        case Key.End:
                            this.oGame.VGADriver.Keys.Enqueue(0x4f31);
                            break;

                        case Key.PageUp:
                            this.oGame.VGADriver.Keys.Enqueue(0x4939);
                            break;

                        case Key.PageDown:
                            this.oGame.VGADriver.Keys.Enqueue(0x5133);
                            break;
                    }
                }
                else if ((e.KeyModifiers & KeyModifiers.Alt) == KeyModifiers.Alt)
                {
                    e.Handled = true;

                    switch (e.Key)
                    {
                        case Key.A:
                            this.oGame.VGADriver.Keys.Enqueue(0x1e00);
                            break;

                        case Key.C:
                            this.oGame.VGADriver.Keys.Enqueue(0x2e00);
                            break;

                        case Key.D:
                            this.oGame.VGADriver.Keys.Enqueue(0x2000);
                            break;

                        case Key.G:
                            this.oGame.VGADriver.Keys.Enqueue(0x2200);
                            break;

                        case Key.H:
                            this.oGame.VGADriver.Keys.Enqueue(0x2300);
                            break;

                        case Key.M:
                            this.oGame.VGADriver.Keys.Enqueue(0x3200);
                            break;

                        case Key.O:
                            this.oGame.VGADriver.Keys.Enqueue(0x1800);
                            break;

                        case Key.Q:
                            this.oGame.VGADriver.Keys.Enqueue(0x1000);
                            break;

                        case Key.R:
                            this.oGame.VGADriver.Keys.Enqueue(0x1300);
                            break;

                        case Key.V:
                            this.oGame.VGADriver.Keys.Enqueue(0x2f00);
                            break;

                        case Key.W:
                            this.oGame.VGADriver.Keys.Enqueue(0x1100);
                            break;
                    }
                }
            }
        }
    }

    private void Form_MouseMove(object sender, PointerEventArgs e)
    {
        //Point location = new Point(e.Location.X, e.Location.Y - this.tsMain.Height);

        //if (this.oMouseRect.Contains(location))
        //{
        //    this.oMouseLocation = new Point(location.X / (this.oScreenSize.Width / 320),
        //        location.Y / (this.oScreenSize.Height / 200));
        //    this.oMouseButtons = e.Button;
        //}
    }

    private void Form_MouseDown(object sender, PointerEventArgs e)
    {
        //if (e.Button == MouseButtons.Left)
        //{
        //    this.oMouseButtons |= MouseButtons.Left;
        //}
        //else if (e.Button == MouseButtons.Right)
        //{
        //    this.oMouseButtons |= MouseButtons.Right;
        //}
    }

    private void Form_MouseUp(object sender, PointerEventArgs e)
    {
        //if (e.Button == MouseButtons.Left)
        //{
        //    this.oMouseButtons |= MouseButtons.Left;
        //    this.oMouseButtons ^= MouseButtons.Left;
        //}
        //else if (e.Button == MouseButtons.Right)
        //{
        //    this.oMouseButtons |= MouseButtons.Right;
        //    this.oMouseButtons ^= MouseButtons.Right;
        //}
    }

    private void cmdPause_Click(object sender, EventArgs e)
    {
        if (this.oGame != null && this.oGame.CPU != null)
        {
            if (!this.oGame.VGADriver.CPU.Pause)
            {
                this.oGame.VGADriver.CPU.Pause = true;
                CanPause = false;
                CanRun = true;

                lock (this.oGame.VGADriver.VGALock)
                {
                    RedrawScreens(Bitmap, true);
                }
            }
        }
    }

    private void cmdRun_Click(object sender, EventArgs e)
    {
        if (this.oGame != null && this.oGame.CPU != null)
        {
            if (this.oGame.VGADriver.CPU.Pause)
            {
                this.oGame.VGADriver.CPU.Pause = false;
                CanPause = true;
                CanRun = false;

                lock (this.oGame.VGADriver.VGALock)
                {
                    RedrawScreens(Bitmap, true);
                }
            }
        }
    }

    internal async Task OnMainFormLoaded()
    {
//#if !DEBUG
        await DialogService.ShowAsync("This Alpha Release of OpenCiv1 (OpenCiv1) project " +
			"most certainly has bugs, but most functions should work normally, and has no sound at this point. " +
			"It is compatible with old civ.exe and can save/load original game files.\n" +
			"The Debug mode can be toggled by pressing Alt + D Key.\n\n" +
			"Technicalities:\n\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR " +
			"IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, " +
			"FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE " +
			"AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER " +
			"LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, " +
			"OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.",
			"Warning");
//#endif
        if (this.oGameThread == null)
        {
            this.oGameThread = new Thread(new ThreadStart(GameThread));
            this.oGameThread.Start();
        }
    }

    private void GameThread()
    {
        try
        {
            this.oGame = new OpenCiv1.OpenCiv1(this);

            this.InitializeControlsMethod();

            this.oGame.Start();
        }
        catch (ApplicationExitException)
        {
        }
        catch (ResourceMissingExitException ex)
        {
            //MessageBox.Show(ex.Message, "OpenCiv1 resource error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
#if !DEBUG
			catch (Exception e)
			{
				if (this.oGame != null && this.oGame.Log != null)
				{
					this.oGame.Log.WriteLine("");
					this.oGame.Log.WriteLine($"Exception message: {e.Message}");
					this.oGame.Log.WriteLine($"Exception source: {e.Source}");
					this.oGame.Log.WriteLine($"Exception stack trace: {e.StackTrace}");
				}

				MessageBox.Show("There was an error (Exception) in the OpenCiv1 application, "+
					"the details about the error should be in a Log.txt file.");
			}
#endif
        if (!this.bClosing)
        {
            this.bClosing = true;
            try
            {
                this.CloseMainForm?.Invoke(this, EventArgs.Empty);
            }
            catch
            {
                Environment.FailFast("emergency exit");
            }
        }
    }

    private void MainForm_FormClosing(object sender, WindowClosingEventArgs e)
    {
        if (this.bClosing
            // ||
            //MessageBox.Show("Are you sure you want to quit?", "Exiting application",
            //    MessageBoxButtons.OKCancel, 
            //    MessageBoxIcon.Question,
            //    MessageBoxDefaultButton.Button2) ==
            //DialogResult.OK)
            )
        {
            this.bClosing = true;

            if (this.oGame != null && this.oGame.CPU != null)
            {
                this.oGame.CPU.OnApplicationExit();
                if (oGameThread?.IsAlive == true)
                {
                    oGameThread?.Join();
                }
            }
        }
        else
        {
            e.Cancel = true;
        }
    }
}
