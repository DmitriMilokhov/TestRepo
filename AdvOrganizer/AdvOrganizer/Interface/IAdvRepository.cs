using AdvOrganizer.Model;
using System.Collections.Generic;

namespace AdvOrganizer.Interface
{
    public interface IAdvRepository
    {
        void Save(AdvInfoModel newAdvInfo);
        void RemovePassedData();
        List<AdvInfoModel> GetAllAdvInfos();
    }
}