using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace projectAnhedonia_back.Common
{
    public static class TaskExt
    {
        public static Task<TOut> MapResult<T, TOut>(this Task<T> task, Func<T, TOut> func)
        {
            return task.ContinueWith(t =>
                func(t.Result)
            );
        }

        public static Task<T> MapError<T>(this Task<T> task,
            Func<ReadOnlyCollection<Exception>, Exception> handler)
        {
            var exceptions = task.Exception?.InnerExceptions;
            if (exceptions != null)
            {
                throw handler(exceptions);
            }

            return task;
        }
    }
}