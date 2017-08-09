using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaroneiroWeb.Repositories;
using System.Web.Helpers;
using System.Drawing;


namespace CaroneiroWeb.Controllers
{
    public class ImagesController : Controller
    {
        ImagesRepository imagesRepository = new ImagesRepository();

        // GET: Images
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }// Retorna a view com a opção de upload

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return View();
            }

            int idUser = Convert.ToInt32(Session["id_user"]);
            string fileExt = Path.GetExtension(file.FileName);
            bool validImage = false;


            foreach (string ext in new string[] { ".gif", ".jpeg", ".jpg", ".png" })
            {
                if (fileExt == ext)
                    validImage = true;
            }

            if ((file.ContentLength > 0) && (validImage != false)) // Confere se o arquivo enviado tem mais de 0 bytes
            {
                        

                String[] strName = file.FileName.Split('.');
                String strExt = strName[strName.Count() - 1];
                string pathSave = String.Format("{0}{1}.{2}", Server.MapPath("~/Upload/"), idUser, strExt);
                String pathBase = String.Format("/Upload/{0}.{1}", idUser, strExt);

                //salva caminho da imagem no banco
                imagesRepository.saveImagePath(pathBase, idUser);
                Session["image"] = pathBase;

                file.SaveAs(pathSave);
                ViewBag.uploadFile = "Imagem salva com sucesso!";
                

                return View();
            }
            else
            {
                ViewBag.uploadFile = "Seu upload falhou!";
                return View();
            }

        } //Função que realizia o upload de uma imagem para o diretório e salva seu caminho no banco

        [HttpGet]
        public ActionResult DeleteProfilePhoto()
        {
            int idUser = Convert.ToInt32(Session["id_user"]);
            var path = "/Design/images/user.png";
            Session["image"] = path;
            imagesRepository.saveImagePath(path, idUser);
            return RedirectToAction("UploadFile");
        }


    }
}