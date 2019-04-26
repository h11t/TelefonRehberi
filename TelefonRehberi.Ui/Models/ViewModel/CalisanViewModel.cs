using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelefonRehberi.Entity;

namespace TelefonRehberi.Ui.Models.ViewModel
{
    public class CalisanViewModel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Departman { get; set; }
        public string Yonetici { get; set; }
        public Calisan   Calisan { get; set; }
        public List<Calisan> CalisanList { get; set; }

    }
}