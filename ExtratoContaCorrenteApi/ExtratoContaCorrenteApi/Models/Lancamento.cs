using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ExtratoContaCorrenteApi.Models
{
	  public class Lancamento
	{
		[Key]
        public int Id { get; set; }
        public string descricao { get; set; }
        public DateTime data { get; set; }
        public double valor { get; set; }
        public Boolean avulso { get; set; }
        public enum status { Válido, Cancelado }

		public Lancamento(int id, string descricao, double valor, bool avulso)
		{
			Id = id;
			this.descricao = descricao;
			this.data = DateTime.Now;
			this.valor = valor;
			this.avulso = avulso;
		}

		public Lancamento()
		{

		}
	}
}
