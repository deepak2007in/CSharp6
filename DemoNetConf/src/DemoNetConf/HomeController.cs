using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MyLibrary;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoNetConf
{
    public class HomeController : Controller
    {
        private readonly IMySiteCultureService _mscs;

        public HomeController(IMySiteCultureService mscs)
        {
            _mscs = mscs;
        }

        [HttpGet("/")]
        public string Index()
        {
            _mscs.SetCulture();
            return "Hello World "+ DateTimeOffset.Now;
        }
    }
}
