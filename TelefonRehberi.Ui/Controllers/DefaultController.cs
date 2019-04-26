using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Bll.DataServices;
using TelefonRehberi.Dal.Entity;
using TelefonRehberi.Entity;
using TelefonRehberi.Ui.Models.ViewModel;

namespace TelefonRehberi.Ui.Controllers
{
    public class DefaultController : Controller
    {
        CalisanRepository repository = new CalisanRepository(new RehberContext());
        // GET: Home
        public ActionResult Index()
        {
            List<Calisan> liste=repository.GetList().ToList();
            return View(new CalisanViewModel {  CalisanList=liste});
        }
        public ActionResult Details(int id)
        {
            CalisanViewModel model = new CalisanViewModel();
            model.Calisan=repository.FirstOrDefault(x => x.Id == id);
            model.Yonetici = repository.FirstOrDefault(x => x.Id == model.Calisan.YoneticiBilgisiId).Ad+" " + repository.FirstOrDefault(x => x.Id == model.Calisan.YoneticiBilgisiId).Soyad;
            return View(model);
        }
    }
}