using ProtoBuf;
using Rouzzf.Common.Models;

namespace Rouzzf.Common.Messages
{
    [ProtoContract]
    public class GetDirectoryResponse : IMessage
    {
        [ProtoMember(1)]
        public string RemotePath { get; set; }

        [ProtoMember(2)]
        public FileSystemEntry[] Items { get; set; }
    }
}
