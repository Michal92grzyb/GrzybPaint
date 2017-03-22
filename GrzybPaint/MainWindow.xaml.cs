using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace GrzybPaint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region constructor
        public MainWindow()
        {
            InitializeComponent();
            // ...
            SettingsInfo.ReadColor();
        }
        #endregion

        #region ClickButton
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // To też nie powinno być w code-behind.
            this.inkCanvas1.Strokes.Clear();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // To jest najgorsza rzecz, jaką mogłem zrobić.
            // SettingsInfo.SaveColor(new Model.DrawingColor((byte)SliderR.Value, (byte)SliderG.Value, (byte)SliderB.Value));
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Też trzeba wyrzucić do viewmodel (i SaveFileDialog do modelu?)
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "savedimage"; // Default file name
            dlg.DefaultExt = ".jpg"; // Default file extension
            dlg.Filter = "Image (.jpg)|*.jpg"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                //get the dimensions of the ink control
                int margin = (int)this.inkCanvas1.Margin.Left;
                int width = (int)this.inkCanvas1.ActualWidth - margin;
                int height = (int)this.inkCanvas1.ActualHeight - margin;
                //render ink to bitmap
                RenderTargetBitmap rtb =
                new RenderTargetBitmap(width, height, 96d, 96d, PixelFormats.Default);
                rtb.Render(inkCanvas1);

                // TODO: obsługa błędów przy pliku

                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(rtb));
                    encoder.Save(fs);
                }
            }
        }

        private void ConfigurationButton_Click(object sender, RoutedEventArgs e)
        {
            // Brak pomysłów na wyrzucenie tego.
            // Nie wiem, jak robić, żeby pierwsze okno było spowrotem aktywne po wyłączeniu tego. Coś z window.parent, czy jakoś tak.

            Window configurationWindow = new ConfigurationWindow();
            configurationWindow.Show();
            //this.IsEnabled = false;
            configurationWindow.Topmost = true;
            //configurationWindow.Focus();
        }
#endregion
    }
}
