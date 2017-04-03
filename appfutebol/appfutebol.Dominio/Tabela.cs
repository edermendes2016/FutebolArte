using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appfutebol.Dominio
{
    public class Tabela : DominioBase
    {
        public Tabela()
        {
           
        }
        public int Pontos { get; set; }
        public int GolFeito { get; set; }
        public int GolSofrido { get; set; }
        public Guid? chvTabelaClube { get; set; }
        [ForeignKey("chvTabelaClube")]
        public virtual Clube Clube { get; set; }

    }
}



