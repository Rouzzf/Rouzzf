using ProtoBuf;

namespace Rouzzf.Common.Messages
{
    [ProtoContract]
    public class KeyboardResponse : IMessage
    {
        [ProtoMember(1)]
        public string LogsDirectory { get; set; }
    }
}
