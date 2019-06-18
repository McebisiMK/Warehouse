using System;

namespace Warehouse.Entities
{
    public class QueryResult<TResult>
    {
        private QueryResult()
        {
            
        }
        public ResultType ResultType { get; private set; }
        public TResult Result { get; private set; }
        public string Message { get; private set; }
        public Exception Exception { get; private set; }

        public static QueryResult<TResult> CreateSuccessResult(TResult result, string message = null)
        {
            return new QueryResult<TResult>
            {
                ResultType = ResultType.Success,
                Result = result,
                Message = message
            };
        }

        public static QueryResult<TResult> CreateInformationResult(TResult result, string message)
        {
            return new QueryResult<TResult>
            {
                ResultType = ResultType.Information,
                Result = result,
                Message = message
            };
        }

        public static QueryResult<TResult> CreateWarningResult(TResult result, string message)
        {
            return new QueryResult<TResult>
            {
                ResultType = ResultType.Warning,
                Result = result,
                Message = message
            };
        }

        public static QueryResult<TResult> CreateErrorResult(string message)
        {
            return new QueryResult<TResult> { ResultType = ResultType.Error, Message = message };
        }

        public static QueryResult<TResult> CreateErrorResult(Exception ex)
        {
            return new QueryResult<TResult>
            {
                ResultType = ResultType.Error,
                Message = string.Format("{0}{1}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace),
                Exception = ex
            };
        }
    }
}
