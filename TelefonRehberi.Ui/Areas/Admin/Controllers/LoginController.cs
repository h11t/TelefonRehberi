using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Ui.Areas.Admin.Models.ViewModel;
using TelefonRehberi.Ui.Helper;

namespace TelefonRehberi.Ui.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {

            ViewBag.Path = "/areas/admin/content";
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                string gelenkullaniciadi = lvm.KullaniciAdi;
                string gelensifre = lvm.Sifre;

                if (lvm.KullaniciAdi == System.Configuration.ConfigurationManager.AppSettings["KullaniciAdi"].ToString() && lvm.Sifre == System.Configuration.ConfigurationManager.AppSettings["Sifre"].ToString())
                {
                    //Giriş Yapılacak
                    HttpCookie myCookie = new HttpCookie(System.Configuration.ConfigurationManager.AppSettings["key"].ToString());
                    myCookie["User"] = Crypto.Encrypt(lvm.KullaniciAdi.ToString(), "a61", true);
                    myCookie["pass"] = Crypto.Encrypt(lvm.Sifre.ToString(), "a61", true);

                    myCookie.Expires = DateTime.Now.AddMinutes(5);
                    Response.Cookies.Add(myCookie);
                    Response.Redirect("~/AdminUI/Home");
                }
                else
                {
                    ViewBag.ErrorText = "Hatalı İşlem Şifre Yanlış";
                }
            }
            ViewBag.Path = "/areas/admin/content";
            return View();
        }
    }
}