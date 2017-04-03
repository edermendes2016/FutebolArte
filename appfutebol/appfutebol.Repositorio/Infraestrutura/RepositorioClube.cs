using System;
using System.Collections.Generic;
using System.Linq;
using appfutebol.Dominio;
using Dapper;

namespace appfutebol.Repositorio.Infraestrutura
{
    public class RepositorioClube : Repository<Clube>, IClube
    {
        public RepositorioClube() : base(new FutebolContext()) 
        {
        }
        public IEnumerable<Clube> ObterAtivos()
        {
            var sql = "SELECT c.Id as 'Id', c.* FROM Clube c where Ativo = 1";
            //throw new Exception("THE TRETA HAS BEEN PLANTED!!!!");

            return Db.Database.Connection.Query<Clube>(sql);
        }
        public override Clube Adicionar(Clube entidade)
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

        public Clube ObterNome(string nome)
        {
            return Buscar(c => c.Nome == nome).FirstOrDefault();
        }
    }
}

