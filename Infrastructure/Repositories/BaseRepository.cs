using Domain.Base;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public abstract class BaseRepository<T> where T : BaseEntity<int>
    {
        private ApplicationDbContext _db;
        private readonly DbSet<T> _entity;

        protected BaseRepository(ApplicationDbContext db)
        {
            _db = db;
            _entity = _db.Set<T>();
        }

        public virtual int Create(T entity)
        {
            _entity.Add(entity);
            _db.SaveChanges();
            return entity.Id;
        }

        public virtual T? GetById(int id, bool tracking = false)
        {
            var query = _entity.AsQueryable();
            if (tracking)
                query = query.AsNoTracking();
            return query

                .SingleOrDefault(p => p.Id == id);
        }



        public int Update(T entity)
        {

            _db.Update(entity);
            _db.SaveChanges();

            return entity.Id;
        }

        public void Delete(int id
            , bool tracking = false)
        {

            var query = _entity.AsQueryable();
            if (tracking)
                query = query.AsNoTracking();


            var En = query.SingleOrDefault(p => p.Id == id);

            _db.Remove(En);
            _db.SaveChanges();

        }

        public IReadOnlyCollection<T> GetPaged(int pageNo, int pageSize)
        {
            return _entity
        .AsNoTracking()
        .Skip((pageNo - 1) * pageSize)
        .Take(pageSize)
        .ToList();

        }


    }

}
