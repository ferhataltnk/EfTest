using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IGenericDal<TEntity> where TEntity : class,new()
    {
      
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        public void Add(TEntity entity);
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        public void Delete(int id);
        void Update(TEntity entity);
    }
}
