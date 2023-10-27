using ExtratoContaCorrenteApi.Models;
using System.Text.Json.Serialization;

namespace ExtratoContaCorrenteApi.DTO_s
{
	public class LancamentoNaoAvulsoDTO
	{
		public string descricao { get; set; }
		public DateTime data { get; set; }
		public double valor { get; set; }
		private Boolean avulso { get; set; } = false;

		[JsonConverter(typeof(JsonStringEnumConverter))]
		private Status status { get; set; }

		public LancamentoNaoAvulsoDTO(string descricao, DateTime data, double valor)
		{
			this.descricao = descricao;
			this.data = data;
			this.valor = valor;
			this.status = Status.Válido;

		}

		public LancamentoNaoAvulsoDTO()
		{

		}
	}
}
