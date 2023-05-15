using ExAula16.Enums;
using System.Text.Json.Serialization;

namespace ExAula16.Domain
{
    public class Parametros
    {
        [JsonPropertyName("num1")]
        public double Num1 { get; set; }

        [JsonPropertyName("num2")]
        public double Num2 { get; set; }

        [JsonPropertyName("operacao")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoOperacao Operacao { get; set; }
    }
}
