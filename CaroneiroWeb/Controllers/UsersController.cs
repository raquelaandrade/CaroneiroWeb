using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaroneiroWeb.Models;
using CaroneiroWeb.Controllers;
using CaroneiroWeb.Repositories;
using System.Web.Security;

namespace CaroneiroWeb.Controllers
{
    public class UsersController : Controller
    {
        UsersRepository usersRepository = new UsersRepository();
        AdvertisementRepository adRepository = new AdvertisementRepository();
        AccessRepository accessRepository = new AccessRepository();

        // GET: Users
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Perfil()
        {
            int idUser = Convert.ToInt32(Session["id_user"]);
            var user = usersRepository.getOnePerfil(idUser);
            int age = accessRepository.checkAge(user.date_birth);
            ViewBag.date = age;
            return View(user);
        }//Retorna a view com o perfil do usuário

        [HttpGet]
        public ActionResult EditPerfil()
        {
            int idUser = Convert.ToInt32(Session["id_user"]);
            var user = usersRepository.getOnePerfil(idUser);
            return View(user);
        }//Retorna a view para alterar o perfil do usuário

        [HttpPost]
        public ActionResult EditPerfil(Users pUser)
        {
            if (pUser.name_user == null)
            {
                return View();
            }
            if (pUser.state == null)
            {
                return View();
            }
            if (pUser.city == null)
            {
                return View();
            }
            Session["name_user"] = pUser.name_user;
            Session["state"] = pUser.state;
            int idUser = Convert.ToInt32(Session["id_user"]);
            pUser.id_user = idUser;
            usersRepository.editPerfil(pUser);
            return View("Perfil");
        }//Recebe os dados alterados

        [HttpGet]
        public ActionResult AccessEditPerfil()
        {
            int idUser = Convert.ToInt32(Session["id_user"]);
            var user = usersRepository.getOnePerfilAccess(idUser);
            return View(user);
        }

        [HttpPost]
        public ActionResult AccessEditPerfil(Users pUser)
        {
            if (pUser.name_user == null)
            {
                return View();
            }
            if (pUser.date_birth == Convert.ToDateTime("01/01/0001 00:00:00"))
            {
                ViewBag.error1 = "Informe sua data de aniversário."; 
                return View();
            }
            if ((pUser.state == null)||(pUser.state == "não informado"))
            {
            
                return View();
            }
            if ((pUser.city == null)||(pUser.city == "não informado"))
            {
                return View();
            }
            int age = accessRepository.checkAge(pUser.date_birth);
            if (age < 16)
            {
                ViewBag.register = "Você não possui idade para se cadastrar!";
                return View();
            }
            Session["name_user"] = pUser.name_user;
            Session["state"] = pUser.state;
            int idUser = Convert.ToInt32(Session["id_user"]);
            usersRepository.alterEditAccess(1, idUser);
            pUser.id_user = idUser;
            usersRepository.editPerfilAccess(pUser);
            return RedirectToAction("ListAdTimeLine", "Advertisement", new { state = pUser.state });
        }


        [HttpGet]
        public ActionResult Message()
        {
            int idUser = Convert.ToInt32(Session["id_user"]);
            accessRepository.alterNotificationMessage(idUser);
            NotificationMessages nm = accessRepository.notificationMessage(idUser);
            int numMsg = nm.qtdMsg;
            Session["qtdMsg"] = numMsg;

            var message = usersRepository.receivedMessages(idUser);
            return View(message);
        }

        [HttpGet]
        public ActionResult DeleteMessage(int id)
        {
            usersRepository.deleteMessage(id);
            return RedirectToAction("Message");
        }//Deleta uma mensagem

        [HttpGet]
        public ActionResult MyAds()
        {
            int idUser = Convert.ToInt32(Session["id_user"]);
            var ad = adRepository.searchAd(idUser);
            return View(ad);
        }//Retorna os anúncios do usuário logado

        public ActionResult SearchSpecificAd(int idAd)
        {
            int idUser = Convert.ToInt32(Session["id_user"]);
            var ad = adRepository.getOneAd(idUser, idAd);

            var interestedList = usersRepository.interestedPeople(idAd);
            var participantsList = usersRepository.participantPeople(idAd);
            ViewBag.interestedList = new List<Interested>(interestedList);
            ViewBag.participantsList = new List<Participants>(participantsList);
            return View(ad);
        }// Seleciona um anúncio especifico e retorna os interessados neste anúncio

        public ActionResult AcceptParticipation(int pIdAd, int pIdUser, string title, int idOwner)
        {
            usersRepository.deleteRequestForParticipation(pIdAd, pIdUser);
            usersRepository.acceptParticipationRequest(pIdAd, pIdUser, title, idOwner);

            return RedirectToAction("SearchSpecificAd", new { idAd = pIdAd });

        }//Aceita a solicitação de participação de outro usuário

        public ActionResult DeclineParticipation(int pIdAd, int pIdUser)
        {
            usersRepository.refuseRequestParticipation(pIdAd, pIdUser);

            return RedirectToAction("SearchSpecificAd", new { idAd = pIdAd });
        }//Recusa uma solicitação de participação

        public ActionResult DeleteParticipation(int pIdAd, int pIdUser)
        {
            usersRepository.deleteParticipation(pIdAd, pIdUser);
            return RedirectToAction("SearchSpecificAd", new { idAd = pIdAd });
        }//Deleta uma participação 

        public ActionResult ListNotificationInterested()
        {
            int idUser = Convert.ToInt32(Session["id_user"]);
            accessRepository.alterNotificationInterested(idUser);

            int numNI = 0;
            Session["numNI"] = numNI;

            var notification = usersRepository.notificationInterestedList(idUser);
            return View(notification);
        }

        public ActionResult ListNotificationParticipants()
        {
            int idUser = Convert.ToInt32(Session["id_user"]);
            accessRepository.alterNotificationParticipation(idUser);

            int numNP = 0;
            Session["numNP"] = numNP;

            var notification = usersRepository.notificationParticipantsList(idUser);
            return View(notification);
        }

        public ActionResult DeleteNotificationParticipantes(int idNotification)
        {
            usersRepository.deleteNotificationParticipant(idNotification);
            return RedirectToAction("ListNotificationParticipants");
        }
         
        public ActionResult DeleteNotificationInterested(int idNotification)
        {
            usersRepository.deleteNotificationInterested(idNotification);
            return RedirectToAction("ListNotificationParticipants");
        }

    }
}