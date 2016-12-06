using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleCalculatorClient.CalculatorService;
using ConsoleCalculatorClient.Enums;
using ConsoleCalculatorClient.Models;

namespace ConsoleCalculatorClient.Services
{
    internal class CalculationService : IDisposable
    {
        #region Private Members

        private readonly CalculatorClient _client = new CalculatorClient();

        private readonly Dictionary<OperationType, Func<double[], CalculatorClient, double>> _calculatorOperations = new Dictionary
            <OperationType, Func<double[], CalculatorClient, double>>
            {
                {OperationType.Add, (arguments, client) => client.Add(arguments[0], arguments[1])},
                {OperationType.Divide, (arguments, client) => client.Divide(arguments[0], arguments[1])},
                {OperationType.Multiply, (arguments, client) => client.Multiply(arguments[0], arguments[1])},
                {OperationType.Substract, (arguments, client) => client.Substract(arguments[0], arguments[1])},
                {OperationType.Sqrt, (arguments, client) => client.Sqrt(arguments[0])}
            };

        #endregion

        #region Public Methods

        public void Dispose()
        {
            try
            {
                _client.Close();
            }
            catch (Exception)
            {
               _client.Abort();
            }
        }

        #endregion

        #region Internal Methods

        internal double PerformOperation(OperationInfo operationInfo)
        {
            if (operationInfo == null)
                throw new ArgumentNullException(nameof(operationInfo));
            if(operationInfo.Arguments == null)
                throw new ArgumentNullException();

            var operation = _calculatorOperations[operationInfo.Operation];
            var result = operation(operationInfo.Arguments.ToArray(), _client);

            return result;
        }

        #endregion
    }
}
