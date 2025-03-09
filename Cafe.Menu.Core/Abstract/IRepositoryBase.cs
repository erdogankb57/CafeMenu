using Cafe.Menu.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Menu.Core.Abstract
{
    public interface IRepositoryBase<TEntity, TContext> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        DataResult<TEntity> Get(Expression<Func<TEntity, bool>>? filter);
        DataResult<TEntity> Update(TEntity Entity, string[]? updateFields = null);
        DataResult<TEntity> Save(TEntity Entity);
        DataResult<TEntity> Delete(TEntity Entity);
        DataResult<IList<TEntity>> Find(Expression<Func<TEntity, bool>>? filter);
    }
}
