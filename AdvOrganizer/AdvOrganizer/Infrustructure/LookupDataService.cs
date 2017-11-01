
using AdvOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvOrganizer.Infrustructure
{
    public class LookupDataService
    {
        public IEnumerable<LookupItem> GetAdvTypes()
        {
            List<AdvType> types = new List<AdvType>();
            foreach (AdvType type in Enum.GetValues(typeof(AdvType)))
            {
                types.Add(type);
            }

            return types.Select(t =>
                            new AdvLookupItem
                            {
                                Type = t,
                                DisplayMember = t.ToString()
                            })
                        .ToList();
        }
    }
}
