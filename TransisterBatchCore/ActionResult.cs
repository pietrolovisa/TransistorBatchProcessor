using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransisterBatchCore
{
    public enum ActionResultCode
    {
        Success,
        Failed
    }

    public class ActionResult<T>
    {
        public ActionResultCode ResultCode { get; set; }
        public bool Success => ResultCode == ActionResultCode.Success;
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public T Data { get; set; }

        public void SetError(string message, ActionResultCode pluginResultCode = ActionResultCode.Failed)
        {
            ResultCode = pluginResultCode;
            Message = message;
        }

        public void SetError(Exception exception, string message, ActionResultCode pluginResultCode = ActionResultCode.Failed)
        {
            Exception = exception;
            SetError(message, pluginResultCode);
        }

        public void SetError<SourceT>(ActionResult<SourceT> source)
        {
            SetError(source.Message, source.ResultCode);
        }

        public string Dump
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (Message == null) Message = string.Empty;
                    Message += Message.Length > 0 ? $"{Environment.NewLine}{value}" : value;
                }
            }
        }
    }

    public class ActionResult : ActionResult<string>
    {
        public override string ToString()
        {
            return $"success [{Success}] result code [{ResultCode}] data [{Data}] message [{Message}] exception [{Exception}]";
        }
    }
}
