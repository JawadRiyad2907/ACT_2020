using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ACT.Models;
using AutoMapper;

namespace ACT.Service
{
    public interface IGenericService<TModel>
    {
        TModel GetById(object id);

        TModel GetBy(Expression<Func<TModel, bool>> predicate,
           bool WithTracking = false,
           params Expression<Func<TModel, object>>[] includeProperties);
        List<TModel> GetAll();
        List<TModel> FindBy(Expression<Func<TModel, bool>> predicate);
        
        bool Any(Expression<Func<TModel, bool>> predicate);
        void Add(TModel entity);
        int Add(TModel entity, string returnName);
        void AddRange(IEnumerable<TModel> entities);
        void Delete(Expression<Func<TModel, bool>> predicate);
        void Delete(TModel entity);
        void DeleteRange(IEnumerable<TModel> entities);
        void Edit(TModel entity);
        IList<TModel> List(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null, params Expression<Func<TModel, object>>[] includeProperties);
        (IList<TModel> EntityData, int Count) ListWithPaging<TOrderBy>(Expression<Func<TModel, bool>> filter = null,
                   Expression<Func<TModel, TOrderBy>> orderBy = null,
               int? page = null, int? pageSize = null, params Expression<Func<TModel, object>>[] includeProperties);

    }
}