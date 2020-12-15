using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Web.Infrastructure;

namespace WebApplication4.Areas.Panel.Configuration.Languages
{
    [Area("Panel")]
    [SubArea("Configuration")]
    public class LanguagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
