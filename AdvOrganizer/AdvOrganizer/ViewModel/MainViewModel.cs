using AdvOrganizer.Infrustructure;
using AdvOrganizer.Model;
using AdvOrganizer.Model.Wrapper;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MlkPwgen;
using AdvOrganizer.Interface;

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
        private IAdvRepository repository;

        public MainViewModel()
        {
            repository = new AdvJsonRepository();
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
                        var morningModel = (repository as AdvJsonRepository).FindAdvInfo(currentDate, true);
                        if (morningModel == null)
                        {
                            morningModel = new AdvInfoModel()
                            {
                                Id = PasswordGenerator.Generate(length: 10, allowed: Sets.Alphanumerics),
                                Date = currentDate
                            };
                        }
                        MorningAdvInfo = new AdvInfoWrapper(morningModel);


                        var eveningModel = (repository as AdvJsonRepository).FindAdvInfo(currentDate, false);
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
                        MorningAdvInfo.Save(repository);
                    if (EveningAdvInfo.Time.Hours != 0)
                        EveningAdvInfo.Save(repository);
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
