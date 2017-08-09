using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CaroneiroWeb.Repositories;
using CaroneiroWeb.Models;

namespace CaroneiroWeb.Controllers
{
    public class SettingsController : Controller
    {
        SettingsRepository settingsRepository = new SettingsRepository();

        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConfirmAction()
        {
            return View();
        } //Retorna a view de confirmação de desativação da conta

        public ActionResult DeactivateAccount()
        {
            int idUser = Convert.ToInt32(Session["id_user"]);
            settingsRepository.changeAccountStatus(0, idUser);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }//Caso o usuário confirme a desativação esta action altera o campo active para 0 = false (desativado)

        public ActionResult ConfirmPasswordChange()
        {
            return View();
        }//Retorna a view de troca de senha - completar

        [HttpPost]
        public ActionResult ConfirmPasswordChange(Users pUser)
        {
            if ((pUser.password_user != null))
            {
                int idUser = Convert.ToInt32(Session["id_user"]);
                var result = settingsRepository.verifyPassword(idUser, pUser.password_user);
                if (result == true)
                {
                    return RedirectToAction("AlterPassword");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        public ActionResult AlterPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlterPassword(Users users)
        {
            if (users.password_user == users.password_confirm)
            {
                int idUser = Convert.ToInt32(Session["id_user"]);
                settingsRepository.alterPassword(users.password_user, idUser);
                ViewBag.alterPassword = "Senha alterada com sucesso!";
                return View();
            }
            if (users.password_user != users.password_confirm)
            {
                ViewBag.alterPassword = "As senhas não são iguais!";
                return View();
            }
            return View();
        }
    }
}