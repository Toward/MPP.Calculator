using System.Collections.Generic;
using System.Linq;
using ConsoleCalculatorClient.Enums;
using ConsoleCalculatorClient.Models;

namespace ConsoleCalculatorClient.Services
{
    internal static class ArgumentsParser
    {
        #region Private Members

        private const int MinArgumentsCount = 2;
        private const int MaxArgumentsCount = 3;
        private const int OperationParameterIndex = 0;

        private static readonly Dictionary<string, OperationType> OperationDictionary = new Dictionary<string, OperationType>
        {
            {"+", OperationType.Add},
            {"-", OperationType.Substract},
            {"/", OperationType.Divide},
            {"*", OperationType.Multiply},
            {"sqrt", OperationType.Sqrt}
        };

        #endregion

        #region Internal Methods

        internal static OperationInfo GetOperationInfo(string[] args)
        {
            OperationType opertionType;

            var argumentsCount = args.Length;
            var operationArguments = GetArguments(args);

            if ((argumentsCount < MinArgumentsCount) ||
                (argumentsCount > MaxArgumentsCount) ||
                operationArguments == null ||
                !OperationDictionary.TryGetValue(args[OperationParameterIndex], out opertionType))
                return null;

            return new OperationInfo(operationArguments, opertionType);
        }

        #endregion

        #region Private Methods

        private static IEnumerable<double> GetArguments(IEnumerable<string> args)
        {
            var result = new List<double>();
            args = args.Skip(OperationParameterIndex + 1);

            foreach (var argument in args)
            {
                double destination;
                if (double.TryParse(argument, out destination))
                    result.Add(destination);
            }

            return (result.Count != 0)
                ? result
                : null;
        }

        #endregion
    }
}
