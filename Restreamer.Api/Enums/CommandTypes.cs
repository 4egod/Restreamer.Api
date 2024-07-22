using System.Runtime.Serialization;

namespace Restreamer.Api
{
    public enum CommandTypes

    {
        [EnumMember(Value = "start")]
        Start,

        [EnumMember(Value = "stop")]
        Stop,

        [EnumMember(Value = "restart")]
        Restart,

        [EnumMember(Value = "reload")]
        Reload
    }
}
