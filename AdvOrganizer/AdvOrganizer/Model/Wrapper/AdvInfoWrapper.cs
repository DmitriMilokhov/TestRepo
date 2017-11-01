
using System;

namespace AdvOrganizer.Model.Wrapper
{
    public class AdvInfoWrapper : ModelWrapper<AdvInfoModel>
    {
        public AdvInfoWrapper(AdvInfoModel model) : base(model)
        {
        }

        public string Id
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public DateTime Date
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }

        public TimeSpan Time
        {
            get { return GetValue<TimeSpan>(); }
            set { SetValue(value); }
        }

        public string Advertiser
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public AdvType Type
        {
            get { return GetValue<AdvType>(); }
            set { SetValue(value); }
        }

        public bool IsPaid
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }

        public bool IsMorning
        {
            get { return GetValue<bool>(); }
        }
    }
}
