using System;
namespace Covid19Tracker.Helpers
{
    public static class ExtensionMethods
    {
        public static string TransformNumberToString(this int number)
        {
            switch (number.ToString().Length)
            {
                case 1:
                case 2:
                case 3:
                    return number.ToString();
                case 4:
                    return $"{number.ToString().Insert(1, ",").Substring(0, 3)}k";
                case 5:
                    return $"{number.ToString().Insert(2, ",").Substring(0, 4)}k";
                case 6:
                    return $"{number.ToString().Insert(3, ",").Substring(0, 5)}k";
                default:
                    return $"{number.ToString().Insert(1, ",").Substring(0, 3)}M";
            }
        }

        public static string TransformNumericString(this string number)
        {
            switch (number.Length)
            {
                case 1:
                case 2:
                case 3:
                    return number.ToString();
                case 4:
                    return $"{number.Insert(1, ",").Substring(0, 3)}k";
                case 5:
                    return $"{number.Insert(2, ",").Substring(0, 4)}k";
                case 6:
                    return $"{number.Insert(3, ",").Substring(0, 5)}k";
                default:
                    return $"{number.Insert(1, ",").Substring(0, 3)}M";
            }
        }

        public static DateTime TransformLongToDateTime(this long value)
        {
            return new DateTime(1970, 1, 1).AddMilliseconds(value).ToLocalTime();
        }

        
    }
}
