using System.Text.Json.Serialization;

namespace Restreamer.Api.Contracts
{
    public record JWTRefresh
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; } = null!;
    }
}
