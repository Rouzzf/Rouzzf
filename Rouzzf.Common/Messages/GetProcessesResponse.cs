using ProtoBuf;
using Rouzzf.Common.Models;

namespace Rouzzf.Common.Messages
{
    [ProtoContract]
    public class GetProcessesResponse : IMessage
    {
        [ProtoMember(1)]
        public Process[] Processes { get; set; }
    }
}
