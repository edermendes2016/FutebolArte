using System.Collections.Generic;
using appfutebol.Dominio;

namespace appfutebol.Repositorio.Infraestrutura
{
    public interface IClube : IRepositorio<Clube>
    {
        Clube ObterNome(string nome);
        IList<Clube> ObterAtivos();
    }
}