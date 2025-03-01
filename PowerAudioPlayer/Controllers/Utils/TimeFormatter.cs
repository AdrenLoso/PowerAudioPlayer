using System.Text;

namespace PowerAudioPlayer.Controllers.Utils
{
    public enum TimeUnit
    {
        Seconds,
        Milliseconds,
        Microseconds
    }

    public static class TimeFormatter
    {
        public static string Format(
            decimal duration,
            TimeUnit unit = TimeUnit.Seconds,
            string format = "M\\:ss",
            bool ignoreOverflow = false)
        {
            try
            {
                decimal totalMicroseconds = ConvertToMicroseconds(duration, unit);
                var time = DecomposeTime(totalMicroseconds);
                return BuildFormattedString(format, time);
            }
            catch (OverflowException) when (ignoreOverflow)
            {
                return "∞";
            }
        }

        private static decimal ConvertToMicroseconds(decimal duration, TimeUnit unit)
        {
            return unit switch
            {
                TimeUnit.Seconds => duration * 1_000_000m,
                TimeUnit.Milliseconds => duration * 1_000m,
                TimeUnit.Microseconds => duration,
                _ => throw new ArgumentException("Invalid time unit")
            };
        }

        private static TimeComponents DecomposeTime(decimal totalMicroseconds)
        {
            const decimal microsecondPerDay = 86_400_000_000m;
            const decimal microsecondPerHour = 3_600_000m;
            const decimal microsecondPerMinute = 60_000m;

            return new TimeComponents
            {
                Days = Math.Floor(totalMicroseconds / microsecondPerDay),
                Hours = (int)(totalMicroseconds % microsecondPerDay / microsecondPerHour),
                Minutes = (int)(totalMicroseconds % microsecondPerHour / microsecondPerMinute),
                Seconds = (int)(totalMicroseconds % microsecondPerMinute / 1_000m),
                Milliseconds = (int)(totalMicroseconds % 1_000m / 1),
                TotalMicroseconds = totalMicroseconds
            };
        }

        private static string BuildFormattedString(string format, TimeComponents time)
        {
            var result = new StringBuilder();
            int position = 0;

            while (position < format.Length)
            {
                if (format[position] == '\\')
                {
                    HandleEscapeCharacter(format, result, ref position);
                }
                else if ("dhmsfMS".Contains(format[position]))
                {
                    ProcessFormatSpecifier(format, time, result, ref position);
                }
                else
                {
                    result.Append(format[position++]);
                }
            }

            return result.ToString();
        }

        private static void HandleEscapeCharacter(string format, StringBuilder result, ref int position)
        {
            if (position + 1 < format.Length)
            {
                result.Append(format[position + 1]);
                position += 2;
            }
            else
            {
                result.Append(format[position++]);
            }
        }

        private static void ProcessFormatSpecifier(
            string format,
            TimeComponents time,
            StringBuilder result,
            ref int position)
        {
            char specifier = format[position];
            int count = CountConsecutiveCharacters(format, position);
            string value = specifier switch
            {
                'd' => FormatDays(time.Days, count),
                'h' => FormatHours(time.Hours, count),
                'm' => FormatMinutes(time.Minutes, count),
                's' => FormatSeconds(time.Seconds, count),
                'f' => FormatFraction(time.TotalMicroseconds, count),
                'M' => FormatTotalMinutes(time, count),
                'S' => FormatTotalSeconds(time, count),
                _ => throw new FormatException($"Invalid format specifier '{specifier}'")
            };
            result.Append(value);
            position += count;
        }

        private static int CountConsecutiveCharacters(string format, int position)
        {
            char initial = format[position];
            int count = 0;
            while (position + count < format.Length &&
                   format[position + count] == initial)
            {
                count++;
            }
            return count;
        }

        private static string FormatDays(decimal days, int length)
        {
            string daysStr = days.ToString("0");
            return length > 1 ? daysStr.PadLeft(length, '0') : daysStr;
        }

        private static string FormatHours(int hours, int length)
        {
            return hours.ToString(length > 1 ? "D2" : "D");
        }

        private static string FormatMinutes(int minutes, int length)
        {
            return minutes.ToString(length > 1 ? "D2" : "D");
        }

        private static string FormatSeconds(int seconds, int length)
        {
            return seconds.ToString(length > 1 ? "D2" : "D");
        }

        private static string FormatFraction(decimal totalMicroseconds, int length)
        {
            decimal fraction = totalMicroseconds % 1_000_000;
            decimal scaledFraction = fraction * (decimal)Math.Pow(10, length - 6);
            return scaledFraction.ToString("F0").PadLeft(length, '0');
        }

        private static string FormatTotalMinutes(TimeComponents time, int length)
        {
            decimal totalMinutes = time.Days * 1440 + time.Hours * 60 + time.Minutes;
            return totalMinutes.ToString($"D{length}");
        }

        private static string FormatTotalSeconds(TimeComponents time, int length)
        {
            decimal totalSeconds = time.Days * 86400 + time.Hours * 3600 +
                                 time.Minutes * 60 + time.Seconds;
            return totalSeconds.ToString($"D{length}");
        }

        private struct TimeComponents
        {
            public decimal Days;
            public int Hours;
            public int Minutes;
            public int Seconds;
            public int Milliseconds;
            public decimal TotalMicroseconds;
        }
    }
}