using ProtoBuf;
using Rouzzf.Common.Models;

namespace Rouzzf.Common.Messages
{
    [ProtoContract]
    public class DoStartupItemRemove : IMessage
    {
        [ProtoMember(1)]
        public StartupItem StartupItem { get; set; }
    }
}
