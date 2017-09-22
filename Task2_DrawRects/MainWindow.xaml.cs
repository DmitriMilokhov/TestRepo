using System.Windows;
using EmvuCV_VideoPlayer.ViewModel;
using EmvuCV_VideoPlayer.View;

namespace EmvuCV_VideoPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new VideoViewModel(this.Dispatcher);
        }
    }
}
