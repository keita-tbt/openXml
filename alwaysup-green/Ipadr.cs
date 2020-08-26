using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alwaysup_green
{
    public class Ipadr
    {
        public string remoteIp { get; set; }
        public StringValues forwardedFor { get; set; }
        public StringValues forwardedProto { get; set; }
        public StringValues forwardedHost { get; set; }
        public string requestStatus { get; set; }
    }
}
