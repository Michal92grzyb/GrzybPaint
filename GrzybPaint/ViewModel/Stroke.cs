using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Ink;
using System.Windows.Input;
using System.Collections.Specialized;

namespace GrzybPaint.ViewModel
{
    // do napisania od nowa, nic tu nie działa

    public class StrokeEdit : INotifyPropertyChanged
    {
        public StrokeCollection Signature {
            get;
            set;
        }

        //a jakby czyścić canvas, zbierając wszystkie stroke i zwracając je do inkCanvas tylko, że w kolorze białym?


           
        private readonly StrokeCollection signature;

        public event PropertyChangedEventHandler PropertyChanged;

        public StrokeEdit()
        {
            Signature = new StrokeCollection();

            Signature.StrokesChanged += Signature_StrokesChanged;
        }

        private void OnPropertyChanged(params string[] names)
        {
            if (PropertyChanged != null)
            {
                foreach (string name in names)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        // nie działa, bo olewa działania
        void Signature_StrokesChanged(object sender, StrokeCollectionChangedEventArgs e)
        {
            int count = 0;
            var signatureMod = new StrokeCollection();
            foreach (var stroke in (System.Windows.Ink.StrokeCollection)sender)
            {
                var stylusColl = new StylusPointCollection();
                foreach (var stylusPoint in stroke.StylusPoints)
                {
                    if (count % 5 == 0)
                    {
                        stylusColl.Add(stylusPoint);
                    }
                    count++;
                }
                Stroke addedStroke = new Stroke(stylusColl);
                signatureMod.Add(addedStroke);
            }
            Signature = (StrokeCollection)sender;
            
        }
    }
}
