using System.Diagnostics.CodeAnalysis;

namespace Autokauppa_DAO
{
    public static class Methods
    {
        public static bool Empty(this IEnumerable<object>? list)
        {
            if (list == null)
            {
                return false;
            }

            if (!list.Any())
            {
                return false;
            }

            return true;
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
