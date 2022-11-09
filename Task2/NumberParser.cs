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

            if (string.IsNullOrEmpty(stringValue) || string.IsNullOrWhiteSpace(stringValue))
            {
                throw new FormatException($"Symbol '{stringValue}' cannot be part of a number");
            }

            stringValue = stringValue.Trim();

            var isNegative = IsNegative(stringValue);
            var hasPlus = HasPlus(stringValue);

            var result = 0;
            var start = isNegative || hasPlus ? 1 : 0;

            for (var i = start; i < stringValue.Length; i++)
            {
                if (stringValue[i] < '0' || stringValue[i] > '9')
                {
                    throw new FormatException($"Symbol '{stringValue[i]}' cannot be part of a number");
                }

                try
                {
                    result = checked(result * 10 + stringValue[i] - '0');
                }
                catch (OverflowException)
                {
                    throw new OverflowException($"Can't be converted, because number must be between {int.MinValue} and {int.MaxValue}");
                }
            }

            return isNegative ? -result : result;
        }

        private static bool IsNegative(string value) => value[0] == '-';
        private static bool HasPlus(string value) => value[0] == '+';
    }
}