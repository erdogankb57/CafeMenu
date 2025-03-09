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
    public class ProductPropertyService
    {
        private IRepositoryBase<ProductProperty, DefaultDataContext> manager = null;
        private UnitOfWork<DefaultDataContext>? unitOfWork = null;
        public ProductPropertyService()
        {
            unitOfWork = new UnitOfWork<DefaultDataContext>();
            manager = unitOfWork.AddRepository<ProductProperty>();
        }

        public void Save(ProductProperty category)
        {
            if (category.ProductPropertyId == 0)
                manager.Save(category);
            else
                manager.Update(category);

            unitOfWork.SaveChanges();
        }

        public void Delete(ProductProperty category)
        {
            manager.Delete(category);

            unitOfWork.SaveChanges();
        }

        public DataResult<IList<ProductProperty>> Find(Expression<Func<ProductProperty, bool>>? filter = null)
        {
            return manager.Find(filter);
        }

        public DataResult<ProductProperty> Get(Expression<Func<ProductProperty, bool>>? filter)
        {
            return manager.Get(filter);
        }


    }
}
