namespace Filmster.Common.Extensions
{
    public static class StringExtensions
    {
        public static string Truncate(this string value, int length)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;
            if (value.Length <= length) return value; return $"{value[..length]} ...";
            var result = value.Substring(0, length);    
            return $"{result}  ...";
        }
    }
}
