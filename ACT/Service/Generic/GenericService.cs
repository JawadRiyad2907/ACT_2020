using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ACT.Models;
using AutoMapper;

namespace ACT.Service
{
    public class GenericService<TModel> : IGenericService<TModel>
       where TModel : class
    {
        protected readonly ActEntities context;
        private readonly DbSet<TModel> dbSet;
        public GenericService(ActEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TModel>();
        }

        public virtual TModel GetById(object id)
        {
            var ent = context.Set<TModel>();
            var item = ent.Find(id);
            if (item == null)
                return null;
            context.Entry(item).State = EntityState.Detached;
            var dto = Mapper.Map<TModel, TModel>(item);
            return item;
        }

        public TModel GetBy(Expression<Func<TModel, bool>> predicate,
           bool WithTracking = false,
           params Expression<Func<TModel, object>>[] includeProperties)
        {
            IQueryable<TModel> query = dbSet;

            if (!WithTracking)
                query = query.AsNoTracking();
            else
                query = query.AsQueryable();

            query = query.Where(predicate);

            if (includeProperties != null && includeProperties.Count() > 0)
                query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.FirstOrDefault();
        }

        public virtual List<TModel> GetAll()
        {
            var ent = context.Set<TModel>();
            var query = ent.ToList();

            var list = query.ToList();
            return list;
        }



        public List<TModel> FindBy(Expression<Func<TModel, bool>> predicate)
        {
            var expression = Mapper.Map<Expression<Func<TModel, bool>>>(predicate);
            var ent = context.Set<TModel>();
            var query = ent.Where(expression).ToList();

            var list = query.ToList();
            return list;
        }


        public bool Any(Expression<Func<TModel, bool>> predicate)
        {
            var expression = Mapper.Map<Expression<Func<TModel, bool>>>(predicate);
            var result = context.Set<TModel>().Any(expression);
            return result;
        }

        public virtual void Add(TModel entity)
        {
            var item = Mapper.Map<TModel, TModel>(entity);
            context.Set<TModel>().Add(item);
            context.SaveChanges();
        }

        public virtual int Add(TModel entity, string returnName)
        {
            var item = Mapper.Map<TModel, TModel>(entity);

            try
            {
                context.Set<TModel>().Add(item);
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
            return (int)item.GetType().GetProperty(returnName).GetValue(item, null);

        }

        public virtual void AddRange(IEnumerable<TModel> entities)
        {
            var list = Mapper.Map<IEnumerable<TModel>, IEnumerable<TModel>>(entities);

            context.Set<TModel>().AddRange(list);
            context.SaveChanges();
        }

        public virtual TModel AddGetId(TModel entity)
        {
            var item = Mapper.Map<TModel, TModel>(entity);

            context.Set<TModel>().Add(item);
            context.SaveChanges();
            return Mapper.Map<TModel>(item);
        }

        public virtual void Delete(Expression<Func<TModel, bool>> predicate)
        {
            var expression = Mapper.Map<Expression<Func<TModel, bool>>>(predicate);
            context.Set<TModel>().RemoveRange(context.Set<TModel>().Where(expression));
            context.SaveChanges();
        }

        public virtual void Delete(TModel entity)
        {

            var item = Mapper.Map<TModel, TModel>(entity);
            bool isDetached = context.Entry(item).State == EntityState.Detached;
            if (isDetached)
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                context.Set<TModel>().Attach(item);
            }
            context.Set<TModel>().Remove(item);
            context.SaveChanges();

        }

        public virtual void DeleteRange(IEnumerable<TModel> entities)
        {
            var list = Mapper.Map<IEnumerable<TModel>, IEnumerable<TModel>>(entities);
            foreach (var item in list)
            {
                bool isDetached = context.Entry(item).State == EntityState.Detached;
                if (isDetached)
                {
                    context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    context.Set<TModel>().Attach(item);
                }
            }
            context.Set<TModel>().RemoveRange(list);
            context.SaveChanges();
        }

        public virtual void Edit(TModel entity)
        {
            var item = Mapper.Map<TModel, TModel>(entity);
            context.Set<TModel>().Attach(item);
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
            context.Entry(item).State = EntityState.Detached;
        }


        public virtual List<TModel> GetAll<TKey>(int blockSize, int blockNumber, Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, TKey>> orderBy)
        {
            var expression = Mapper.Map<Expression<Func<TModel, bool>>, Expression<Func<TModel, bool>>>(predicate);
            var orderByExpression = Mapper.Map<Expression<Func<TModel, TKey>>>(orderBy);
            int startIndex = (blockNumber - 1) * blockSize;
            var list = context.Set<TModel>().Where(expression)
                .OrderBy(orderByExpression).Skip(startIndex).Take(blockSize).ToList();
            return list.ToList();
        }


        public IList<TModel> List(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null, params Expression<Func<TModel, object>>[] includeProperties)
        {
            IQueryable<TModel> query = context.Set<TModel>();

            if (includeProperties != null && includeProperties.Count() != 0)
            {
                var includePropertiesExpression = Mapper.Map<List<Expression<Func<TModel, object>>>>(includeProperties);
                includePropertiesExpression.ForEach(i => { query = query.Include(i); });
            }

            if (filter != null)
            {
                var filterExpression = Mapper.Map<Expression<Func<TModel, bool>>>(filter);
                query = query.Where(filterExpression);
            }

            if (orderBy != null)
            {
                query = orderBy.Invoke(query);
            }
            var list = query.ToList();
            return Mapper.Map<IList<TModel>>(list);
        }

        public (IList<TModel> EntityData, int Count) ListWithPaging<TOrderBy>(Expression<Func<TModel, bool>> filter = null,
            Expression<Func<TModel, TOrderBy>> orderBy = null,
        int? page = null, int? pageSize = null, params Expression<Func<TModel, object>>[] includeProperties)
        {

            IQueryable<TModel> query = context.Set<TModel>();

            if (includeProperties != null && includeProperties.Count() != 0)
            {
                var includePropertiesExpression = Mapper.Map<List<Expression<Func<TModel, object>>>>(includeProperties);
                includePropertiesExpression.ForEach(i => { query = query.Include(i); });
            }

            if (filter != null)
            {
                var filterExpression = Mapper.Map<Expression<Func<TModel, bool>>>(filter);
                query = query.Where(filterExpression);
            }

            if (orderBy != null)
            {
                var orderExpression = Mapper.Map<Expression<Func<TModel, TOrderBy>>>(orderBy);
                query = query.OrderBy(orderExpression);
            }
            var count = query.Count();
            if (page != null && pageSize != null)
                query = query
                    .Skip(page.Value)
                    .Take(pageSize.Value);
            var data = query.ToList();
            var result = Mapper.Map<(IList<TModel>, int)>((data, count));
            return result;
        }


    }
}
