using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmvuCV_VideoPlayer.Infrustructure
{
    public class Repository
    {
        public string GetNameFromCommandArg(string arg)
        {
            Dictionary<string, string> argsDictionary = new Dictionary<string, string>();
            string videoName = string.Empty;

            string[] args = Environment.GetCommandLineArgs();

            for (int index = 1; index < args.Length; index += 2)
            {
                if (index + 1 < args.Length)
                {
                    argsDictionary.Add(args[index], args[index + 1]);
                } 
            }

            argsDictionary.TryGetValue(arg, out videoName);
            return videoName;
        }
    }
}
