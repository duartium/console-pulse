namespace BigSorting
{
    internal class BigIntegerStringComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException(x == null ? nameof(x) : nameof(y));
            }

            if (x.Length != y.Length)
            {
                return x.Length.CompareTo(y.Length);
            }

            return string.Compare(x, y, StringComparison.Ordinal);
        }
    }
}
