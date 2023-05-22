using Rouzzf.Common.Networking;
using System;
using System.Threading;

namespace Rouzzf.Common.Messages
{
    public abstract class MessageProcessorBase<T> : IMessageProcessor, IProgress<T>
    {
        protected readonly SynchronizationContext SynchronizationContext;

        private readonly SendOrPostCallback var1;

        public delegate void ReportProgressEventHandler(object sender, T value);

        public event ReportProgressEventHandler report;

        protected MessageProcessorBase(bool flag)
        {
            var1 = CallBack;
            SynchronizationContext = flag ? SynchronizationContext.Current : ProgressStatics.DefaultContext;
        }

        private void CallBack(object state)
        {
            report?.Invoke(this, (T)state);
        }

        public abstract bool CanExecute(IMessage message);

        public abstract bool CanExecuteFrom(ISender sender);

        public abstract void Execute(ISender sender, IMessage message);

        protected void OnReport(T value)
        {
            if (report != null)
            {
                SynchronizationContext.Post(var1, value);
            }
        }

        public void Report(T value)
        {
            OnReport(value);
        }
        
    }

    internal static class ProgressStatics
    {
        internal static readonly SynchronizationContext DefaultContext = new SynchronizationContext();
    }
}
