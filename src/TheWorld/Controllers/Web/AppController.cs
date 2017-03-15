using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWorld.Models;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller 
    {
        private IMailServices _mailService;
        private IConfigurationRoot _config;
        private IWorldRepository _repository;
        private ILogger<AppController> _logger;

        public AppController(IMailServices mailService, 
            IConfigurationRoot config, 
            WorldContext context,
            IWorldRepository repository,
            ILogger<AppController> logger) 
        {
            _mailService = mailService;
            _config = config;
            _repository = repository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Trips()
        {
            try
            {
                var data = _repository.GetAllTrips();
                return View(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get trips in Index page: {ex.Message}");
                return Redirect("/error");
            }
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            // Server side email validation 
            if (model.Email.Contains("fake.com"))
            {
                ModelState.AddModelError("", "We do not support Fake.com addresses");
            }

            // If no errors on form send email
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

        public IActionResult Register()
        {
            return View();
        }
    }
}
