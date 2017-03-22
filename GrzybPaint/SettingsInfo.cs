using System;
using System.Collections.Generic;
using GrzybPaint.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrzybPaint
{
    public static class SettingsInfo
    {
        // wyglada, ze to dziala, teraz zapisac do mvvm.
        // może zamiast DrawingColor trzeba użyć Color, to nie będę musiał się tam odwoływać do modelu.
        public static DrawingColor ReadColor()
        {
            Properties.Settings settings = Properties.Settings.Default;
            return new DrawingColor(settings.R, settings.G, settings.B);
        }

        public static void SaveColor(DrawingColor drawingColor)
        {
            Properties.Settings settings = Properties.Settings.Default;
            settings.R = drawingColor.R;
            settings.G = drawingColor.G;
            settings.B = drawingColor.B;
            settings.Save();
        }
    }
}
