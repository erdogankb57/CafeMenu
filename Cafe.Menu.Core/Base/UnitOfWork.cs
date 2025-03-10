﻿using Cafe.Menu.Core.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Menu.Core.Base
{
    public class UnitOfWork<TContext> : IDisposable where TContext : DbContext, new()
    {
        private readonly TContext? DataContext;
        public UnitOfWork()
        {
            if (DataContext == null)
            {
                DataContext = new TContext();
                //DataContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            }
        }

        public TContext? GetDataContext => DataContext;
        public RepositoryBase<TEntity, TContext> AddRepository<TEntity>() where TEntity : class, IEntity, new()
        {
            return new RepositoryBase<TEntity, TContext>(DataContext);
        }

        public void SaveChanges()
        {
            using (var transaction = DataContext?.Database.BeginTransaction())
            {
                try
                {
                    DataContext?.SaveChanges();
                    transaction?.Commit();

                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    throw ex;
                }
            }
        }

        private bool Disposed = false;
        protected virtual void Dispose(bool Disposing)
        {
            if (!this.Disposed)
            {
                if (Disposing)
                {
                    DataContext?.Dispose();
                }
            }

            this.Disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
