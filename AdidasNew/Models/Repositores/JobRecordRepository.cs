using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdidasNew.Models.Repositores
{

    public class JobRecordRepository : IDisposable
    {
        private AdidasNew.Models.DomainModels.DatabaseContext db = null;

        public JobRecordRepository()
        {
            db = new DomainModels.DatabaseContext();
        }

        public bool Add(AdidasNew.Models.DomainModels.JobRecord entity, bool autoSave = true)
        {
            try
            {
                db.JobRecords.Add(entity);
                //AdidasNew.Controllers.HomeController.personId = entity.Id;
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(AdidasNew.Models.DomainModels.JobRecord entity, bool autoSave = true)
        {
            try
            {
                db.JobRecords.Attach(entity);
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(AdidasNew.Models.DomainModels.JobRecord entity, bool autoSave = true)
        {
            try
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id, bool autoSave = true)
        {
            try
            {
                var entity = db.People.Find(id);
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public AdidasNew.Models.DomainModels.JobRecord Find(int id)
        {
            try
            {
                return db.JobRecords.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<AdidasNew.Models.DomainModels.JobRecord> Where(System.Linq.Expressions.Expression<Func<AdidasNew.Models.DomainModels.JobRecord, bool>> predicate)
        {
            try
            {
                return db.JobRecords.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<AdidasNew.Models.DomainModels.JobRecord> Select()
        {
            try
            {
                return db.JobRecords.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<AdidasNew.Models.DomainModels.JobRecord, TResult>> selector)
        {
            try
            {
                return db.JobRecords.Select(selector);
            }
            catch
            {
                return null;
            }
        }

        public int GetLastIdentity()
        {
            try
            {
                if (db.People.Any())
                    return db.People.OrderByDescending(p => p.Id).First().Id;
                else
                    return 0;
            }
            catch
            {
                return -1;
            }
        }

        public int Save()
        {
            try
            {
                return db.SaveChanges();
            }
            catch
            {
                return -1;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }

        ~JobRecordRepository()
        {
            Dispose(false);
        }
    }
}