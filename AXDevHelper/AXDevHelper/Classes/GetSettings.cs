using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXDevHelper.Classes
{
    [Serializable]
    public class GetSettings
    {
        public string CurrentWIT { get; set; }
    }
    [Serializable]
    public class FormatKeyWord
    {
        public string key { get; set; }
        public string description { get; set; }
        public FormatKeyWord(string _key, string _description)
        {
            key = _key;
            description = _description;
        }
        public override string ToString()
        {
            return description;
        }
    }
}
