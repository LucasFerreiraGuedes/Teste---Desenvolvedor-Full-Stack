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

		[JsonConverter(typeof(JsonStringEnumConverter))]
		public Avulso avulso { get; set; }

		[JsonConverter(typeof(JsonStringEnumConverter))]
		public Status status { get; set; }

		public LancamentoDTO(string descricao, DateTime data,double valor, Avulso avulso, Status status)
		{
			this.descricao = descricao;
			this.data = data;
			this.valor = valor;
			this.avulso = avulso;

		}

		public LancamentoDTO()
		{

		}
	}
}
