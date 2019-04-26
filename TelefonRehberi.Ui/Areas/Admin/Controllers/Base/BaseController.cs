using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Bll.DataServices;
using TelefonRehberi.Dal.Entity;
using TelefonRehberi.Ui.Helper;

namespace TelefonRehberi.Ui.Areas.Admin.Controllers.Base
{
    public class BaseController : Controller
    {
        public RehberContext context;
        public CalisanRepository CalisanRepository;
        public DepartmanRepository DepartmanRepository;

        public BaseController()
        {
            context = new RehberContext();
            CalisanRepository = new CalisanRepository(context);
            DepartmanRepository = new DepartmanRepository(context);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            bool LoginState = false;
            HttpCookie cookie = Request.Cookies[ConfigurationManager.AppSettings["key"].ToString()];
            if (cookie != null)
            {
                string BeklenenKullaniciAdi = Crypto.Encrypt(System.Configuration.ConfigurationManager.AppSettings["KullaniciAdi"].ToString(), "a61", true);
                string BeklenenSifre = Crypto.Encrypt(System.Configuration.ConfigurationManager.AppSettings["Sifre"].ToString(), "a61", true);

                string GelenUser = cookie["User"].ToString();
                string GelenSifre = cookie["pass"].ToString();

                if (GelenUser == BeklenenKullaniciAdi && BeklenenSifre == GelenSifre)
                {
                    LoginState = true;
                }
            }
            if (LoginState == false)
            {
                filterContext.Result = new RedirectResult("~/AdminUI/Login");
            }

            string ActionName = filterContext.RouteData.Values["Action"].ToString();
            string ControllerName = filterContext.RouteData.Values["Controller"].ToString();

            ViewBag.Path = "/areas/admin/content";
            ViewBag.DuyuruSayisi = 1;
            base.OnActionExecuted(filterContext);

        }
    }
}