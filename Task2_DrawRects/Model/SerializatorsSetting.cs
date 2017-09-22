using EmvuCV_VideoPlayer.Infrustructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmvuCV_VideoPlayer.Model
{
    public class SerializatorsSetting : INotifyPropertyChanged
    {
        private Deserializators seriaizatorType;
        private string filePath;

        public Deserializators SeriaizatorType
        {
            get { return seriaizatorType; }
            set
            {
                seriaizatorType = value;
                OnPropertyChanged("SeriaizatorType");
            }
        }

        public string FilePath
        {
            get { return filePath; }
            set
            {
                filePath = value;
                OnPropertyChanged("FilePath");
            }
        }

        public string SeriaizatorTypeText
        {
            get { return seriaizatorType.ToText(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
