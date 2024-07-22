using System.Text.Json.Serialization;

namespace Restreamer.Api.Contracts
{
    public record ProcessConfigLimits
    {
        [JsonPropertyName("cpu_usage")]
        public double CpuUsage { get; set; }

        [JsonPropertyName("memory_mbytes")]
        public int MemoryMbytes { get; set; }

        [JsonPropertyName("waitfor_seconds")]
        public int WaitforSeconds { get; set; }
    }
}
