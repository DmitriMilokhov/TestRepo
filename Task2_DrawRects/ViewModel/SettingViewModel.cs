using EmvuCV_VideoPlayer.Concrete;
using EmvuCV_VideoPlayer.Infrustructure;
using EmvuCV_VideoPlayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmvuCV_VideoPlayer.ViewModel
{
    class SettingViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<SerializatorsSetting> SerializatorsSettings { get; set; }
        private RelayCommand openDialogCommand;
        private Repository repository = new Repository();

        public SettingViewModel()
        {
            SerializatorsSettings = repository.LoadSettingsFromXml<SerializatorsSetting>();
            if (SerializatorsSettings == null)
            {
                SerializatorsSettings = SetNoneFindedSettings();
            }
        }

        public RelayCommand OpenDialogCommand
        {
            get
            {
                return openDialogCommand ??
                    (openDialogCommand = new RelayCommand(obj =>
                    {
                        DefaultDialogService dialogSerivce = new DefaultDialogService();
                        try
                        {
                            if (dialogSerivce.OpenFileDialog() == true)
                            {
                                string filePath = dialogSerivce.FilePath;
                                string extension = Path.GetExtension(filePath);
                                SetNewDeserialFilePath(filePath, extension);
                                SerializatorsSettings.SaveToXml();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }));
            }
        }

        private void SetNewDeserialFilePath(string newPath, string deserializationFileExtension)
        {
            switch (deserializationFileExtension)
            {
                case ".xml":
                    SerializatorsSettings.FirstOrDefault(s => s.SeriaizatorType == Deserializators.XmlSerializator).FilePath = newPath;
                    break;
                case ".yaml":
                    SerializatorsSettings.FirstOrDefault(s => s.SeriaizatorType == Deserializators.YamlSerializator).FilePath = newPath;
                    break;
            }
        }

        private ObservableCollection<SerializatorsSetting> SetNoneFindedSettings()
        {
            return new ObservableCollection<SerializatorsSetting>
            {
                new SerializatorsSetting { SeriaizatorType = Deserializators.XmlSerializator, FilePath="Not finded" },
                new SerializatorsSetting { SeriaizatorType = Deserializators.YamlSerializator, FilePath="Not finded" },
            };
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
