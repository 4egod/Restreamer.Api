using System.Text.Json.Serialization;

namespace Restreamer.Api.Contracts
{
    public record JWT : JWTRefresh
    {
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; } = null!;
    }
}
