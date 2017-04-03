using System.Collections.Generic;
using System.Linq.Expressions;
using appfutebol.Dominio;

namespace appfutebol.Repositorio.Infraestrutura
{
    public interface IJogador : IRepositorio<Jogador>
    {
        IEnumerable<Jogador> ObterAtivos();
        IEnumerable<Jogador> Artilheiros();
        
    }
}