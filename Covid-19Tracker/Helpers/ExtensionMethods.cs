using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Covid19Tracker.Helpers
{
    public static class ExtensionMethods
    {
        public static string TransformNumberToString(this int number)
        {
            switch (number.ToString().Length)
            {
                case 4:
                    return $"{number.ToString().Insert(1, ",").Substring(0, 3)}k";
                case 5:
                    return $"{number.ToString().Insert(2, ",").Substring(0, 4)}k";
                case 6:
                    return $"{number.ToString().Insert(3, ",").Substring(0, 5)}k";
                case 7:
                    return $"{number.ToString().Insert(1, ",").Substring(0, 3)}M";
                case 8:
                    return $"{number.ToString().Insert(2, ",").Substring(0, 4)}M";
                case 9:
                    return $"{number.ToString().Insert(3, ",").Substring(0, 5)}M";
                default:
                    return number.ToString();
            }
        }

        public static string TransformNumberToSpacing(this int number)
        {
            var nfi = new NumberFormatInfo();
            nfi.NumberGroupSeparator = " ";
            return number.ToString("N0", nfi);
        }

        public static string TransformNumericString(this string number)
        {
            switch (number.Length)
            {
                case 4:
                    return $"{number.ToString().Insert(1, ",").Substring(0, 3)}k";
                case 5:
                    return $"{number.ToString().Insert(2, ",").Substring(0, 4)}k";
                case 6:
                    return $"{number.ToString().Insert(3, ",").Substring(0, 5)}k";
                case 7:
                    return $"{number.ToString().Insert(1, ",").Substring(0, 3)}M";
                case 8:
                    return $"{number.ToString().Insert(2, ",").Substring(0, 4)}M";
                case 9:
                    return $"{number.ToString().Insert(3, ",").Substring(0, 5)}M";
                default:
                    return number.ToString();
            }
        }

        public static DateTime TransformLongToDateTime(this long value)
        {
            return new DateTime(1970, 1, 1).AddMilliseconds(value).ToLocalTime();
        }

        public static string TimeAgo(this DateTime dateTime)
        {
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(dateTime);

            if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    String.Format("Há {0} minutos", timeSpan.Minutes) :
                    "Há 1 minuto";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    String.Format("Há {0} horas", timeSpan.Hours) :
                    "Há 1 hora";
            }
            else
                result = string.Format("{0:d MMMM yyyy}", dateTime);

            return result;
        }

        public static string RemoveDiacriticalMarks(this string text)
        {
            return new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }
    }
}
