using Project.Areas.JobArea.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Areas.JobArea.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private SuperUniversityEntities1 db = new SuperUniversityEntities1();
        private DbSet<T> DbSet = null;

        public Repository()
        {
            DbSet = db.Set<T>();
        }
        public void Create(T _entity)
        {
            DbSet.Add(_entity);
            db.SaveChanges();
        }

        public void Delete(T _entity)
        {
            DbSet.Remove(_entity);
            db.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Update(T _entity)
        {
            db.Entry(_entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}