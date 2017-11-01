using EmvuCV_VideoPlayer.Abstract;
using EmvuCV_VideoPlayer.View;
using EmvuCV_VideoPlayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmvuCV_VideoPlayer.Concrete
{
    class SettingWindowFactory : IWindowFactory
    {
        public void CreateNewWindow()
        {
            SettingView settingWindow = new SettingView()
            {
                DataContext = new SettingViewModel()
            };

            settingWindow.Show();
        }
    }
}
