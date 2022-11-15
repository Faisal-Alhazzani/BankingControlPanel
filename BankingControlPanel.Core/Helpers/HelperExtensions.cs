namespace BankingControlPanel.Core.Helpers
{
    public static class HelperExtensions
    {
        public static int Default(this int? @this, int value) => @this ?? value;
        public static int AtLeast(this int @this, int value) => Math.Max(@this, value);
        public static int AtMost(this int @this, int value) => Math.Min(@this, value);
        public static int AtLeast(this int? @this, int value) => Math.Max(@this ?? value, value);
        public static int AtMost(this int? @this, int value) => Math.Min(@this ?? value, value);
        public static int Within(this int? @this, int min, int max, int @default)
            => @this.Default(@default).AtLeast(min).AtMost(max);
    }
}
