using System.Diagnostics.CodeAnalysis;

namespace Autokauppa_DAO
{
    public static class Methods
    {
        public static bool Empty(this IEnumerable<object>? list)
        {
            if (list == null)
            {
                return true;
            }

            if (!list.Any())
            {
                return true;
            }

            return false;
        }

        public static bool IsWhitespace(this string? toCheck)
        {
            if (string.IsNullOrWhiteSpace(toCheck))
            {
                return true;
            }
            return false;
        }
    }
}
