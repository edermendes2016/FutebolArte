using System;
using appfutebol.Dominio;

namespace appfutebol.Repositorio.Infraestrutura
{
    public class RepositorioTabela : Repository<Tabela>
    {
        public RepositorioTabela() : base (new FutebolContext())
        {
            
        }

        public override Tabela Adicionar(Tabela entidade)
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