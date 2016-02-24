namespace GalaxyStorm.Services.Web
{
    using System;
    using System.Linq.Expressions;
    using Contracts;
    using Hangfire;

    public class BackgroundWorkerService<T> : IBackgroundWorkerService<T>
    {
        public void Schedule(Expression<Action<T>> action, TimeSpan delay)
        {
            BackgroundJob.Schedule<T>(action, delay);
        }
    }
}
