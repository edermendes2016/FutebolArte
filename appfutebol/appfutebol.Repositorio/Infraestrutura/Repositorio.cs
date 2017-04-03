using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace appfutebol.Repositorio.Infraestrutura
{
    
    public abstract class Repository<TEntidade> : IDisposable, IRepositorio<TEntidade> where TEntidade : class 
    {
        protected FutebolContext Db;
        protected DbSet<TEntidade> Dbset;
        private readonly FutebolContext futebolContext;
        
        public Repository(FutebolContext futebolContext)
        {
            Db = new FutebolContext();
            Dbset = Db.Set<TEntidade>();
            this.futebolContext = futebolContext;
        }
        
        public virtual TEntidade Adicionar(TEntidade entidade)
        {
            var entidadeAdd = Dbset.Add(entidade);
            SaveChanges();
            return entidadeAdd;
        }

        public virtual TEntidade Atualizar(TEntidade entidade)
        {
            var entry = Db.Entry(entidade);
            Dbset.Attach(entidade);
            entry.State = EntityState.Modified;
            SaveChanges();
            return entidade;
        }
        public virtual IEnumerable<TEntidade> Buscar(Expression<Func<TEntidade, bool>> predicate)
        {
            var query = Dbset.Where(predicate);
            return query.ToList();

        }
        
        public virtual TEntidade ObterPorId(Guid id)
        {
            return Dbset.Find(id);
        }
        public virtual IEnumerable<TEntidade> ObterTodos()
        {
            return Dbset.ToList();
        }

        public virtual void Remover(Guid id)
        {
            var entidade = this.ObterPorId(id);
            Dbset.Remove(entidade);
            SaveChanges();
        }

        public virtual int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public virtual void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

      
    }
}
