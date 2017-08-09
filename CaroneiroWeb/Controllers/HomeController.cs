using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaroneiroWeb.Models;
using CaroneiroWeb.Repositories;

namespace CaroneiroWeb.Controllers
{
    public class HomeController : Controller
    {
        EmailServerAccount emailSend = new EmailServerAccount();
        AccessRepository accessRepository = new AccessRepository();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                string send = emailSend.sendEmailContact(contact);
                if (send == "ok")
                {
                    ViewBag.send = "Obrigado pelo seu contato. Em breve retornaremos para seu email.";
                }
                else
                {
                    ViewBag.send = "Ops... Não foi possível enviar sua mensagem. Tente novamente.";
                }

                return View();
            }
            return View();

            
        }

        public ActionResult TermsOfUse()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RecoverPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecoverPassword(Users users)
        {
            bool verify = accessRepository.verifyEmail(users.email);
            bool access = accessRepository.verifyFacebook(users.email);

            if (verify == true)
            {
                if (access == true)
                {
                    ViewBag.ok = "Você está logado com sua conta do Facebook.";
                    return View();
                }
                else
                {
                    Users user = accessRepository.verifyPassword(users);
                    emailSend.sendPassword(users.email, user.password_user);
                    ViewBag.ok = "Sua senha foi enviada para seu email.";
                    return View();
                }

                
            }
            return View();
        }
    }
}