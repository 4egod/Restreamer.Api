using Refit;
using Restreamer.Api.Contracts;

namespace Restreamer.Api
{
    public interface IRestreamerApiClient
    {
        [Get("/ping")]
        public Task<string> PingAsync();

        public async Task<JWT> LoginAsync(string username, string password) => await InternalLoginAsync(new { username, password });

        public async Task<string> RefreshTokenAsync(string refershToken) => (await InternalRefreshTokenAsync(refershToken)).AccessToken;

        [Get("/api/v3/process?filter={filter}&reference={reference}&id={id}&idpattern={idPattern}&refpattern={refPattern}")]
        public Task<List<Process>> GetProcesses([Authorize("Bearer")] string token, string? filter = null, string? reference = null, string? id = null, string? idPattern = null, string? refPattern = null);

        [Post("/api/v3/process")]
        public Task<ProcessConfig> StartProcess([Authorize("Bearer")] string token, ProcessConfig processConfig);

        public async Task<bool> DeleteProcessAsync(string token, string processId) => (await InternalDeleteProcessAsync(token, processId)).Contains("OK");

        public async Task<bool> SendCommandAsync(string token, string processId, CommandTypes command) => (await InternalSendCommandAsync(token, processId, new { command })).Contains("OK");

        [Post("/api/login")]
        protected Task<JWT> InternalLoginAsync(object request);

        [Get("/api/login/refresh")]
        protected Task<JWTRefresh> InternalRefreshTokenAsync([Authorize("Bearer")] string refershToken);

        [Delete("/api/v3/process/{processId}")]
        public Task<string> InternalDeleteProcessAsync([Authorize("Bearer")] string token, string processId);

        [Put("/api/v3/process/{processId}/command")]
        protected Task<string> InternalSendCommandAsync([Authorize("Bearer")] string token, string processId, object command);
    }
}
