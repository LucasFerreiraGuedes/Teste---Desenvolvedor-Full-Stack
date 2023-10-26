using ExtratoContaCorrenteApi.Models;

namespace ExtratoContaCorrenteApi.Repository.LancamentoRepo
{
	public interface ILancamentoRepository : IRepository
	{
		public Task<IEnumerable<Lancamento>> GetAll();

		public Task<IQueryable<Lancamento>> GetByDate(DateTime date);
	}
}
