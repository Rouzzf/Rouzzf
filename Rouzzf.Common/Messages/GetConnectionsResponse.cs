using ProtoBuf;
using Rouzzf.Common.Models;

namespace Rouzzf.Common.Messages
{
    [ProtoContract]
    public class GetConnectionsResponse : IMessage
    {
        [ProtoMember(1)]
        public TcpConnection[] Connections { get; set; }
    }
}
