using ExtratoContaCorrenteApi.Models;

namespace ExtratoContaCorrenteApi.Repository.LancamentoRepo
{
	public interface ILancamentoRepository : IRepository
	{
		public Task<IEnumerable<Lancamento>> GetAll();

		public Task<IQueryable<Lancamento>> GetByDate(DateTime date,int intervalo);

		public Task<Lancamento> GetById(int id);

		public Task<Lancamento> Cancel(int id);

		public Task<Lancamento> AttValorData(int id,double valor,DateTime data);
	}
}
