using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appfutebol.Dominio
{
    public class Tecnico : Funcionario
    {
      
        public virtual string Apelido { get; set; }
        public Guid? chvtecClube { get; set; }
        [ForeignKey("chvtecClube")]
        public virtual Clube Clube { get; set; }
        public Guid? chvtecJogo { get; set; }
        [ForeignKey("chvtecJogo")]
        public virtual Jogo Jogo { get; set; }


    } 
}
