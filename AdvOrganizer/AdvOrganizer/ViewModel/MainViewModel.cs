using AdvOrganizer.Infrustructure;
using AdvOrganizer.Model;
using AdvOrganizer.Model.Wrapper;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MlkPwgen;

namespace AdvOrganizer.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool isReport;
        private AdvInfoWrapper morningAdvInfo;
        private AdvInfoWrapper eveningAdvInfo;
        private ICommand dateChangedCommand;
        private ICommand saveCommand;
        private ICommand cleanOldCommand;
        private ICommand showReportCommand;
        private Repository repository;

        public MainViewModel()
        {
            repository = new Repository();
            ReportViewModel = new ReportViewModel();
            IsReport = false;
        }

        public ReportViewModel ReportViewModel { get; }

        public bool IsReport
        {
            get { return isReport; }
            set
            {
                if (IsReport != value)
                {
                    isReport = value;
                    OnPropertyChanged();
                }
            }
        }


        public AdvInfoWrapper MorningAdvInfo
        {
            get { return morningAdvInfo; }
            set
            {
                morningAdvInfo = value;
                OnPropertyChanged();
            }
        }

        public AdvInfoWrapper EveningAdvInfo
        {
            get { return eveningAdvInfo; }
            set
            {
                eveningAdvInfo = value;
                OnPropertyChanged();
            }
        }

        public ICommand DateChangedCommand
        {
            get
            {
                return dateChangedCommand ?? (dateChangedCommand = new RelayCommand(date =>
                {
                    Mouse.Capture(null);
                    if (date != null)
                    {
                        DateTime currentDate = ((IEnumerable<DateTime>)date).FirstOrDefault();
                        var morningModel = repository.FindAdvInfo(currentDate, true);
                        if (morningModel == null)
                        {
                            morningModel = new AdvInfoModel()
                            {
                                Id = PasswordGenerator.Generate(length: 10, allowed: Sets.Alphanumerics),
                                Date = currentDate
                            };
                        }
                        MorningAdvInfo = new AdvInfoWrapper(morningModel);


                        var eveningModel = repository.FindAdvInfo(currentDate, false);
                        if (eveningModel == null)
                        {
                            eveningModel = new AdvInfoModel()
                            {
                                Id = PasswordGenerator.Generate(length: 10, allowed: Sets.Alphanumerics),
                                Date = currentDate
                            };
                        }
                        EveningAdvInfo = new AdvInfoWrapper(eveningModel);
                    }
                }));
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new RelayCommand(obj =>
                {
                    if (MorningAdvInfo.Time.Hours != 0)
                        repository.SaveToJson(MorningAdvInfo.Model);
                    if (EveningAdvInfo.Time.Hours != 0)
                        repository.SaveToJson(EveningAdvInfo.Model);
                }));
            }
        }

        public ICommand CleanOldCommand
        {
            get
            {
                return cleanOldCommand ?? (cleanOldCommand = new RelayCommand(obj =>
                {
                    repository.RemovePassedData();
                }));
            }
        }

        public ICommand ShowReportCommand
        {
            get
            {
                return showReportCommand ?? (showReportCommand = new RelayCommand(obj =>
                {
                    IsReport = !IsReport;
                    if(IsReport)
                    {
                        ReportViewModel.LoadInfos();
                    }
                }));
            }
        }
    }
}
