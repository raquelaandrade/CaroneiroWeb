using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaroneiroWeb.Repositories;
using System.Globalization;

namespace CaroneiroWeb.Controllers
{
    public class PeopleController : Controller
    {
        PeopleRepository peopleRepository = new PeopleRepository();
        AdvertisementRepository adRepository = new AdvertisementRepository();
        UsersRepository userRepository = new UsersRepository();
        AccessRepository accessRepository = new AccessRepository();

        // GET: People
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult SearchPeopleName(string name )
        {
            int idUser = Convert.ToInt32(Session["id_user"]);
            if (name == string.Empty)
            {
                return RedirectToAction("ListAdTimeLine", "Advertisement");
            }
            var people = peopleRepository.searchUsersByName(name, idUser);
            return View(people);
        }//Retorna para a view a lista dos usuários encontrados

        [HttpGet]
        public ActionResult Message(int id)
        {
            var friend = peopleRepository.getOnePerfilFriend(id);
            ViewBag.idFriend = friend.id_user;
            ViewBag.nameFriend = friend.name_user;
            ViewBag.genreFriend = friend.genre;
            ViewBag.stateFriend = friend.state;
            ViewBag.cityFriend = friend.city;
            ViewBag.evalution = friend.evalution;
            ViewBag.image = friend.image;
            return View();
        }

        [HttpPost]
        public ActionResult Message(int id, string message)
        {
            if (message == string.Empty)
            {
                var friend = peopleRepository.getOnePerfilFriend(id);
                ViewBag.idFriend = friend.id_user;
                ViewBag.nameFriend = friend.name_user;
                ViewBag.genreFriend = friend.genre;
                ViewBag.stateFriend = friend.state;
                ViewBag.cityFriend = friend.city;
                ViewBag.evalution = friend.evalution;
                ViewBag.image = friend.image;
                ViewBag.messagefeedback = "Você precisa inserir uma mensagem...";
                return View();
            }
            else
            {
                var friend = peopleRepository.getOnePerfilFriend(id);
                ViewBag.idFriend = friend.id_user;
                ViewBag.nameFriend = friend.name_user;
                ViewBag.genreFriend = friend.genre;
                ViewBag.stateFriend = friend.state;
                ViewBag.cityFriend = friend.city;
                ViewBag.evalution = friend.evalution;
                ViewBag.image = friend.image;

                int idUser = Convert.ToInt32(Session["id_user"]);
                peopleRepository.sendMessage(id, idUser, message);
                ViewBag.messagefeedback = "Mensagem enviada com sucesso...";
                ModelState.Clear(); 
                return View();
            }

        }


        [HttpGet]
        public ActionResult FriendPerfil(int id)
        {
            var friend = peopleRepository.getOnePerfilFriend(id);
          
            int age = accessRepository.checkAge(friend.date_birth);

            ViewBag.date = age;
            ViewBag.idFriend = friend.id_user;
            ViewBag.nameFriend = friend.name_user;
            ViewBag.genreFriend = friend.genre;
            ViewBag.stateFriend = friend.state;
            ViewBag.cityFriend = friend.city;
            ViewBag.evalution = friend.evalution;
            ViewBag.image = friend.image;

            return View(friend);
        }// Retorna o perfil completo de outro usuário

        public ActionResult ListAdsFriends(int id)
        {
            var friend = peopleRepository.getOnePerfilFriend(id);
            ViewBag.idFriend = friend.id_user;
            ViewBag.nameFriend = friend.name_user;
            ViewBag.genreFriend = friend.genre;
            ViewBag.stateFriend = friend.state;
            ViewBag.cityFriend = friend.city;
            ViewBag.evalution = friend.evalution;
            ViewBag.image = friend.image;

            var ad = adRepository.searchAd(id);
            return View(ad);
        }// Retorna lista com anúncios de outro usuário

        [HttpGet]
        public ActionResult AdParticipationRequest(int idOwner, int idAd, string adTitle)
        {
            int idOwner1 = idOwner;
            int idAd1 = idAd;
            int idUser = Convert.ToInt32(Session["id_user"]);
            userRepository.adParticipationRequest(adTitle, idUser, idAd, idOwner);
          
            return RedirectToAction("SelectedAd", new {idOwner = idOwner1, idAd = idAd1 });
        }// O usuário logado solicita participação no anúncio de outro usuário

        public ActionResult SelectedAd(int idOwner, int idAd)
        {
            var friend = peopleRepository.getOnePerfilFriend(idOwner);
            ViewBag.idFriend = friend.id_user;
            ViewBag.nameFriend = friend.name_user;
            ViewBag.genreFriend = friend.genre;
            ViewBag.stateFriend = friend.state;
            ViewBag.cityFriend = friend.city;
            ViewBag.evalution = friend.evalution;
            ViewBag.image = friend.image;

            int idUser = Convert.ToInt32(Session["id_user"]);
            bool check = peopleRepository.checkRequest(idUser, idAd);
            bool participation = peopleRepository.checkParticipation(idUser, idAd);

            ViewBag.p = participation;
            ViewBag.check = check;
            var ad = adRepository.getOneAd(idOwner, idAd);
            return View(ad);

        }//Seleciona um anúncio específico 

        public ActionResult CancelAdShare(int idOwner, int idAd)
        {
            int idOwner1 = idOwner;
            int idAd1 = idAd;
            int idUser = Convert.ToInt32(Session["id_user"]);
            userRepository.deleteRequestForParticipation(idAd, idUser);
            return RedirectToAction("SelectedAd", new { idOwner = idOwner1, idAd = idAd1 });
        }// O usuário logado cancela solicitação de participação no anúncio de outra pessoa

    }

}