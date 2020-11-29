using System;
using System.Collections.Generic;
using System.Text;

namespace Serializer
{
    class BuildHelper
    {
        //<objectId, className, variableName, value, type>
        public KeyValuePair<int, string> parentObject { get; set; }
        public KeyValuePair<int, string> currentObject { get; set; }
        public KeyValuePair<int, string> childObject { get; set; }
        public String assemblyName { get; set; }
        public String variableName { get; set; }
        public String value { get; set; }
        public String type { get; set; }
    }
}
