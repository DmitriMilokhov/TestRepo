using EmvuCV_VideoPlayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmvuCV_VideoPlayer.Abstract
{
    interface IAdditionalObjectsDeserializable
    {
        /// <param name="path">path with name</param>
        Tracks Deserialize(string path);
    }
}
