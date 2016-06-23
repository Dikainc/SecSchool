using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Data;
using EnterpriseSchool.Model.Translator;

namespace EnterpriseSchool.Business
{
    public abstract class BusinessBaseLogic<T, E> : IDisposable where E : class
    {
        protected BaseTranslator<T, E> translator;
        protected IRepository repository = new Repository();

        protected const string ArgumentNullException = "Null object argument. Please contact your system administrator";
        protected const string UpdateException = "Operation failed due to update exception!";
        protected const string NoItemModified = "No item modified!";
        protected const string NoItemFound = "No item found to modified!";
        protected const string NoItemRemoved = "No item removed!";
        protected const string ErrowDuringProccesing = "Error Occurred During Processing.";

        public virtual T GetModelBy(Expression<Func<E, bool>> selector = null)
        {
            try
            {

                E entity = repository.GetSingleBy(selector);
                return translator.Translate(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual List<T> GetModelsBy(Expression<Func<E, bool>> selector = null, Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null, string includeProperties = "")
        {
            try
            {
                List<E> entity = repository.GetBy(selector, orderBy, includeProperties).ToList();
                return translator.Translate(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual E GetEntityBy(Expression<Func<E, bool>> selector)
        {
            try
            {
                return repository.GetSingleBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual List<E> GetEntitiesBy(Expression<Func<E, bool>> selector = null, Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null, string includeProperties = "")
        {
            try
            {
                return repository.GetBy(selector, orderBy, includeProperties).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual List<T> GetAll()
        {
            try
            {
                List<E> entities = repository.GetAll<E>().ToList();
                return translator.Translate(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual T Add(T model)
        {
            try
            {
                E entity = translator.Translate(model);
                E addedEntity = repository.Add(entity);

                return translator.Translate(addedEntity);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(ArgumentNullException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual int Add(List<T> models)
        {
            try
            {
                List<E> entities = translator.Translate(models);
                return repository.Add<E>(entities);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(ArgumentNullException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual T Create(T model)
        {
            try
            {
                E entity = translator.Translate(model);
                E addedEntity = repository.Add(entity);

                repository.Save();

                return translator.Translate(addedEntity);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(ArgumentNullException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual int Create(List<T> models)
        {
            try
            {
                List<E> entities = translator.Translate(models);
                repository.Add<E>(entities);

                return repository.Save();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(ArgumentNullException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public virtual bool Modify(T model)
        //{
        //    try
        //    {
        //        E entity = ModifyHelper(model);
        //        if (entity == null)
        //        {
        //            throw new Exception(NoItemFound);
        //        }

        //        int modifiedRecordCount = Save();
        //        if (modifiedRecordCount <= 0)
        //        {
        //            throw new Exception(NoItemModified);
        //        }

        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //protected abstract E ModifyHelper(T model);

        public bool Delete(Expression<Func<E, bool>> selector)
        {
            try
            {
                repository.Delete(selector);
                return Save() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(object id)
        {
            try
            {
                repository.Delete(id);
                return Save() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Save()
        {
            return repository.Save();
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
                if (repository != null)
                {
                    repository.Dispose();
                    repository = null;
                }
            }
        }

        public bool Delete(List<E> entity)
        {
            try
            {
                repository.Delete(entity);
                return Save() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }

}
