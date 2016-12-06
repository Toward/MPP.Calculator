using System;
using System.ServiceModel;
using ConsoleCalculatorClient.CalculatorService;
using ConsoleCalculatorClient.Services;

namespace ConsoleCalculatorClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CalculationService calculationService = null;
            try
            {
                var operation = ArgumentsParser.GetOperationInfo(args);
                if (operation == null)
                    throw new ArgumentException("Invailid arguments");

                calculationService = new CalculationService();
                Console.WriteLine(calculationService.PerformOperation(operation));
            }
            catch (FaultException<CalculationFault> e)
            {
                Console.WriteLine($"{e.Detail.Message}");
            }
            catch (CommunicationException)
            {
                Console.WriteLine("Connection error");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                calculationService?.Dispose();
            }
        }
    }
}
