using System.Collections.Generic;
using ConsoleCalculatorClient.Enums;

namespace ConsoleCalculatorClient.Models
{
    internal class OperationInfo
    {
        internal IEnumerable<double> Arguments { get; set; }
        internal OperationType Operation { get; set; }

        public OperationInfo(IEnumerable<double> arguments, OperationType operation )
        {
            Arguments = arguments;
            Operation = operation;
        }
    }
}
