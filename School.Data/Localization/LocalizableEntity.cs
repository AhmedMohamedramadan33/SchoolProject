using System.Globalization;

namespace School.Data.Localization
{
    public static class LocalizableEntity
    {
        public static string localize(string textar, string texten)
        {
            CultureInfo cult = Thread.CurrentThread.CurrentCulture;
            if (cult.TwoLetterISOLanguageName.ToLower().Equals("ar"))
            {
                return textar;
            }
            return texten;
        }
    }
}
