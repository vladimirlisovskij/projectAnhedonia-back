using System.Threading.Tasks;

namespace projectAnhedonia_back.Presentation.Tools
{
    public static class TaskExtension
    {
        public static Task<Result<string>> ConvertToResult(this Task task, string message)
        {
            return task.ContinueWith( _ => new Result<string>("ok", message, ""));
        }

        public static Task<Result<T>> ConvertToResult<T>(this Task<T> task, string message)
        {
            return task.ContinueWith( res => new Result<T>("ok", message, res.Result));
        }
    }
}