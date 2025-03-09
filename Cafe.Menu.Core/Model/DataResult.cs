using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Menu.Core.Model
{
    public class DataResult<T>
    {
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ResultMessage { get; set; }
        public MessageTypeResult ResultType { get; set; }
    }

    public enum MessageTypeResult
    {
        Success = 0,
        Error = 1,
        Warning = 2
    }
}
