using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException(nameof(stringValue), "String cannot be null, empty or whitespace");
            }

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                throw new FormatException($"Symbol '{stringValue}' cannot be part of a number");
            }

            stringValue = stringValue.Trim();

            var isNegative = IsNegative(stringValue);
            var hasPlus = HasPlus(stringValue);

            long result = 0;

            var start = isNegative || hasPlus ? 1 : 0;

            for (var i = start; i < stringValue.Length; i++)
            {
                if (!char.IsDigit(stringValue[i]))
                {
                    throw new FormatException($"Symbol '{stringValue[i]}' cannot be part of a number");
                }
                result = result * 10 + stringValue[i] - '0';
            }

            if(isNegative)
            {
                result = -result;
            }

            if (result < int.MinValue || result > int.MaxValue)
            {
                throw new OverflowException("The result doesn't fit the expected range.");
            }

            return Convert.ToInt32(result);
        }

        private static bool IsNegative(string value) => value.StartsWith('-');
        private static bool HasPlus(string value) => value.StartsWith('+');
    }
}