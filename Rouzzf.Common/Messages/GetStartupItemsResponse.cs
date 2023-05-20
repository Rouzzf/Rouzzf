using ProtoBuf;
using Rouzzf.Common.Models;
using System.Collections.Generic;

namespace Rouzzf.Common.Messages
{
    [ProtoContract]
    public class GetStartupItemsResponse : IMessage
    {
        [ProtoMember(1)]
        public List<StartupItem> StartupItems { get; set; }
    }
}
