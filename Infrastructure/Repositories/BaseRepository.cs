using Domain.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public abstract class BaseRepository<T> where T: BaseEntity<int>
    {
        private ApplicationDbContext _db;
        private readonly DbSet<T> _entity;

        protected BaseRepository(ApplicationDbContext db)
        {
            _db = db;
         
        }

        public virtual int Create(T entity) 
        {
            _entity.Add(entity);
            _db.SaveChanges();
            return entity.Id;


        }

        public virtual T? GetById(int id)
        {
            return _entity
                .AsNoTracking()
                .SingleOrDefault(p => p.Id == id);
        }
    }
}
