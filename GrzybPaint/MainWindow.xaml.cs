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
        public MainWindow()
        {
            InitializeComponent();
            SliderC_ValueChanged(null, null);
            SliderM_ValueChanged(null, null);
            SliderY_ValueChanged(null, null);
        }

        private void inkCanvas1_Gesture(object sender, InkCanvasGestureEventArgs e)
        {
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            this.inkCanvas1.Strokes.Clear();
            MessageBox.Show("Canvas cleared.");
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("See ya!");
            this.Close();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
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

                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(rtb));
                    encoder.Save(fs);
                }
            }
        }

        private void SliderC_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TextBlockC.Text = Convert.ToString((byte)SliderC.Value);
            Slider_ValueChanged();
        }

        private void SliderM_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TextBlockM.Text = Convert.ToString((byte)SliderM.Value);
            Slider_ValueChanged();
        }

        private void SliderY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TextBlockY.Text = Convert.ToString((byte)SliderY.Value);
            Slider_ValueChanged();
        }

        private void Slider_ValueChanged()
        {
            Color drawingColor = Color.FromRgb((byte)SliderC.Value, (byte)SliderM.Value, (byte)SliderY.Value);
            ColorRectangle.Fill = new SolidColorBrush(drawingColor);
            inkCanvas1.DefaultDrawingAttributes.Color = drawingColor;
        }

        private void ConfigurationButton_Click(object sender, RoutedEventArgs e)
        {
            Window configurationWindow = new ConfigurationWindow();
            configurationWindow.Show();
            //this.IsEnabled = false;
            configurationWindow.Topmost = true;
            //configurationWindow.Focus();
        }
        
    }
}
