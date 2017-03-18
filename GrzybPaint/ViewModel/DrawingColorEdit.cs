using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrzybPaint.ViewModel
{
    using Model;
    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Windows.Media;
    public class DrawingColorEdit : INotifyPropertyChanged
    {
        private readonly DrawingColor drawingColor = new DrawingColor(0,0,0);

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

        public Color Color
        {
            get
            {
                return drawingColor.ToColor();
            }
        }

        
    }

    static class Extensions
    {
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
