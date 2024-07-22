using System.Text.Json.Serialization;

namespace Restreamer.Api.Contracts
{
    public record ProcessConfig
    {
        public string Type { get; set; } = string.Empty;

        public string Id { get; set; } = string.Empty;

        public string Reference { get; set; } = string.Empty;

        [JsonPropertyName("input")]
        public List<ProcessConfigIO> Inputs { get; set; } = [];

        [JsonPropertyName("output")]
        public List<ProcessConfigIO> Outputs { get; set; } = [];

        public List<string> Options { get; set; } = [];

        public bool Autostart { get; set; }

        public bool Reconnect { get; set; }

        [JsonPropertyName("reconnect_delay_seconds")]
        public int ReconnectDelaySeconds { get; set; }

        [JsonPropertyName("stale_timeout_seconds")]
        public int StaleTimeoutSeconds { get; set; }

        public ProcessConfigLimits Limits { get; set; } = null!;
    }
}
