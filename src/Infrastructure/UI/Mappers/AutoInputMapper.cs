using AutoMapper;
using CodeCampServer.Core.Bases;
using CodeCampServer.Core.Domain;

namespace CodeCampServer.Infrastructure.UI.Mappers
{
	public abstract class AutoInputMapper<TModel, TForm> : Mapper<TModel, TForm> where TModel : PersistentObject, new()
	{
		protected AutoInputMapper(IRepository<TModel> repository) : base(repository) {}

		public override K Map<T, K>(T model)
		{
			return Mapper.Map<T, K>(model);
		}
	}
}