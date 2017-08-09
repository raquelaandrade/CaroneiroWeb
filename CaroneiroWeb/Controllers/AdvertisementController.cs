using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaroneiroWeb.Models;
using CaroneiroWeb.Repositories;

namespace CaroneiroWeb.Controllers
{
    public class AdvertisementController : Controller
    {
        AdvertisementRepository adRepository = new AdvertisementRepository();

        // GET: Advertisement
        #region ok
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateHostingAd()
        {
            return View();
        }//Retorna a view com o formulário de procura por hospedagem

        [HttpPost]
        public ActionResult CreateHostingAd(Advertisement ad)
        {
            if (ModelState.IsValid)
            {
                if (ad.title == null)
                {
                    return View();
                }

                if (ad.expiration_date < DateTime.Now)
                {
                    ViewBag.erroDateEx = "A validade do anúncio não pode ser inferior a data atual.";
                    return View();
                }

                if ((ad.state == null) || (ad.city == null))
                {
                    ViewBag.erroLocality = "Informações sobre o destino devem ser preenchidas.";
                    return View();
                }

                if (ad.checkin < DateTime.Now)
                {
                    ViewBag.erroCheckin = "A data de checkin não pode ser inferior a data atual.";
                    return View();
                }

                if ((ad.checkout < DateTime.Now) || (ad.checkout < ad.checkin))
                {
                    ViewBag.erroCheckout = "A data de checkout não pode ser inferior a data atual ou a data de checkin.";
                    return View();
                }

                if (ad.quantity_people <= 0)
                {
                    ViewBag.erroQtdP = "É necessário ter no mínimo uma pessoa";
                    return View();
                }

                if (ad.maximum_people_value <= 0)
                {
                    ViewBag.erroMPV = "Informe o valor diário máximo que deseja gastar por pessoa.";
                    return View();
                }

                if (ad.accommodation_type == null)
                {
                    ViewBag.erroAT = "Informe o tipo de acomodação que deseja encontrar. Ex: Quarto confortável, etc.";
                    return View();
                }

                int idUser = Convert.ToInt32(Session["id_user"]);
                adRepository.saveAdHosting(ad, idUser);


                return RedirectToAction("MyAds", "Users");
            }

            return View();

        }// Recebe o formulário de procura por hospedagem

        [HttpGet]
        public ActionResult CreateAdHostingOffer()
        {
            return View();
        }//Retorna a view com o formulário de oferta por hospedagem

        [HttpPost]
        public ActionResult CreateAdHostingOffer(Advertisement ad)
        {
            if (ModelState.IsValid)
            {
                if (ad.title == null)
                {
                    return View();
                }

                if (ad.expiration_date < DateTime.Now)
                {
                    ViewBag.erroDateEx = "A validade do anúncio não pode ser inferior a data atual.";
                    return View();
                }

                if ((ad.state == null) || (ad.city == null))
                {
                    ViewBag.erroLocality = "Informações sobre a localidade devem ser preenchidas.";
                    return View();
                }

                if (ad.start < DateTime.Now)
                {
                    ViewBag.erroCheckin = "A data de início de disponibilidade não pode ser inferior a data atual.";
                    return View();
                }

                if ((ad.end < DateTime.Now) || (ad.end < ad.start))
                {
                    ViewBag.erroCheckout = "A data de checkout não pode ser inferior a data atual ou a data de início.";
                    return View();
                }

                if (ad.quantity_people <= 0)
                {
                    ViewBag.erroQtdP = "É necessário aceitar no mínimo uma pessoa";
                    return View();
                }

                if (ad.maximum_people_value <= 0)
                {
                    ViewBag.erroMPV = "Informe o valor diário máximo que deseja cobrar por pessoa.";
                    return View();
                }

                if (ad.accommodation_type == null)
                {
                    ViewBag.erroAT = "Informe o tipo de acomodação que deseja disponibilizar. Ex: Quarto confortável, etc.";
                    return View();
                }

                int idUser = Convert.ToInt32(Session["id_user"]);
                adRepository.saveHostingOffer(ad, idUser);

                return RedirectToAction("MyAds", "Users");
            }
            return View();

        }//Recebe o formulário de oferta de hospedagem

        [HttpGet]
        public ActionResult CreateRideAdvertising()
        {
            return View();
        }// Retorna a view

        [HttpPost]
        public ActionResult CreateRideAdvertising(Advertisement ad)
        {
            if (ModelState.IsValid)
            {
                if (ad.title == null)
                {
                    return View();
                }

                if (ad.expiration_date < DateTime.Now)
                {
                    ViewBag.erroDateEx = "A validade do anúncio não pode ser inferior a data atual.";
                    return View();
                }

                if (ad.departure_date < DateTime.Now)
                {
                    ViewBag.erroDepartureDate = "A data de saída não pode ser inferior a data atual.";
                    return View();
                }

                if ((ad.exitState == null) || (ad.exitTown == null))
                {
                    ViewBag.erroExit = "Informações sobre a local de saída devem ser preenchidas.";
                    return View();
                }

                if ((ad.state == null) || (ad.city == null))
                {
                    ViewBag.erroLocality = "Informações sobre o destino devem ser preenchidas.";
                    return View();
                }

                if (ad.local_exit == null)
                {
                    ViewBag.erroLocalExit = "Informe o local de saída. Ex: minha casa, a combinar...";
                }

                if (ad.quantity_people <= 0)
                {
                    ViewBag.erroQtdP = "É necessário no mínimo uma pessoa para solicitar carona.";
                    return View();
                }

                if (ad.maximum_route_value <= 0)
                {
                    ViewBag.erroMRV = "Informe o valor que pode colaborar no trajeto.";
                    return View();
                }

                int idUser = Convert.ToInt32(Session["id_user"]);
                adRepository.saveSearchRide(ad, idUser);

                return RedirectToAction("MyAds", "Users");

            }
            return View();

        }// Recebe o formulário de procura por carona

        [HttpGet]
        public ActionResult CreateAdOfferRide()
        {
            return View();
        }// Retorna a view

        [HttpPost]
        public ActionResult CreateAdOfferRide(Advertisement ad)
        {
            if (ModelState.IsValid)
            {
                if (ad.title == null)
                {
                    return View();
                }

                if (ad.expiration_date < DateTime.Now)
                {
                    ViewBag.erroDateEx = "A validade do anúncio não pode ser inferior a data atual.";
                    return View();
                }

                if (ad.departure_date < DateTime.Now)
                {
                    ViewBag.erroDepartureDate = "A data de saída não pode ser inferior a data atual.";
                    return View();
                }

                if ((ad.exitState == null) || (ad.exitTown == null))
                {
                    ViewBag.erroExit = "Informações sobre a local de saída devem ser preenchidas.";
                    return View();
                }

                if ((ad.state == null) || (ad.city == null))
                {
                    ViewBag.erroLocality = "Informações sobre o destino devem ser preenchidas.";
                    return View();
                }

                if (ad.quantity_people <= 0)
                {
                    ViewBag.erroQtdP = "É necessário vaga para no mínimo uma pessoa.";
                    return View();
                }

                if (ad.maximum_route_value <= 0)
                {
                    ViewBag.erroMRV = "Informe o valor para ajuda nos custos no trajeto.";
                    return View();
                }

                int idUser = Convert.ToInt32(Session["id_user"]);
                adRepository.saveOfferRide(ad, idUser);

                return RedirectToAction("MyAds", "Users");
            }

            return View();
        } // Recebe o formulário de oferta de carona

        [HttpGet]
        public ActionResult CreateCompanyAd()
        {
            return View();
        }// Retorna view de procura por companhia

        [HttpPost]
        public ActionResult CreateCompanyAd(Advertisement ad)
        {
            if (ModelState.IsValid)
            {
                if (ad.title == null)
                {
                    return View();
                }

                if (ad.expiration_date < DateTime.Now)
                {
                    ViewBag.erroDateEx = "A validade do anúncio não pode ser inferior a data atual.";
                    return View();
                }

                if ((ad.state == null) || (ad.city == null))
                {
                    ViewBag.erroLocality = "Informações sobre o destino devem ser preenchidas.";
                    return View();
                }

                if (ad.checkin < DateTime.Now)
                {
                    ViewBag.erroCheckin = "A data de checkin não pode ser inferior a data atual.";
                    return View();
                }

                if ((ad.checkout < DateTime.Now) || (ad.checkout < ad.checkin))
                {
                    ViewBag.erroCheckout = "A data de checkout não pode ser inferior a data atual ou a data de checkin.";
                    return View();
                }

                if (ad.finality == null)
                {
                    ViewBag.erroFinality = "É preciso informar uma finalidade para procurar uma companhia.";
                    return View();
                }

                int idUser = Convert.ToInt32(Session["id_user"]);
                adRepository.saveSearchCompany(ad, idUser);

                return RedirectToAction("MyAds", "Users");
            }

            return View();
        }// Recebe formulário de procura por companhia   
        #endregion

        #region edição de anúncios
        public ActionResult EditAd(int idAd, int idOwner, string type)
        {
            
            if (type == "Oferta Carona")
            {
                return RedirectToAction("EditAdOfferRide", new { idAd = idAd, idOwner = idOwner });
            }
            if (type == "Procura Carona")
            {
                return RedirectToAction("EditAdRide", new { idAd = idAd, idOwner = idOwner });
            }
            if (type == "Oferta Hospedagem")
            {
                return RedirectToAction("EditAdOfferHosting", new { idAd = idAd, idOwner = idOwner });
            }
            if (type == "Procura Hospedagem")
            {
                return RedirectToAction("EditAdHosting", new { idAd = idAd, idOwner = idOwner });
            }
            if (type == "Procura Companhia")
            {
                return RedirectToAction("EditAdCompany", new { idAd = idAd, idOwner = idOwner });
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditAdOfferRide(int idAd, int idOwner)
        {
            var ad = adRepository.getOneAd2(idOwner, idAd);
            return View(ad);
        }//Retorna view para editar anúncio oferta de carona ok

        [HttpPost]
        public ActionResult EditAdOfferRide(int idAd, EditAdOfferRide ad)
        {
            if (ModelState.IsValid)
            {
                if (ad.title == null)
                {
                    return View();
                }

                if (ad.expiration_date < DateTime.Now)
                {
                    ViewBag.erroDateEx = "A validade do anúncio não pode ser inferior a data atual.";
                    return View();
                }

                if (ad.departure_date < DateTime.Now)
                {
                    ViewBag.erroDepartureDate = "A data de saída não pode ser inferior a data atual.";
                    return View();
                }

                if ((ad.exitState == null) || (ad.exitTown == null))
                {
                    ViewBag.erroExit = "Informações sobre a local de saída devem ser preenchidas.";
                    return View();
                }

                if ((ad.state == null) || (ad.city == null))
                {
                    ViewBag.erroLocality = "Informações sobre o destino devem ser preenchidas.";
                    return View();
                }

                if (ad.quantity_people <= 0)
                {
                    ViewBag.erroQtdP = "É necessário vaga para no mínimo uma pessoa.";
                    return View();
                }

                if (ad.maximum_route_value <= 0)
                {
                    ViewBag.erroMRV = "Informe o valor para ajuda nos custos no trajeto.";
                    return View();
                }

                int idUser = Convert.ToInt32(Session["id_user"]);
                adRepository.editAdRide(ad, idUser, idAd);

                return RedirectToAction("MyAds", "Users");
            }
            else
            {
                return View();
            }
            
        }//Editar anúncio oferta carona ok

        [HttpGet]
        public ActionResult EditAdRide(int idAd, int idOwner)
        {
            var ad = adRepository.getOneAd2(idOwner, idAd);
            return View(ad);
        }// Retorna view para editar anúncio de procura por carona ok

        [HttpPost]
        public ActionResult EditAdRide(int idAd, int idOwner, EditAdOfferRide ad)
        {
            if (ModelState.IsValid)
            {
                if (ad.title == null)
                {
                    return View();
                }

                if (ad.expiration_date < DateTime.Now)
                {
                    ViewBag.erroDateEx = "A validade do anúncio não pode ser inferior a data atual.";
                    return View();
                }

                if (ad.departure_date < DateTime.Now)
                {
                    ViewBag.erroDepartureDate = "A data de saída não pode ser inferior a data atual.";
                    return View();
                }

                if ((ad.exitState == null) || (ad.exitTown == null))
                {
                    ViewBag.erroExit = "Informações sobre a local de saída devem ser preenchidas.";
                    return View();
                }

                if ((ad.state == null) || (ad.city == null))
                {
                    ViewBag.erroLocality = "Informações sobre o destino devem ser preenchidas.";
                    return View();
                }

                if (ad.local_exit == null)
                {
                    ViewBag.erroLocalExit = "Informe o local de saída. Ex: minha casa, a combinar...";
                    return View();

                }

                if (ad.quantity_people <= 0)
                {
                    ViewBag.erroQtdP = "É necessário no mínimo uma pessoa para solicitar carona.";
                    return View();
                }

                if (ad.maximum_route_value <= 0)
                {
                    ViewBag.erroMRV = "Informe o valor que pode colaborar no trajeto.";
                    return View();
                }

                int idUser = Convert.ToInt32(Session["id_user"]);
                adRepository.editAdRide(ad, idUser, idAd);

                return RedirectToAction("MyAds", "Users");
            }
            else
            {
                return View();
            }         
        }//Editar anúncio procura por carona ok

        [HttpGet]
        public ActionResult EditAdOfferHosting(int idAd, int idOwner)
        {
            var ad = adRepository.getOneAd3(idOwner, idAd);
            return View(ad);
        }//Retorna view para editar anuncio de oferta de hospedagem ok

        [HttpPost]
        public ActionResult EditAdOfferHosting(int idAd, EditAdOfferHosting ad)
        {
            if (ModelState.IsValid)
            {
                if (ad.title == null)
                {
                    return View();
                }

                if (ad.expiration_date < DateTime.Now)
                {
                    ViewBag.erroDateEx = "A validade do anúncio não pode ser inferior a data atual.";
                    return View();
                }

                if ((ad.state == null) || (ad.city == null))
                {
                    ViewBag.erroLocality = "Informações sobre a localidade devem ser preenchidas.";
                    return View();
                }

                if (ad.start < DateTime.Now)
                {
                    ViewBag.erroCheckin = "A data de início de disponibilidade não pode ser inferior a data atual.";
                    return View();
                }

                if ((ad.end < DateTime.Now) || (ad.end < ad.start))
                {
                    ViewBag.erroCheckout = "A data de checkout não pode ser inferior a data atual ou a data de início.";
                    return View();
                }

                if (ad.quantity_people <= 0)
                {
                    ViewBag.erroQtdP = "É necessário aceitar no mínimo uma pessoa";
                    return View();
                }

                if (ad.maximum_people_value <= 0)
                {
                    ViewBag.erroMPV = "Informe o valor diário máximo que deseja cobrar por pessoa.";
                    return View();
                }

                if (ad.accommodation_type == null)
                {
                    ViewBag.erroAT = "Informe o tipo de acomodação que deseja disponibilizar. Ex: Quarto confortável, etc.";
                    return View();
                }

                int idUser = Convert.ToInt32(Session["id_user"]);
                adRepository.editAdHosting(ad, idUser, idAd);

                return RedirectToAction("MyAds", "Users");
            }
            else
            {
                return View();
            }
        }// Editar anúncio oferta de hospedagem ok

        [HttpGet]
        public ActionResult EditAdHosting(int idAd, int idOwner)
        {
            var ad = adRepository.getOneAd4(idOwner, idAd);
            return View(ad);
        }//Retorna view para editar anúncio procura por hospedagem ok

        [HttpPost]
        public ActionResult EditAdHosting(int idAd, EditAdOfferHosting ad)
        {
            if (ModelState.IsValid)
            {
                if (ad.title == null)
                {
                    return View();
                }

                if (ad.expiration_date < DateTime.Now)
                {
                    ViewBag.erroDateEx = "A validade do anúncio não pode ser inferior a data atual.";
                    return View();
                }

                if ((ad.state == null) || (ad.city == null))
                {
                    ViewBag.erroLocality = "Informações sobre o destino devem ser preenchidas.";
                    return View();
                }

                if (ad.checkin < DateTime.Now)
                {
                    ViewBag.erroCheckin = "A data de checkin não pode ser inferior a data atual.";
                    return View();
                }

                if ((ad.checkout < DateTime.Now) || (ad.checkout < ad.checkin))
                {
                    ViewBag.erroCheckout = "A data de checkout não pode ser inferior a data atual ou a data de checkin.";
                    return View();
                }

                if (ad.quantity_people <= 0)
                {
                    ViewBag.erroQtdP = "É necessário ter no mínimo uma pessoa";
                    return View();
                }

                if (ad.maximum_people_value <= 0)
                {
                    ViewBag.erroMPV = "Informe o valor diário máximo que deseja gastar por pessoa.";
                    return View();
                }

                if (ad.accommodation_type == null)
                {
                    ViewBag.erroAT = "Informe o tipo de acomodação que deseja encontrar. Ex: Quarto confortável, etc.";
                    return View();
                }

                int idUser = Convert.ToInt32(Session["id_user"]);
                adRepository.editAdHosting1(ad, idUser, idAd);

                return RedirectToAction("MyAds", "Users");
            }
            else
            {
                return View();
            }
            
        } //Editar anúncio procura por hospedagem ok

        [HttpGet]
        public ActionResult EditAdCompany(int idAd, int idOwner)
        {
            var ad = adRepository.getOneAd1(idOwner, idAd);
            return View(ad);
        }//ok

        [HttpPost]
        public ActionResult EditAdCompany(EditAdCompany ad, int idAd)
        {
            if (ModelState.IsValid)
            {
                if (ad.title == null)
                {
                    return View();
                }

                if (ad.expiration_date < DateTime.Now)
                {
                    ViewBag.erroDateEx = "A validade do anúncio não pode ser inferior a data atual.";
                    return View();
                }

                if ((ad.state == null) || (ad.city == null))
                {
                    ViewBag.erroLocality = "Informações sobre o destino devem ser preenchidas.";
                    return View();
                }

                if (ad.checkin < DateTime.Now)
                {
                    ViewBag.erroCheckin = "A data de checkin não pode ser inferior a data atual.";
                    return View();
                }

                if ((ad.checkout < DateTime.Now) || (ad.checkout < ad.checkin))
                {
                    ViewBag.erroCheckout = "A data de checkout não pode ser inferior a data atual ou a data de checkin.";
                    return View();
                }

                if (ad.finality == null)
                {
                    ViewBag.erroFinality = "É preciso informar uma finalidade para procurar uma companhia.";
                    return View();
                }

                int idUser = Convert.ToInt32(Session["id_user"]);
                adRepository.editAdCompany(ad, idUser, idAd);

                return RedirectToAction("MyAds", "Users");
            }
            else
            {
                return View();
            }

        }//ok

        #endregion

        #region ok
        public ActionResult DisableAd(int idAd)
        {
            int active = 0;
            adRepository.ChangeStatusAnnouncement(idAd, active);

            return RedirectToAction("MyAds", "Users");
        }

        public ActionResult DisableAdTimeLine(int idAd, string state)
        {
            int active = 0;
            adRepository.ChangeStatusAnnouncement(idAd, active);

            return RedirectToAction("ListAdTimeLine", new { state = state });
        }

        public ActionResult ActivateAd(int idAd)
        {
            int active = 1;
            adRepository.ChangeStatusAnnouncement(idAd, active);

            return RedirectToAction("MyAds", "Users");
        }

        [HttpGet]
        public ActionResult ListAdTimeLine(string state)
        {
            DateTime currentDate = DateTime.Now;
            int idUser = Convert.ToInt32(Session["id_user"]);
            var ad = adRepository.listAdTimeLine(state, currentDate, idUser);
            ViewBag.idUser = idUser;
            return View(ad);
        }

        public ActionResult DeleteAd(int idAd, int idOwner)
        {
            adRepository.deleteAd(idAd, idOwner);
            return RedirectToAction("MyAds", "Users");
        }

        public ActionResult DeleteAdTimeLine(int idAd, int idOwner, string pState)
        {
            adRepository.deleteAd(idAd, idOwner);
            return RedirectToAction("ListAdTimeLine", "Advertisement", new { state = pState });
        }

        public ActionResult ListAdTimeLineType(string type)
        {
            if (type == "Oferta Carona")
            {
                DateTime currentDate = DateTime.Now;
                int idUser = Convert.ToInt32(Session["id_user"]);
                var ad = adRepository.listAdType(type, currentDate);
                ViewBag.idUser = idUser;
                ViewBag.type = "Ofertas de Carona";
                return View(ad);
            }
            if (type == "Procura Carona")
            {
                DateTime currentDate = DateTime.Now;
                int idUser = Convert.ToInt32(Session["id_user"]);
                var ad = adRepository.listAdType(type, currentDate);
                ViewBag.idUser = idUser;
                ViewBag.type = "Buscas por Carona";
                return View(ad);
            }
            if (type == "Oferta Hospedagem")
            {
                DateTime currentDate = DateTime.Now;
                int idUser = Convert.ToInt32(Session["id_user"]);
                var ad = adRepository.listAdType(type, currentDate);
                ViewBag.idUser = idUser;
                ViewBag.type = "Ofertas de Hospedagem";
                return View(ad);
            }
            if (type == "Procura Hospedagem")
            {
                DateTime currentDate = DateTime.Now;
                int idUser = Convert.ToInt32(Session["id_user"]);
                var ad = adRepository.listAdType(type, currentDate);
                ViewBag.idUser = idUser;
                ViewBag.type = "Buscas por Hospedagem";
                return View(ad);
            }
            if (type == "Procura Companhia")
            {
                DateTime currentDate = DateTime.Now;
                int idUser = Convert.ToInt32(Session["id_user"]);
                var ad = adRepository.listAdType(type, currentDate);
                ViewBag.idUser = idUser;
                ViewBag.type = "Buscas por Companhia";
                return View(ad);
            }
            return View();

        }

        public ActionResult DeleteAdTimeLineType(int idAd, int idOwner, string type)
        {
            adRepository.deleteAd(idAd, idOwner);
            return RedirectToAction("ListAdTimeLineType", "Advertisement", new { type = type });
        }

        public ActionResult OfferRideSearch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OfferRideSearchList(RideSearch rs)
        {
            if (ModelState.IsValid)
            {
                ViewBag.exitState = rs.exitState;
                ViewBag.exitCity = rs.exitTown;
                ViewBag.state = rs.state;
                ViewBag.city = rs.city;
                int idUser = Convert.ToInt32(Session["id_user"]);
                ViewBag.idUser = idUser;
                ViewBag.type = "Ofertas de Carona";
                string type = "Oferta Carona";
                var ad = adRepository.listAdRide(rs, type);
                return View(ad);
            }
            string type1 = "Oferta Carona";
            return RedirectToAction("ListAdTimeLineType", new { type = type1 });
        }

        public ActionResult RideSearch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RideSearchList(RideSearch rs)
        {
            if (ModelState.IsValid)
            {
                ViewBag.exitState = rs.exitState;
                ViewBag.exitCity = rs.exitTown;
                ViewBag.state = rs.state;
                ViewBag.city = rs.city;
                int idUser = Convert.ToInt32(Session["id_user"]);
                ViewBag.idUser = idUser;
                ViewBag.type = "Buscas por Carona";
                string type = "Procura Carona";
                var ad = adRepository.listAdRide(rs, type);
                return View(ad);
            }
            string type1 = "Procura Carona";
            return RedirectToAction("ListAdTimeLineType", new { type = type1 });
        }

        public ActionResult OfferHostingSearch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OfferHostingList(HostingSearch hs)
        {
            if (ModelState.IsValid)
            {
                ViewBag.state = hs.state;
                ViewBag.city = hs.city;
                int idUser = Convert.ToInt32(Session["id_user"]);
                ViewBag.idUser = idUser;
                ViewBag.type = "Ofertas de Hospedagem";
                string type = "Oferta Hospedagem";
                var ad = adRepository.listAdHosting(hs, type);
                return View(ad);
            }
            string type1 = "Oferta Hospedagem";
            return RedirectToAction("ListAdTimeLineType", new { type = type1 });
        }

        public ActionResult HostingSearch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HostingSearchList(HostingSearch hs)
        {
            if (ModelState.IsValid)
            {
                ViewBag.state = hs.state;
                ViewBag.city = hs.city;
                int idUser = Convert.ToInt32(Session["id_user"]);
                ViewBag.idUser = idUser;
                ViewBag.type = "Buscas por Hospedagem";
                string type = "Procura Hospedagem";
                var ad = adRepository.listAdHosting(hs, type);
                return View(ad);
            }
            string type1 = "Procura Hospedagem";
            return RedirectToAction("ListAdTimeLineType", new { type = type1 });

        }

        public ActionResult CompanySearch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CompanySearchList(HostingSearch hs)
        {
            if (ModelState.IsValid)
            {
                ViewBag.state = hs.state;
                ViewBag.city = hs.city;
                int idUser = Convert.ToInt32(Session["id_user"]);
                ViewBag.idUser = idUser;
                ViewBag.type = "Buscas por Companhia";
                string type = "Procura Companhia";
                var ad = adRepository.listAdHosting(hs, type);
                return View(ad);
            }
            string type1 = "Procura Companhia";
            return RedirectToAction("ListAdTimeLineType", new { type = type1 });

        } 
        #endregion
    }

}