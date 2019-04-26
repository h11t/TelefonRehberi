using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Entity;
using TelefonRehberi.Ui.Areas.Admin.Controllers.Base;

namespace TelefonRehberi.Ui.Areas.Admin.Controllers
{
    public class DepartmanController : BaseController
    {
        public ActionResult Listele()
        {
            return View(DepartmanRepository.GetList().ToList());
        }

        #region Ekle
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Departman model)
        {
            try
            {
                Departman d = new Departman();
                d.Ad = model.Ad;
                DepartmanRepository.Add(d);
                DepartmanRepository.Save();
                ViewBag.SuccessText = "Kayıt Başarı ile eklendi";
                return RedirectToAction("Listele");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorText = " Hata Açıklaması: " + ex.ToString();
                return View(model);
            }
        }

        #endregion Ekle


        #region Sil
        public string AjaxDeleteDepartman()
        {
            // 0 - silme işlemi başarısız oldu
            // 1 - Silme işlemi başarılı oldu
            string donenkod = "0";
            int ID = Convert.ToInt32(Request.Form["id"]);
            Departman d = DepartmanRepository.Find(ID);
            if (d.Calisans.Count > 0)
            {
                return donenkod;
            }
            else
            {
                try
                {
                    DepartmanRepository.Delete(ID);
                    DepartmanRepository.Save();

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