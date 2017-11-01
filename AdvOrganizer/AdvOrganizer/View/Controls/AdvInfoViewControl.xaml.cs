using System.Windows.Controls;
using AdvOrganizer.Model.Wrapper;
using System.Windows;
using System.Collections.ObjectModel;
using AdvOrganizer.Infrustructure;

namespace AdvOrganizer.View.Controls
{
    /// <summary>
    /// Interaction logic for AdvInfoViewControl.xaml
    /// </summary>
    public partial class AdvInfoViewControl : UserControl
    {
        public AdvInfoViewControl()
        {
            InitializeComponent();
            AdvTypes = new ObservableCollection<LookupItem>();
            LoadAdvTypes();
        }

        public AdvInfoWrapper AdvInfo
        {
            get { return (AdvInfoWrapper)GetValue(AdvInfoProperty); }
            set { SetValue(AdvInfoProperty, value); }
        }

        public static readonly DependencyProperty AdvInfoProperty =
            DependencyProperty.Register("AdvInfo", typeof(AdvInfoWrapper), typeof(AdvInfoViewControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public ObservableCollection<LookupItem> AdvTypes { get; }

        private void LoadAdvTypes()
        {
            AdvTypes.Clear();
            LookupDataService lookupDataService = new LookupDataService();
            var lookup = lookupDataService.GetAdvTypes();
            foreach (var lookupItem in lookup)
            {
                AdvTypes.Add(lookupItem);
            }
        }
    }
}
