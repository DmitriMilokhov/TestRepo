using EmvuCV_VideoPlayer.Abstract;
using EmvuCV_VideoPlayer.Infrustructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmvuCV_VideoPlayer.ViewModel
{
    public class OpenWindowViewModel
    {
        private readonly IWindowFactory windowFactory;
        private RelayCommand openNewWindowCommand;
        public RelayCommand OpenNewWindowCommand
        {
            get { return openNewWindowCommand; }
        }

        public OpenWindowViewModel(IWindowFactory windowFactory)
        {
            this.windowFactory = windowFactory;
            openNewWindowCommand = new RelayCommand(obj =>
                {
                    DoOpenNewWindow();
                });
        }

        private void DoOpenNewWindow()
        {
            windowFactory.CreateNewWindow();
        }
    }
}
