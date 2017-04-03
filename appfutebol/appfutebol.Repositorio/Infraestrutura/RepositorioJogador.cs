using System;
using System.Collections.Generic;
using appfutebol.Dominio;
using Dapper;

namespace appfutebol.Repositorio.Infraestrutura
{
    public class RepositorioJogador : Repository<Jogador>, IJogador
    {
        public RepositorioJogador() : base(new FutebolContext())
        {
        }

        public IEnumerable<Jogador> ObterAtivos()
        {
            var sql = "SELECT c.Id as 'Id', c.* FROM Jogador c where Ativo = 1";
            //throw new Exception("THE TRETA HAS BEEN PLANTED!!!!");

            return Db.Database.Connection.Query<Jogador>(sql);
        }
        public override Jogador Adicionar(Jogador entidade)
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

        public IEnumerable<Jogador> Artilheiros()
        {
            var sql = "SELECT [Nome] FROM [appFutebol].[dbo].[Jogador] ORDER BY [GolFeitos] ";

            //throw new Exception("THE TRETA HAS BEEN PLANTED!!!!");

            return Db.Database.Connection.Query<Jogador>(sql);
        }

       
    }

}

