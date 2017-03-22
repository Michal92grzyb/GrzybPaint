using GrzybPaint;

namespace GrzybPaint.ViewModel
{
    using Model;

    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Windows.Ink;
    using System.Windows.Input;
    using System.Windows.Media;
    public class DrawingColorEdit : INotifyPropertyChanged
    {
        // wczytanie danych przy wlaczeniu programu
        private readonly DrawingColor drawingColor = SettingsInfo.ReadColor();

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged (params string[] valueNames)
        {
            if ( PropertyChanged != null )
            {
                foreach(string valueName in valueNames)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(valueName));
                }
            }
        }

        #region RGBconstuctors
        public byte R
        {
            get
            {
                return drawingColor.R;
            }
            set
            {
                drawingColor.R = value;
                OnPropertyChanged("R", "Color");
            }
        }

        public byte G
        {
            get
            {
                return drawingColor.G;
            }
            set
            {
                drawingColor.G = value;
                OnPropertyChanged("G", "Color");
            }
        }

        public byte B
        {
            get
            {
                return drawingColor.B;
            }
            set
            {
                drawingColor.B = value;
                OnPropertyChanged("B", "Color");
            }
        }
        #endregion

        #region ColorAndCanvasConstructors
        public Color Color
        {
            get
            {
                canvas.DefaultDrawingAttributes.Color = drawingColor.ToColor(); // Dlaczego to działa?!
                return drawingColor.ToColor();
            }
        }

        private readonly InkCanvas canvas = new InkCanvas();

        public DrawingAttributes DrawingAttributes
        {
            get
            {
                return canvas.DefaultDrawingAttributes;
            }
        }
        #endregion
        
    }

    
    static class Extensions
    {
        /// <summary>
        /// Zamienia DrawingColor na parametr, ktory moze byc wykorzystany przez InkCanvas.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color ToColor(this DrawingColor color)
        {
            return new Color()
            {
                A = 255,
                R = color.R,
                G = color.G,
                B = color.B
            };
        }
    }
}
