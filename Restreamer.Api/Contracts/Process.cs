namespace Restreamer.Api.Contracts
{
    public record Process
    {
        public string Id { get; set; } = string.Empty;

        public string Reference { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;
    }
}
