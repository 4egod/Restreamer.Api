namespace Restreamer.Api.Contracts
{
    public record ProcessConfigIO
    {
        public string Id { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public List<string> Options { get; set; } = [];
    }
}
