using System;
using appfutebol.Dominio;

namespace appfutebol.Repositorio.Infraestrutura
{
    public class RepositorioJogo : Repository<Jogo>
    {
        public RepositorioJogo() : base(new FutebolContext())
        {
        }

        public override Jogo Adicionar(Jogo entidade)
        {
            var entidadeAdd = Dbset.Add(entidade);
            entidadeAdd.Ativo = true;
            entidadeAdd.DataInclusao = DateTime.Now;
            SaveChanges();
            return entidadeAdd;
        }

        public override void Remover(Guid id)
        {
            var entidadeAdd = ObterPorId(id);
            entidadeAdd.Excluido = true;
            Atualizar(entidadeAdd);
        }
    }
}