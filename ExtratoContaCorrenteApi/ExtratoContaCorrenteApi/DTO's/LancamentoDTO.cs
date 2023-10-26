using ExtratoContaCorrenteApi.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json.Serialization;

namespace ExtratoContaCorrenteApi.DTO_s
{
	public class LancamentoDTO
	{
		public string descricao { get; set; }
		public DateTime data { get; set; }
		public double valor { get; set; }
		public Boolean avulso { get; set; }

		[JsonConverter(typeof(JsonStringEnumConverter))]
		public Status status { get; set; }

		public LancamentoDTO(string descricao, double valor, bool avulso, Status status)
		{
			this.descricao = descricao;
			this.data = DateTime.Now;
			this.valor = valor;
			this.avulso = avulso;

		}

		public LancamentoDTO()
		{

		}
	}
}
