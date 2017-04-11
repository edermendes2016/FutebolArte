using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appfutebol.Dominio
{
    public class Funcionario : DominioBase
    {
        public  string Nome { get;  set; }
        
        public  double Salario { get; set; }
        public  DateTime InicioContrato { get;  set; }
        public  DateTime FinalContrato { get;  set; }
        
    }
}
