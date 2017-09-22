using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmvuCV_VideoPlayer.Infrustructure
{
    public enum Deserializators
    {
        XmlSerializator,
        YamlSerializator
    }

    public enum GrabStates
    {
        Stopped,
        Running,
        Pause,
        Stopping,
    }
}
