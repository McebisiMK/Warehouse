using System;

namespace Warehouse.Entities
{
    public class CommandResult
    {
        private CommandResult()
        {
        }

        public ResultType Type { get; private set; }
        public string Message { get; private set; }
        public Exception Exception { get; private set; }

        public static CommandResult CreateSuccessResult(string message)
        {
            return new CommandResult
            {
                Type = ResultType.Success,
                Message=message
            };
        }

        public static CommandResult CreateWarningResult(string message)
        {
            return new CommandResult
            {
                Type = ResultType.Warning,
                Message = message
            };
        }

        public static CommandResult CreateInformationResult(string message)
        {
            return new CommandResult
            {
                Type = ResultType.Information,
                Message = message
            };
        }

        public static CommandResult CreateErrorResult(string message)
        {
            return new CommandResult
            {
                Type = ResultType.Error,
                Message = message
            };
        }
        
        public static CommandResult CreateErrorResult(Exception ex)
        {
            return new CommandResult
            {
                Type = ResultType.Error,
                Message = string.Format("{0}{1}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace),
                Exception = ex
            };
        }
    }
}
