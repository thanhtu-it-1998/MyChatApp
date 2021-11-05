using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChatApp.Controllers
{
    public class RoomsController : Controller
    {
        public IActionResult Friends()
        {
            return View();
        }

        public IActionResult Groups()
        {
            return View();
        }

    }
}
