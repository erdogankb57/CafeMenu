using Cafe.Menu.Business.DataContext;
using Cafe.Menu.Core.Abstract;
using Cafe.Menu.Core.Base;
using Cafe.Menu.Core.Model;
using Cafe.Menu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Menu.Business.Service
{
    public class ProductService
    {
        private IRepositoryBase<Product, DefaultDataContext> manager = null;
        private UnitOfWork<DefaultDataContext>? unitOfWork = null;
        public ProductService()
        {
            unitOfWork = new UnitOfWork<DefaultDataContext>();
            manager = unitOfWork.AddRepository<Product>();
        }

        public void Save(Product category)
        {
            if (category.ProductId == 0)
                manager.Save(category);
            else
                manager.Update(category);

            unitOfWork.SaveChanges();
        }

        public void Delete(Product category)
        {
            manager.Delete(category);

            unitOfWork.SaveChanges();
        }

        public DataResult<IList<Product>> Find(Expression<Func<Product, bool>>? filter)
        {
            return manager.Find(filter);
        }

        public DataResult<Product> Get(Expression<Func<Product, bool>>? filter)
        {
            return manager.Get(filter);
        }


    }
}
