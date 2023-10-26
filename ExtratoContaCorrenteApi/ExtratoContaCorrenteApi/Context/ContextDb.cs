using ExtratoContaCorrenteApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExtratoContaCorrenteApi.Context
{
	public class ContextDb : DbContext
	{
		public DbSet<Lancamento> Lancamentos { get; set; }

		public ContextDb(DbContextOptions<ContextDb> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Lancamento>()
				.Property(e => e.status)
				.HasConversion(
					v => v.ToString(),
					v => (Status)Enum.Parse(typeof(Status), v)
				);
		}

	}
	
}
