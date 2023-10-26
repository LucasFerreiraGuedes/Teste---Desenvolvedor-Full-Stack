namespace ExtratoContaCorrenteApi.Repository
{
	public interface IRepository
	{
		public Task<Boolean> Add<T>(T entity) where T : class;
	}
}
