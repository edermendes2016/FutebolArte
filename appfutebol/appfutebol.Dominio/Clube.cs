using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appfutebol.Dominio
{
    public class Clube : DominioBase
    {
        public Clube()
        {
            //StudentsList = new List<Student>();
            Jogadores = new List<Jogador>();
            Tecnicos = new List<Tecnico>();
        }

        public  string Nome { get; set; }
        public  string Sigla { get; set; }
        public int GF { get; set; }
        public int GS { get; set; }
        public int Pontos { get; set; }
        public ICollection<Jogador> Jogadores { get;  set; }
        public ICollection<Tecnico> Tecnicos { get;  set; }
    }
}
