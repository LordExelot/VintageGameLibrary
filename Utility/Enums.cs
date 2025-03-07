namespace VintageGameLibrary.Utility
{
    public static class Enums
    {
        public static string? Stringify<T>(T value, char replaceUnderScoreWith = ' ') where T : Enum
        {
            return Enum.GetName(typeof(T), value)?.Replace('_', replaceUnderScoreWith);
        }
    }
}
