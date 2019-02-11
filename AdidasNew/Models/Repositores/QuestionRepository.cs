using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdidasNew.Models.Repositores
{
    public class QuestionRepository : IDisposable
    {
        private AdidasNew.Models.DomainModels.DatabaseContext db = null;

        public QuestionRepository()
        {
            db = new DomainModels.DatabaseContext();
        }

        public bool Add(AdidasNew.Models.DomainModels.Question entity, bool autoSave = true)
        {
            try
            {
                db.Questions.Add(entity);

                if (autoSave)
                {
                    int x = db.SaveChanges();
                    //AdidasNew.Controllers.HomeController.personId = entity.Id;

                    return Convert.ToBoolean(x);
                }

                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(AdidasNew.Models.DomainModels.Question entity, bool autoSave = true)
        {
            try
            {
                db.Questions.Attach(entity);
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

        public bool Delete(AdidasNew.Models.DomainModels.Question entity, bool autoSave = true)
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
                var entity = db.Questions.Find(id);
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

        public AdidasNew.Models.DomainModels.Question Find(int id)
        {
            try
            {
                return db.Questions.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<AdidasNew.Models.DomainModels.Question> Where(System.Linq.Expressions.Expression<Func<AdidasNew.Models.DomainModels.Question, bool>> predicate)
        {
            try
            {
                return db.Questions.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<AdidasNew.Models.DomainModels.Question> Select()
        {
            try
            {
                return db.Questions.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<AdidasNew.Models.DomainModels.Question, TResult>> selector)
        {
            try
            {
                return db.Questions.Select(selector);
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
                if (db.Questions.Any())
                    return db.Questions.OrderByDescending(p => p.Id).First().Id;
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

        ~QuestionRepository()
        {
            Dispose(false);
        }
    }
}