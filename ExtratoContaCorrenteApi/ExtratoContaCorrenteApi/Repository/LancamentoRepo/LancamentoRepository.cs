using ExtratoContaCorrenteApi.Context;
using ExtratoContaCorrenteApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExtratoContaCorrenteApi.Repository.LancamentoRepo
{
	public class LancamentoRepository : ILancamentoRepository
	{
		private readonly ContextDb _context;
        public LancamentoRepository(ContextDb context)
        {
            this._context = context;
        }
        public async Task<bool> Add<T>(T entity) where T : class
		{
			if (entity != null && entity is Lancamento)
			{
				Lancamento lancamento = entity as Lancamento;

				_context.Add(lancamento);
				_context.SaveChanges();

				return true;

			}
			return false;
		}

		public async Task<IEnumerable<Lancamento>> GetAll()
		{
			return  _context.Lancamentos;
		}

		public async Task<IQueryable<Lancamento>> GetByDate(DateTime date)
		{
			return  _context.Lancamentos.AsNoTracking().Where(x => x.data.Day == date.Day - 2 && (x.data.Month == date.Month && x.data.Year == date.Year));
		}
	}
}
