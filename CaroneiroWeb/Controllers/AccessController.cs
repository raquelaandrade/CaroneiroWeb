using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CaroneiroWeb.Repositories;
using CaroneiroWeb.Models;
using System.Net.Mail;
using System.Net;

namespace CaroneiroWeb.Controllers
{
    public class AccessController : Controller
    {
        AccessRepository accessRepository = new AccessRepository();
        SettingsRepository settingsRepository = new SettingsRepository();
        EmailServerAccount emailServerAccount = new EmailServerAccount();

        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }//Retorna a view 

        [HttpPost]
        [ValidateAntiForgeryToken]//Previne o ataque CSRF
        public ActionResult Register(Users users)
        {
            if (ModelState.IsValid)
            {
                bool email = accessRepository.verifyEmail(users.email);
                int age = accessRepository.checkAge(users.date_birth);
                if (email == true)
                {
                    ViewBag.register = "Esse email já está vinculado a um usuário!";
                    return View();
                }
                if (age < 16)
                {
                    ViewBag.register = "Você não possui idade para se cadastrar!";
                    return View();
                }
                if (users.password_user != users.password_confirm)
                {
                    ViewBag.register = "Senhas não conferem!";
                    return View();
                }

                //string ok = emailServerAccount.sendEmail(users.email);
                //if (ok == "falha")
                //{
                //    ViewBag.register = "Não conseguimos enviar um email de confirmação. Verifique se ele esta correto e tente novamente.";
                //    return View();
                //}


                accessRepository.register(users);
                ViewBag.success = "Cadastro realizado com sucesso! Insira seu email e senha para continuar...";
                return View("Feedback");
            }
            else
            {
                ViewBag.register = "Você precisa informar todos os dados!";
                return View();
            }



        }// Pega os dados do formlário de cadastro e válida as informações - funcionando

        [HttpGet]
        public ActionResult Login()
        {
            return View();

        }//Retorna a view

        [HttpPost]
        public ActionResult Login(Users user)
        {
         
            if ((user.email == null) || (user.password_user == null))
            {
                return View();
            }
            else
            {
                Users authenticated_User = accessRepository.authenticateUser(user.email, user.password_user);

                if (authenticated_User != null)
                {
                    if (authenticated_User.active == 0)
                    {
                        ViewBag.error = "Sua conta está desativada. Reative para continuar...";
                        return View();
                    }
                    if (authenticated_User.confirmation == 0)
                    {
                        ViewBag.confirmation = "Esse email ainda não foi confirmado. Verifique sua caixa de entrada.";
                        return View();
                    }
                    
                    NotificationMessages nm = accessRepository.notificationMessage(authenticated_User.id_user);
                    Notification ni = accessRepository.notificationInterested(authenticated_User.id_user);
                    Notification np = accessRepository.notificationParticipation(authenticated_User.id_user);
                    int numMsg = nm.qtdMsg;
                    int numNI = ni.qtd;
                    int numNP = np.qtdP;

                    Session["numNP"] = numNP;
                    Session["numNI"] = numNI;
                    Session["qtdMsg"] = numMsg;
                    Session["image"] = authenticated_User.image;
                    Session["name_user"] = authenticated_User.name_user;
                    Session["id_user"] = authenticated_User.id_user;
                    Session["state"] = authenticated_User.state;
                    return RedirectToAction("ListAdTimeLine", "Advertisement", new { state = authenticated_User.state });
                }
                else
                {
                    ViewBag.error = "Login e senha não encontrados!";
                    return View();
                }
            }

        }  //Pega os dados do formulário de login e autentica o usuário

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }//Desconecta o usuário

        public ActionResult ReactivateAccount()
        {
            return View();
        } // Retorna a View

        [HttpPost]
        public ActionResult ReactivateAccount(Users user)
        {
            if ((user.email == null) || (user.password_user == null))
            {
                return View();
            }
            else
            {
                Users authenticated_User = accessRepository.authenticateUser(user.email, user.password_user);

                if (authenticated_User != null)
                {
                    if (authenticated_User.active == 1)
                    {
                        ViewBag.msg = "Esta conta não esta desativada.";
                        return View();
                    }
                    if (authenticated_User.confirmation == 0)
                    {
                        ViewBag.confirmation = "Esse email ainda não foi confirmado. Verifique sua caixa de entrada.";
                        return View();
                    }

                    int disabled = 1;
                    settingsRepository.changeAccountStatus(disabled, authenticated_User.id_user);

                    NotificationMessages nm = accessRepository.notificationMessage(authenticated_User.id_user);
                    Notification ni = accessRepository.notificationInterested(authenticated_User.id_user);
                    Notification np = accessRepository.notificationParticipation(authenticated_User.id_user);
                    int numMsg = nm.qtdMsg;
                    int numNI = ni.qtd;
                    int numNP = np.qtdP;

                    Session["numNP"] = numNP;
                    Session["numNI"] = numNI;
                    Session["qtdMsg"] = numMsg;
                    Session["image"] = authenticated_User.image;
                    Session["name_user"] = authenticated_User.name_user;
                    Session["id_user"] = authenticated_User.id_user;
                    Session["state"] = authenticated_User.state;
                    return RedirectToAction("ListAdTimeLine", "Advertisement", new { state = authenticated_User.state });

                }
                else
                {
                    ViewBag.error = "Login e senha não encontrados!";
                    return View();

                }
            }
        } //Reativa a conta do usuário

        [HttpGet]
        public ActionResult ConfirmationRegister()
        {
            return View();
        } // Retorna a View

        public ActionResult ConfirmationRegister(Users user)
        {
            if ((user.email == null) || (user.password_user == null))
            {
                return View();
            }
            else
            {
                Users authenticated_User = accessRepository.authenticateUser(user.email, user.password_user);

                if (authenticated_User != null)
                {
                    if (authenticated_User.active == 0)
                    {
                        ViewBag.error = "Sua conta está desativada. Reative para continuar.";
                        return View();
                    }
                    if (authenticated_User.confirmation == 1)
                    {
                        ViewBag.confirmation = "Esse email já foi verificado. Retorne a página inicial e faça seu login normalmente";
                        return View();
                    }

                    int confirm = 1;
                    settingsRepository.changeConfirmation(confirm, authenticated_User.id_user);

                    NotificationMessages nm = accessRepository.notificationMessage(authenticated_User.id_user);
                    Notification ni = accessRepository.notificationInterested(authenticated_User.id_user);
                    Notification np = accessRepository.notificationParticipation(authenticated_User.id_user);
                    int numMsg = nm.qtdMsg;
                    int numNI = ni.qtd;
                    int numNP = np.qtdP;

                    Session["numNP"] = numNP;
                    Session["numNI"] = numNI;
                    Session["qtdMsg"] = numMsg;
                    Session["image"] = authenticated_User.image;
                    Session["name_user"] = authenticated_User.name_user;
                    Session["id_user"] = authenticated_User.id_user;
                    Session["state"] = authenticated_User.state;
                    return RedirectToAction("ListAdTimeLine", "Advertisement", new { state = authenticated_User.state });

                }
                else
                {
                    ViewBag.error = "Login e senha não encontrados!";
                    return View();
                }
            }

        } // Login para confirmar o email

    }

}
