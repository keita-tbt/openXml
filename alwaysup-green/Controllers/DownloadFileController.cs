using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alwaysup_green.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadFileController : ControllerBase
    {
        public DownloadFileController() { }
        public IActionResult Get()
        {
            string physicalPath = @"C:\Users\Administrator\Desktop\sample.docx";
            //string physicalPath = @"D:\文書\wordTest\sample.docx";
            FileStream stream = new FileStream(physicalPath, FileMode.Open);
            //return File(stream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "sample.docx");
            return File(stream, "application/octet-stream", "sample.docx");
        }
    }
}
