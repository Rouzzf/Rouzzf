using ProtoBuf;
using Rouzzf.Common.Models;

namespace Rouzzf.Common.Messages
{
    [ProtoContract]
    public class GetCreateRegistryKeyResponse : IMessage
    {
        [ProtoMember(1)]
        public string ParentPath { get; set; }

        [ProtoMember(2)]
        public RegSeekerMatch Match { get; set; }

        [ProtoMember(3)]
        public bool IsError { get; set; }

        [ProtoMember(4)]
        public string ErrorMsg { get; set; }
    }
}
