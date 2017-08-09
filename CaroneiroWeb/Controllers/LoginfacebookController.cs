using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaroneiroWeb.Repositories;
using CaroneiroWeb.Models;
using Facebook;
using Newtonsoft.Json;
using System.Web.Security;

namespace CaroneiroWeb.Controllers
{
    public class LoginfacebookController : Controller
    {
        AccessRepository accessRepository = new AccessRepository();
        SettingsRepository settingsRepository = new SettingsRepository();

        // GET: Loginfacebook
        public ActionResult Index()
        {
            return View();
        }

        private Uri RediredtUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("facebookCallback");
                return uriBuilder.Uri;
            }
        }

        [AllowAnonymous]
        public ActionResult Facebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id= "450966571933372",
                client_secret = "827dcd9ca816f814e42b84f49f7bff7f",
                redirect_uri = RediredtUri.AbsoluteUri,
                response_type ="code",
                scope ="email" 
            });
            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            try
            {
                var fb = new FacebookClient();

                dynamic result = fb.Post("oauth/access_token", new
                {
                    client_id = "450966571933372",
                    client_secret = "827dcd9ca816f814e42b84f49f7bff7f",
                    redirect_uri = RediredtUri.AbsoluteUri,
                    code = code
                });

                var accessToken = result.access_token;
                Session["AccessToken"] = accessToken;

                fb.AccessToken = accessToken;
                dynamic me = fb.Get("me?fields=link,first_name,currency,last_name,email,gender,locale,timezone,verified,picture.type(large),age_range");
                string email = me.email;
                string name = me.first_name;
                string locale = me.locale;
                string gender = me.gender;
                string picture = me.picture.data.url;

                bool emailVerify = accessRepository.verifyEmail(email);
                if (emailVerify == true)
                {
                    Users authenticated_User = accessRepository.authenticateUserFaceboook(email);

                    NotificationMessages nm = accessRepository.notificationMessage(authenticated_User.id_user);
                    Notification ni = accessRepository.notificationInterested(authenticated_User.id_user);
                    Notification np = accessRepository.notificationParticipation(authenticated_User.id_user);
                    int numMsg = nm.qtdMsg;
                    int numNI = ni.qtd;
                    int numNP = np.qtdP;

                    if (authenticated_User.active == 0)
                    {
                        int disabled = 1;
                        settingsRepository.changeAccountStatus(disabled, authenticated_User.id_user);

                    }

                    Session["numNP"] = numNP;
                    Session["numNI"] = numNI;
                    Session["qtdMsg"] = numMsg;
                    Session["image"] = authenticated_User.image;
                    Session["name_user"] = authenticated_User.name_user;
                    Session["id_user"] = authenticated_User.id_user;
                    Session["state"] = authenticated_User.state;

                    if (authenticated_User.access == 0)
                    {
                        return RedirectToAction("AccessEditPerfil", "Users");
                    }
                    return RedirectToAction("ListAdTimeLine", "Advertisement", authenticated_User.state);

                }
                if (emailVerify == false)
                {
                    Users user = new Users();
                    user.name_user = name;

                    if (gender == "female")
                    {
                        user.genre = "Mulher";
                    }
                    else
                    {
                        user.genre = "Homem";
                    }
                    user.email = email;
                    user.image = picture;
                    user.date_birth = Convert.ToDateTime("01/01/0001");
                    user.city = "não informado";
                    user.state = "não informado";
                    user.password_user = "senhaloginfacebook0127382738493823";
                    accessRepository.registerFacebook(user);

                    Users authenticated_User = accessRepository.authenticateUserFaceboook(email);
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

                    return RedirectToAction("AccessEditPerfil", "Users");

                }
            }
            catch
            {
                return RedirectToAction("Login", "Access");
            }
                   
            return View();
        }
    }
}