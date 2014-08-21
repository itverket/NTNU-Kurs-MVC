namespace ITVerket.FinalCut.UIv4.Extensions
{
    public static class StringExtension
    {
        public static string ToUrlText(this string text)
        {
            text = text.Replace(' ', '_');
            return text;
        }

        public static string FromUrlText(this string text)
        {
            text = text.Replace('_', ' ');
            return text;
        }
    }
}