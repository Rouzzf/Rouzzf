using Rouzzf.Client.User;

namespace Rouzzf.Client.Setup
{
    public abstract class ClientSetupBase
    {
        protected UserAccount UserAccount;

        protected ClientSetupBase()
        {
            UserAccount = new UserAccount();
        }
    }
}
