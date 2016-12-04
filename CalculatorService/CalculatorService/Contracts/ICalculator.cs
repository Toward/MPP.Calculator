using System.ServiceModel;

namespace CalculatorService.Contracts
{
    [ServiceContract(Namespace = "http://Calculator")]
    public interface ICalculator
    {
        [OperationContract]
        [FaultContract(typeof(CalculationFault))]
        double Add(double a, double b);
        [OperationContract]
        [FaultContract(typeof(CalculationFault))]
        double Substract(double a, double b);
        [OperationContract]
        [FaultContract(typeof(CalculationFault))]
        double Multiply(double a, double b);
        [OperationContract]
        [FaultContract(typeof(CalculationFault))]
        double Divide(double a, double b);
        [OperationContract]
        [FaultContract(typeof(CalculationFault))]
        double Sqrt(double a);
    }
}
