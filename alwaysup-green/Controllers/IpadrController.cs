using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace alwaysup_green.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IpadrController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string forwardedFor = "X-Forwarded-For";
        private string forwardedHost = "X-Forwarded-Host";
        private string forwardedProto = "X-Forwarded-Proto";
        private StringValues forwardedIp;
        private StringValues hostIp;
        private StringValues protoIp;
        public IpadrController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        /*
        public string Get()
        {
            Request.Headers.TryGetValue(forwardedFor,out forwardedIp);
            Request.Headers.TryGetValue(forwardedHost, out hostIp);
            Request.Headers.TryGetValue(forwardedProto, out protoIp);
            var ipadr = new Ipadr
            {
                forwardedFor = forwardedIp,
                forwardedHost = hostIp,
                forwardedProto = protoIp,
                remoteIp = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                requestStatus = "実行済み"
            };
            return JsonConvert.SerializeObject(ipadr, Formatting.Indented);
        }
        */
        public Ipadr Get()
        {
            OpenXmlWord.OpenAndAddTextToWordDocument();
            Request.Headers.TryGetValue(forwardedFor, out forwardedIp);
            Request.Headers.TryGetValue(forwardedHost, out hostIp);
            Request.Headers.TryGetValue(forwardedProto, out protoIp);
            var ipadr = new Ipadr
            {
                forwardedFor = forwardedIp,
                forwardedHost = hostIp,
                forwardedProto = protoIp,
                remoteIp = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                requestStatus = "return from green"
            };
            return ipadr;
        }
    }
}
