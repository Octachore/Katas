namespace Core.Utils
{
    internal static class NumberExtensions
    {
        public static bool IsMultipleOf(this int a, int b)
        {
            return b.IsDividerOf(a);
        }

        public static bool IsDividerOf(this int a, int b)
        {
            if (a == 0 && b == 0) return true;
            if (a == 0 || b == 0) return false;
            return b % a == 0;
        }
    }
}
