using System;
using System.Linq;
using CodeCampServer.Core.Bases;
using CodeCampServer.Core.Domain;
using NHibernate;

namespace CodeCampServer.Infrastructure.NHibernate.DataAccess.Impl
{
	public class RepositoryBase<T> :  IRepository<T> where T : PersistentObject
	{
		public RepositoryBase(IUnitOfWork unitOfWork )
		{
		}

		public virtual T GetById(Guid id)
		{
			ISession session = GetSession();
			return session.Get<T>(id);
		}

		protected ISession GetSession()
		{
			return new SessionBuilder().GetSession();
		}

		public virtual void Save(T entity)
		{
			GetSession().SaveOrUpdate(entity);
		}

		public virtual T[] GetAll()
		{
			ISession session = GetSession();
			ICriteria criteria = session.CreateCriteria(typeof (T));
			return criteria.List<T>().ToArray();
		}

		public virtual void Delete(T entity)
		{
			GetSession().Delete(entity);
		}
	}
}