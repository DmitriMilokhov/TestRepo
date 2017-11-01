using System.Collections.ObjectModel;
using AdvOrganizer.Model.Wrapper;
using AdvOrganizer.Infrustructure;

namespace AdvOrganizer.ViewModel
{
    public class ReportViewModel : ViewModelBase
    {
        private ObservableCollection<AdvInfoWrapper> advInfos;
        private Repository repository;

        public ReportViewModel()
        {
            AdvInfos = new ObservableCollection<AdvInfoWrapper>();
            repository = new Repository();
        }

        public ObservableCollection<AdvInfoWrapper> AdvInfos
        {
            get { return advInfos; }
            set
            {
                advInfos = value;
                OnPropertyChanged();
            }
        }

        public void LoadInfos()
        {
            var modelList = repository.GetAllAdvInfos();

            if (modelList?.Count > 0)
            {
                AdvInfos.Clear();
                foreach (var model in modelList)
                {
                    AdvInfos.Add(new AdvInfoWrapper(model));
                }
            }
        }
    }
}
