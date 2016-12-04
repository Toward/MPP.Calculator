using System.ServiceModel;

namespace CalculatorService.Contracts
{
    [ServiceContract(Namespace = "http://Calculator")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double a, double b);
        [OperationContract]
        double Substract(double a, double b);
        [OperationContract]
        double Multiply(double a, double b);
        [OperationContract]
        double Divide(double a, double b);
        [OperationContract]
        double Sqrt(double a);
    }
}
