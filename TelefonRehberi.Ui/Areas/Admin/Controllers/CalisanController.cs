using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Entity;
using TelefonRehberi.Ui.Areas.Admin.Controllers.Base;

namespace TelefonRehberi.Ui.Areas.Admin.Controllers
{
    public class CalisanController : BaseController
    {
        // GET: Admin/Calisan
        public ActionResult Listele()
        {   

            return View(CalisanRepository.GetList());
        }

        void DepartmanYukle(int DepartmanId)
        {
            List<SelectListItem> SelectList = new List<SelectListItem>();
            List<Departman> DepartmanList = DepartmanRepository.GetList().ToList();
            foreach (var item in DepartmanList)
            {
                bool state = false;
                if (DepartmanId == item.Id)
                { state = true; }

                SelectList.Add(new SelectListItem { Text = item.Ad, Value = item.Id.ToString(), Selected = state });
            }
            ViewBag.DepartmanID = SelectList;
        }
        void YoneticiYukle(int CalisanId)
        {
            List<SelectListItem> SelectList = new List<SelectListItem>();
            List<Calisan> CalisanList = CalisanRepository.GetList().ToList();
            foreach (var item in CalisanList)
            {
                bool state = false;
                if (CalisanId == item.Id)
                { state = true; }

                SelectList.Add(new SelectListItem { Text = item.Ad+" "+item.Soyad, Value = item.Id.ToString(), Selected = state });
            }
            ViewBag.Yoneticiler = SelectList;
        }

        #region Ekle
        public ActionResult Ekle()
        {
            DepartmanYukle(0);
            YoneticiYukle(0);
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Ekle(Calisan model)
        {
            Calisan calisan = new Calisan();
            calisan.Ad = Request["Ad"].ToString();
            calisan.Soyad = Request["Soyad"].ToString();
            calisan.Telefon = Request["Telefon"].ToString();
            calisan.DepartmanId = Convert.ToInt32(Request["DepartmanID"]);
            //calisan.YoneticiBilgisiId= CalisanRepository().Find;
            if (Request["Yoneticiler"] != null)
                calisan.YoneticiBilgisiId = Convert.ToInt32(Request["Yoneticiler"]);
            try
            {
                CalisanRepository.Add(calisan);
                CalisanRepository.Save();
                return RedirectToAction("Listele");
            }
            catch (Exception)
            {
                return View(model);
            }
          
        }

        #endregion Ekle

        #region Edit
        public ActionResult Edit()
        {
            int ID = Convert.ToInt32(RouteData.Values["id"]);


            Calisan c = CalisanRepository.FirstOrDefault(x => x.Id == ID);


            List<Calisan> liste = CalisanRepository.GetList().ToList();

            DepartmanYukle(c.DepartmanId);

            YoneticiYukle((Int32)c.YoneticiBilgisiId);
            
            return View(c);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Calisan model)
        {
            int ID = Convert.ToInt32(RouteData.Values["id"]);
            int DepartmanId = Convert.ToInt32(Request["DepartmanID"]);
            Calisan calisan = CalisanRepository.FirstOrDefault(x => x.Id == ID);
            calisan.Ad = Request["Ad"].ToString();
            calisan.Soyad = Request["Soyad"].ToString();
            calisan.Telefon = model.Telefon;
            calisan.DepartmanId = DepartmanId;
            calisan.YoneticiBilgisiId = model.YoneticiBilgisiId;

            try
            {
                CalisanRepository.Update(calisan);
                CalisanRepository.Save();
                return RedirectToAction("Listele");
            }
            catch (Exception)
            {
                return View(model);
            }
        }
        #endregion Edit

        #region Sil
        public string AjaxDeleteCalisan()
        {
            // 0 - silme işlemi başarısız oldu
            // 1 - Silme işlemi başarılı oldu
            string donenkod = "0";
            int ID = Convert.ToInt32(Request.Form["id"]);
            Calisan calisan = CalisanRepository.Find(ID);
            int YoneticiMi = CalisanRepository.Count(x => x.YoneticiBilgisiId == calisan.Id);
            if (YoneticiMi>0)
            {
                return donenkod;
            }
            else
            {
                try
                {
                    CalisanRepository.Delete(ID);
                    CalisanRepository.Save();

                    donenkod = "1";
                }
                catch (Exception ex)
                {
                }
                return donenkod;
            }
        }
        #endregion Sil
    }
}