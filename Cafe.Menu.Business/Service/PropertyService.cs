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
    public class PropertyService
    {
        private IRepositoryBase<Property, DefaultDataContext> manager = null;
        private UnitOfWork<DefaultDataContext>? unitOfWork = null;
        public PropertyService()
        {
            unitOfWork = new UnitOfWork<DefaultDataContext>();
            manager = unitOfWork.AddRepository<Property>();
        }

        public void Save(Property category)
        {
            if (category.PropertyId == 0)
                manager.Save(category);
            else
                manager.Update(category);

            unitOfWork.SaveChanges();
        }

        public void Delete(Property category)
        {
            manager.Delete(category);

            unitOfWork.SaveChanges();
        }

        public DataResult<IList<Property>> Find(Expression<Func<Property, bool>>? filter = null)
        {
            return manager.Find(filter);
        }

        public DataResult<Property> Get(Expression<Func<Property, bool>>? filter)
        {
            return manager.Get(filter);
        }


    }
}
