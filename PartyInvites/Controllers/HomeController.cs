using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
   public class HomeController : Controller // Inheritance, Extends
   {
      //   F i e l d s

      private readonly ILogger<HomeController> _logger;

      //   C o n s t r u c t o r s

      public HomeController(ILogger<HomeController> logger)
      {
         _logger = logger;
      }

      //   M e t h o d s

      public IActionResult HelloWorld()
      {
         ViewBag.X = "Xavier";
         ViewBag.R = "Ryan";

         if (System.DateTime.Now.Hour < 12)
         {
            ViewBag.Greeting = "Good Morning";
         }
         else if (System.DateTime.Now.Hour < 17)
         {
            ViewBag.Greeting = "Good Afternoon";
         }
         else
         {
            ViewBag.Greeting = "Good Evening";
         }

         IActionResult result = View();
         return result;
      }

      public IActionResult Index()
      {
         if (System.DateTime.Now.Hour < 12)
         {
            ViewBag.Greeting = "Good Morning";
         }
         else if (System.DateTime.Now.Hour < 17)
         {
            ViewBag.Greeting = "Good Afternoon";
         }
         else
         {
            ViewBag.Greeting = "Good Evening";
         }

         IActionResult result = View("MyView");
         return result;
      }

      [HttpGet]
      public IActionResult RsvpForm()
      {
         return View();
      }

      [HttpPost]
      public IActionResult RsvpForm(GuestResponse guestResponse)
      {
         if (ModelState.IsValid)
         {
            FakeDb.AddResponse(guestResponse);
            return View("Thanks", guestResponse); // Thanks.cshtml
         }
         else
         {
            return View();
         }
      }

      public IActionResult ListResponses()
      {
         GuestResponse[] responses = FakeDb.GetResponses();
         return View(responses);
      }

      public IActionResult Privacy()
      {
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
