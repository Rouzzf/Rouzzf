using Rouzzf.Common.Messages;

namespace Rouzzf.Client.Messages
{
    public abstract class NotificationMessageProcessor : MessageProcessorBase<string>
    {
        protected NotificationMessageProcessor() : base(true)
        {
        }
    }
}
