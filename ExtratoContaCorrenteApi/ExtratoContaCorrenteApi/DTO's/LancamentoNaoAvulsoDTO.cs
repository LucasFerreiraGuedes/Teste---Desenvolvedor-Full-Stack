using ExtratoContaCorrenteApi.Models;
using System.Text.Json.Serialization;

namespace ExtratoContaCorrenteApi.DTO_s
{
	public class LancamentoNaoAvulsoDTO
	{
		public string descricao { get; set; }
		public DateTime data { get; set; }
		public double valor { get; set; }

		[JsonConverter(typeof(JsonStringEnumConverter))]
		private Avulso avulso { get; set; }

		[JsonConverter(typeof(JsonStringEnumConverter))]
		private Status status { get; set; }

		public LancamentoNaoAvulsoDTO(string descricao, DateTime data, double valor)
		{
			this.descricao = descricao;
			this.data = data;
			this.valor = valor;
			this.status = Status.Cancelado;
			this.avulso = Avulso.NãoAvulso;

		}

		public LancamentoNaoAvulsoDTO()
		{

		}
	}
}
