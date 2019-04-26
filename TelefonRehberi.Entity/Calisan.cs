using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entity.Model;

namespace TelefonRehberi.Entity
{   
    [Table("Calisan")]
    public class Calisan:BaseEntity
    {
        [Required]
        public string Soyad { get; set; }

        [Required][DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; }
        public int?  YoneticiBilgisiId{ get; set; }

        public int DepartmanId { get; set; }

        [ForeignKey("DepartmanId")]
        public virtual Departman Departman { get; set; }
    }
}
