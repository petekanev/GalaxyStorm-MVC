namespace GalaxyStorm.Services.Web.Contracts
{
    using System;
    using System.Linq.Expressions;

    public interface IBackgroundWorkerService<T>
    {
        void Schedule(Expression<Action<T>> action, TimeSpan delay);
    }
}
