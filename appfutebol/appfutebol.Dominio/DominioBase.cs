using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appfutebol.Dominio
{
   public class DominioBase
    {

       public DominioBase()
       {
           Id = Guid.NewGuid();
       }
        public Guid Id { get;  set; }
        public DateTime DataInclusao { get;  set; }
        public bool Ativo { get;  set; }
        public bool Excluido { get;  set; }
    }
}
