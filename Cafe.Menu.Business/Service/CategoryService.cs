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
    public class CategoryService
    {
        private IRepositoryBase<Category, DefaultDataContext> manager = null;
        private UnitOfWork<DefaultDataContext>? unitOfWork = null;
        public CategoryService()
        {
            unitOfWork = new UnitOfWork<DefaultDataContext>();
            manager = unitOfWork.AddRepository<Category>();
        }

        public void Save(Category category)
        {
            if (category.CategoryId == 0)
                manager.Save(category);
            else
                manager.Update(category);

            unitOfWork.SaveChanges();
        }

        public void Delete(Category category)
        {
            manager.Delete(category);

            unitOfWork.SaveChanges();
        }

        public DataResult<IList<Category>> Find(Expression<Func<Category, bool>>? filter = null)
        {
            return manager.Find(filter);
        }

        public DataResult<Category> Get(Expression<Func<Category, bool>>? filter)
        {
            return manager.Get(filter);
        }


    }
}
