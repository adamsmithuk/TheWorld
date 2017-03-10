using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller 
    {
        private IMailServices _mailService;
        private IConfigurationRoot _config;

        public AppController(IMailServices mailService, IConfigurationRoot config)
        {
            _mailService = mailService;
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (model.Email.Contains("fake.com"))
            {
                ModelState.AddModelError("", "We do not support Fake.com addresses");
            }

            if (ModelState.IsValid)
            {
                _mailService.Sendmail(_config["MailSettings:ToAddress"], model.Email, "From The World", model.Message);
                ViewBag.UserMessage = "Message Sent";
                ModelState.Clear();
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
