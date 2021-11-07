using System.Threading.Tasks;
using projectAnhedonia_back.Presentation.Entities.Dto;

namespace projectAnhedonia_back.Presentation.Common
{
    public static class TaskExt
    {
        public static Task<Result> ConvertToResult(this Task task, string message)
        {
            return task.ContinueWith(_ => new Result("ok", message));
        }

        public static Task<Result<T>> ConvertToResult<T>(this Task<T> task, string message)
        {
            return task.ContinueWith(res => new Result<T>("ok", message, res.Result));
        }
    }
}