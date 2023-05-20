using Rouzzf.Common.Networking;
using System;
using System.Threading;

namespace Rouzzf.Common.Messages
{
    public abstract class MessageProcessorBase<T> : IMessageProcessor, IProgress<T>
    {
        protected readonly SynchronizationContext SynchronizationContext;

        private readonly SendOrPostCallback callBack;

        public delegate void ReportProgressEventHandler(object sender, T value);

        public event ReportProgressEventHandler report;

        protected MessageProcessorBase(bool flag)
        {
            callBack = CallBack;
            if (flag)
            {
                SynchronizationContext = SynchronizationContext.Current;
            }
            else
            {
                SynchronizationContext = ProgressStatics.DefaultContext;
            }
        }

        private void CallBack(object state)
        {
            var handler = report;
            handler?.Invoke(this, (T)state);
        }

        public abstract bool CanExecute(IMessage message);

        public abstract bool CanExecuteFrom(ISender sender);

        public abstract void Execute(ISender sender, IMessage message);

        protected virtual void OnReport(T value)
        {
            var handler = report;
            if (handler != null)
            {
                SynchronizationContext.Post(callBack, value);
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
