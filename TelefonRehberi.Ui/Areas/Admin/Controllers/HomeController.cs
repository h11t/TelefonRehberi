using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Ui.Areas.Admin.Controllers.Base;
using TelefonRehberi.Ui.Areas.Admin.Models.ViewModel;
using TelefonRehberi.Ui.Helper;

namespace TelefonRehberi.Ui.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel();
            hvm.ToplamCalisan = CalisanRepository.Count(x => x.Id > 0);
            hvm.ToplamDepartman = DepartmanRepository.Count(x => x.Id > 0);
            return View(hvm);
        }

        public ActionResult Logout()
        {
            Response.Cookies[System.Configuration.ConfigurationManager.AppSettings["key"].ToString()].Expires = DateTime.Now.AddDays(-1);

            Response.Redirect("~/AdminUI/");
            return View();

        }
        public ActionResult SifreDegistir()
        {
            LoginViewModel lvm = new LoginViewModel();
            lvm.KullaniciAdi = System.Configuration.ConfigurationManager.AppSettings["KullaniciAdi"].ToString();
            lvm.Sifre= System.Configuration.ConfigurationManager.AppSettings["Sifre"].ToString();
            return View(lvm);
        }

        [HttpPost]
        public ActionResult SifreDegistir(LoginViewModel model)
        {
            string yenisifre= Request["YeniSifre"].ToString();
            System.Configuration.ConfigurationManager.AppSettings.Set("Sifre", yenisifre);
            return RedirectToAction("SifreDegistir");
        }
    }
}