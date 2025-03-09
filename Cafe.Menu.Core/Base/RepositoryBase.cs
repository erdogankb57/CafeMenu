using Cafe.Menu.Core.Abstract;
using Cafe.Menu.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Menu.Core.Base
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity, TContext> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        private readonly DbContext? _dbContext = null;
        public RepositoryBase(DbContext? dbContext = null)
        {
            if (_dbContext == null)
                _dbContext = dbContext;
        }
        public DataResult<TEntity> Delete(TEntity Entity)
        {
            DataResult<TEntity> result = new DataResult<TEntity>();
            try
            {
                if (_dbContext != null)
                {
                    var deletedEntity = _dbContext.Entry(Entity);
                    deletedEntity.State = EntityState.Deleted;
                    result.ResultType = MessageTypeResult.Success;
                    result.Data = Entity;
                }
            }
            catch (Exception ex)
            {
                result.Data = default(TEntity);
                result.ResultType = MessageTypeResult.Error;


            }

            return result;
        }

        public DataResult<TEntity> Get(Expression<Func<TEntity, bool>>? filter)
        {
            DataResult<TEntity> result = new DataResult<TEntity>();
            try
            {
                if (_dbContext != null)
                {
                    if (filter != null)
                    {
                        result.Data = _dbContext.Set<TEntity>().AsNoTracking().SingleOrDefault(filter);
                        //Bu özellik entity frameworkdaki asnotracking (yani izleme özelliğini) kapatır. Bunu eklemezsek önce get sonra update olduğunda hata alıyoruz.
                        //_dbContext.Entry<TEntity>(result.Data).State = EntityState.Detached;
                    }
                    result.ResultType = MessageTypeResult.Success;
                }
            }
            catch (Exception ex)
            {
                result.ResultType = MessageTypeResult.Error;
                result.Data = default(TEntity);
                result.ErrorMessage = ex.ToString();


            }
            return result;
        }
        public DataResult<IList<TEntity>> Find(Expression<Func<TEntity, bool>>? filter)
        {
            DataResult<IList<TEntity>> result = new DataResult<IList<TEntity>>();
            try
            {
                if (_dbContext != null)
                {
                    if (filter == null)
                        result.Data = _dbContext.Set<TEntity>().AsNoTracking().ToList();
                    else
                        result.Data = _dbContext.Set<TEntity>().AsNoTracking().Where(filter).ToList();

                    result.ResultType = MessageTypeResult.Success;
                }
            }
            catch (Exception ex)
            {
                result.Data = default(IList<TEntity>);
                result.ResultType = MessageTypeResult.Error;
                result.ErrorMessage = ex.ToString();


            }
            return result;
        }

        public DataResult<TEntity> Save(TEntity Entity)
        {
            DataResult<TEntity> result = new DataResult<TEntity>();
            try
            {

                if (_dbContext != null)
                {

                    var addedEntity = _dbContext.Entry(Entity);
                    addedEntity.State = EntityState.Added;
                    //context.SaveChanges();
                }

                result.Data = Entity;
                result.ResultType = MessageTypeResult.Success;
            }
            catch (Exception ex)
            {
                result.Data = default(TEntity);
                result.ResultType = MessageTypeResult.Error;
                result.ErrorMessage = ex.ToString();


            }

            return result;
        }

        public DataResult<TEntity> Update(TEntity Entity, string[]? updateFields = null)
        {
            DataResult<TEntity> result = new DataResult<TEntity>();
            try
            {
                if (_dbContext != null)
                {
                    var updatedEntity = _dbContext.Entry<TEntity>(Entity);
                    updatedEntity.State = EntityState.Modified;
                    if (updateFields != null && updateFields.Count() > 0)
                    {
                        foreach (var item in updatedEntity.Properties.Where(v => !updateFields.Any(a => a == v.Metadata.Name) && !v.Metadata.IsPrimaryKey()).ToList())
                            item.IsModified = false;
                    }


                }

                result.Data = Entity;
                result.ResultType = MessageTypeResult.Success;
            }
            catch (Exception ex)
            {
                result.Data = default(TEntity);
                result.ResultType = MessageTypeResult.Error;
                result.ErrorMessage = ex.ToString();

            }

            return result;
        }
    }
}
