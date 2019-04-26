using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Bll.BaseServices;
using TelefonRehberi.Dal.Entity;
using TelefonRehberi.Entity;

namespace TelefonRehberi.Bll.DataServices
{
   public class CalisanRepository:GenericRepository<Calisan>
    {
        public CalisanRepository(RehberContext context):base(context)
        {

        }
    }
}
