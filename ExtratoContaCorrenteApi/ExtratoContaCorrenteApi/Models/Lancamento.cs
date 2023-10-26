using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

		[JsonConverter(typeof(JsonStringEnumConverter))]
		public Status status { get; set; }

		public Lancamento(int id, string descricao, double valor, bool avulso, Status status)
		{
			Id = id;
			this.descricao = descricao;
			this.data = DateTime.Now;
			this.valor = valor;
			this.avulso = avulso;
			this.status = status;
			
		}

		public Lancamento()
		{

		}
	}
}
