using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChatApp.Controllers
{
    public class ChatsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
