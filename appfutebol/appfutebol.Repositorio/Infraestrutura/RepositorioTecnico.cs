using System;
using System.Linq.Expressions;
using appfutebol.Dominio;

namespace appfutebol.Repositorio.Infraestrutura
{
    public class RepositorioTecnico : Repository<Tecnico>
    {
        public RepositorioTecnico() : base (new FutebolContext())
        {
        }

        public override Tecnico Adicionar(Tecnico entidade)
        {
            var entidadeAdd = Dbset.Add(entidade);
            entidadeAdd.Ativo = true;
            entidadeAdd.DataInclusao = DateTime.Now;
            SaveChanges();
            return entidadeAdd;
        }

        public override void Remover(Guid id)
        {
            var campeonato = ObterPorId(id);
            campeonato.Excluido = true;
            Atualizar(campeonato);
        }

    }
}