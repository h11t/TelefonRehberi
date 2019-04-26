using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.Entity.Model
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Ad { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime EklenmeTarihi { get; set; }
        public DateTime? GuncellenmeTarihi { get; set; }

    }
}
