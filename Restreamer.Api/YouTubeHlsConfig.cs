using Restreamer.Api.Contracts;

namespace Restreamer.Api
{
    public record YouTubeHlsConfig : ProcessConfig
    {
        public YouTubeHlsConfig(string reference, string youTubeStreamId, bool backupStream = false)
        {
            var guid = Guid.NewGuid().ToString();

            Type = "ffmpeg";
            Id = $"restreamer-ui:egress:youtube:{guid}";
            Reference = reference;
            Inputs = [new()
            {
                Id = "input_0",
                Address = $"{{memfs}}/{reference}.m3u8",
                Options = ["-re"]
            }];
            Outputs = [new ()
            {
                Id = "output_0",
                Address = $"https://{(backupStream?"b":"a")}.upload.youtube.com/http_upload_hls?cid={youTubeStreamId}&copy=0&file={guid}.m3u8",
                Options =
                [
                    "-map",
                    "0:0",
                    "-codec:v",
                    "copy",
                    "-map",
                    "0:1",
                    "-codec:a",
                    "copy",
                    "-f",
                    "hls",
                    "-start_number",
                    "0",
                    "-hls_time",
                    "2",
                    "-hls_delete_threshold",
                    "3",
                    "-hls_list_size",
                    "5",
                    "-hls_flags",
                    "append_list",
                    "-hls_segment_type",
                    "mpegts",
                    "-http_persistent",
                    "1",
                    "-y",
                    "-method",
                    "PUT",
                    "-hls_segment_filename",
                    $"https://{(backupStream?"b":"a")}.upload.youtube.com/http_upload_hls?cid={youTubeStreamId}&copy=0&file={guid}_%d.ts"
                ]
            }];
            Options = ["-loglevel", "level+info", "-err_detect", "ignore_err"];
            Autostart = true;
            Reconnect = true;
            ReconnectDelaySeconds = 15;
            StaleTimeoutSeconds = 30;
            Limits = new() { WaitforSeconds = 5 };
        }
    }
}
