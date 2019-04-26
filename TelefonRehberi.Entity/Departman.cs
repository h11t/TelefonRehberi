using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entity.Model;

namespace TelefonRehberi.Entity
{
    [Table("Departman")]
    public class Departman:BaseEntity
    {
        public Departman()
        {
            Calisans = new HashSet<Calisan>();
        }
        

        public virtual ICollection<Calisan> Calisans { get; set; }
    }
}
