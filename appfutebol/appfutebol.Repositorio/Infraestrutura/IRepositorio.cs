using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace appfutebol.Repositorio.Infraestrutura
{
    public interface IRepositorio<TEntidade>
    {
        IEnumerable<TEntidade> Buscar(Expression<Func<TEntidade, bool>> predicate);
        TEntidade Adicionar(TEntidade entidade);
        TEntidade Atualizar(TEntidade entidade);
        void Remover(Guid id);
        IEnumerable<TEntidade> ObterTodos();
        TEntidade ObterPorId(Guid id);
        int SaveChanges();
    }
}


