using AdvOrganizer.Model;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace AdvOrganizer.Infrustructure
{
    public class Repository
    {
        private string filePath = Environment.CurrentDirectory + "\\advStorage.json";

        public void SaveToJson(AdvInfoModel newAdvInfo)
        {
            if (File.Exists(filePath))
            {
                var advInfoResults = GetAllAdvInfos();

                if (advInfoResults != null)
                {
                    var element = advInfoResults.FirstOrDefault(ad => ad.Id == newAdvInfo.Id);
                    if (element != null)
                    {
                        element.Advertiser = newAdvInfo.Advertiser;
                        element.Date = newAdvInfo.Date;
                        element.Time = newAdvInfo.Time;
                        element.IsPaid = newAdvInfo.IsPaid;
                        element.Type = newAdvInfo.Type;
                    }
                    else
                    {
                        advInfoResults.Add(newAdvInfo);
                    }
                }
                else
                {
                    advInfoResults = new List<AdvInfoModel>();
                    advInfoResults.Add(newAdvInfo);
                }

                string json = JsonConvert.SerializeObject(advInfoResults, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
        }

        public AdvInfoModel FindAdvInfo(DateTime date, bool isMorning)
        {
            if (File.Exists(filePath))
            {
                var advInfoResults = GetAllAdvInfos();
                if (advInfoResults != null)
                {
                    var element = isMorning ? advInfoResults.FirstOrDefault(ad => ad.Date == date && ad.IsMorning)
                                            : advInfoResults.FirstOrDefault(ad => ad.Date == date && !ad.IsMorning);

                    if (element != null)
                    {
                        return element;
                    }
                }
            }

            return null;
        }

        public void RemovePassedData()
        {
            var advInfo = GetAllAdvInfos();
            advInfo.RemoveAll(ad => DateTime.Compare(ad.Date, DateTime.Today) < 0);

            string json = JsonConvert.SerializeObject(advInfo, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public List<AdvInfoModel> GetAllAdvInfos()
        {
            string advContent = File.ReadAllText(filePath);
            var advInfos = new List<AdvInfoModel>();

            return JsonConvert.DeserializeAnonymousType(advContent, advInfos)?.OrderBy(ad=>ad.Date).ToList();
        }
    }
}
