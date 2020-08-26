using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alwaysup_green.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddTable : ControllerBase
    {
        public void Get()
        {
            OpenXmlWord.AddTable();
        }
    }
}
