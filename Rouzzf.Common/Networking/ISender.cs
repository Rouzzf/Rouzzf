using Rouzzf.Common.Messages;

namespace Rouzzf.Common.Networking
{
    public interface ISender
    {
        void Send<T>(T message) where T : IMessage;
        void Disconnect();
    }
}
