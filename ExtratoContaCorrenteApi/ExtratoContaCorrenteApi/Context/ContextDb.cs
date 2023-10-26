using ExtratoContaCorrenteApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExtratoContaCorrenteApi.Context
{
	public class ContextDb : DbContext
	{
		public DbSet<Lancamento> Lancamentos { get; set; }

        public ContextDb(DbContextOptions<ContextDb> options) : base (options)
        {
            
        }
    }
}
