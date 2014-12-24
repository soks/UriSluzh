using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Visitka.Models;

namespace Visitka.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Customer()
        {
            return View();
        }

        public ActionResult Supervision()
        {
            return View();
        }

        public ActionResult Certificate()
        {
            return View();
        }

        public ActionResult Question()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ViewResult Question(Question index) // Your model is passed in here
        {
            if (ModelState.IsValid)
            {
                var message = new MailMessage {From = new MailAddress("soks.cokc@Gmail.com")};
                message.To.Add(new MailAddress("a.efimov@itransition.com"));
                message.Subject = index.Email;

                // You need to use Index because that is the name declared above
                message.Body = index.Message;

                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("soks.cokc@gmail.com", "soks1234"),
                    EnableSsl = true
                };
                client.EnableSsl = true;
                client.Send(message);
                return View("Index", index);
            }
            else
            {
                return View();
            }
        }
    }
}
