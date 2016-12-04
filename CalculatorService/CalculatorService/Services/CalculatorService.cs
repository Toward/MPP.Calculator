using System;
using System.ServiceModel;
using CalculatorService.Contracts;

namespace CalculatorService.Services
{
    public class CalculatorService: ICalculator
    {
        #region Public Methods
        public double Add(double a, double b)
        {
            return SafeCalculation(() => a + b);
        }

        public double Substract(double a, double b)
        {
            return SafeCalculation(() => a - b);
        }

        public double Multiply(double a, double b)
        {
            return SafeCalculation(() => a * b);
        }

        public double Divide(double a, double b)
        {
            return SafeCalculation(() => a / b);
        }

        public double Sqrt(double a)
        {
            return SafeCalculation(() => Math.Sqrt(a));
        }

        #endregion

        #region Private Methods

        private double SafeCalculation(Func<double> calculation)
        {
            var result = calculation();

            if (double.IsNaN(result))
            {
                var calculationFault = new CalculationFault("Result is NaN.");
                throw new FaultException<CalculationFault>(calculationFault);
            }
            if (double.IsInfinity(result))
            {
                var calculationFault = new CalculationFault("Result is infinity. Possible division by zero or overflow.");
                throw new FaultException<CalculationFault>(calculationFault);
            }

            return result;
        }

        #endregion
    }
}
