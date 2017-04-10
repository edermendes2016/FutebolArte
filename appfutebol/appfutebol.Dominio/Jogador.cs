using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appfutebol.Dominio
{
   public class Jogador : Funcionario
    {
       public Jogador()
       {
            
       }

        public  string Posicao { get;  set; }
        public  int GolFeitos { get; set; }
        public Guid? chvClube { get;  set; }
        [ForeignKey("chvClube")]
        public virtual Clube Clube { get;  set; }
        public Guid? chvJogo { get;  set; } 
        [ForeignKey("chvJogo")]
        public virtual Jogo Jogo { get;  set; } 




    }
}
