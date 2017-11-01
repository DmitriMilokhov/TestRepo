using AdvOrganizer.ViewModel;
using MahApps.Metro.Controls;

namespace AdvOrganizer
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
