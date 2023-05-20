using ProtoBuf;
using Rouzzf.Common.Enums;

namespace Rouzzf.Common.Messages
{
    [ProtoContract]
    public class DoShutdownAction : IMessage
    {
        [ProtoMember(1)]
        public ShutdownAction Action { get; set; }
    }
}
