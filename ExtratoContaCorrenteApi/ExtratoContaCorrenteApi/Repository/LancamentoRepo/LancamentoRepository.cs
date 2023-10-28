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
		public async Task<Lancamento> GetById(int id)
		{
			Lancamento lancamento = await _context.Lancamentos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

			return lancamento;
		}

		public async Task<IEnumerable<Lancamento>> GetAll()
		{
			return _context.Lancamentos.OrderBy(x => x.data);
		}

		public async Task<IQueryable<Lancamento>> GetByDate(DateTime date, int intervalo)
		{
			return _context.Lancamentos.AsNoTracking().Where(x => x.data.Day >= date.Day - intervalo && x.data.Day <= date.Day && (x.data.Month == date.Month && x.data.Year == date.Year)).OrderBy(x => x.data);
		}

		public async Task<Lancamento> Cancel(int id)
		{
			Lancamento lancamento = await GetById(id);

			if(lancamento != null)
			{
				lancamento.status = Status.Cancelado;
				_context.Update(lancamento);
				_context.SaveChanges();
				return lancamento;
			}
			return null;
		}

		public async Task<Lancamento> AttValorData(int id, double valor, DateTime data)
		{
			Lancamento lancamento = await GetById(id);

			if(lancamento != null)
			{
				lancamento.valor = valor;
				lancamento.data = data;

				_context.Update(lancamento);
				_context.SaveChanges();
				return lancamento;
			}
			return null;
		}
	}
}
