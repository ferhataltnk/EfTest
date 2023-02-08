using Core.DataAccess.Abstract;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public class EfGenericDal<TEntity, TContext> : IGenericDal<TEntity> where TContext : DbContext,new() where TEntity:class,new()
    {
      
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedToEntity = context.Entry(entity);
                addedToEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Delete(int id)
        {
            using (TContext context = new TContext())
            {
                var temp = context.Find<TEntity>(id);
                var deletedToEntity = context.Entry(temp);
                deletedToEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedToEntity = context.Entry(entity);
                updatedToEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }



    }
}
