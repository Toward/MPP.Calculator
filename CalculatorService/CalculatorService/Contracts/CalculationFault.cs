using System.Runtime.Serialization;

namespace CalculatorService.Contracts
{
    [DataContract]
    public class CalculationFault
    {
        [DataMember]
        public string Message { get; internal set; }

        internal CalculationFault(string message)
        {
            Message = message;
        }
    }
}
