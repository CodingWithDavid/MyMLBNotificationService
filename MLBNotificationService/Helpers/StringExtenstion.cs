
namespace MLBNotificationService
{
    public static class StringExtenstion
    {
        /// <summary>
        /// checks to see if the string is null or empty
        /// </summary>
        /// <param name="str">source string</param>
        /// <returns>true if empty</returns>
        public static bool IsEmpty(this string str)
        {
            bool result = false;
            result = string.IsNullOrEmpty(str);
            return result;
        }

        /// <summary>
        /// checks to see if the string is not null or empty
        /// </summary>
        /// <param name="str">source string</param>
        /// <returns>true if the string is not empty</returns>
        public static bool IsNotEmpty(this string str)
        {
            bool result = false;
            result = !string.IsNullOrEmpty(str);
            return result;
        }

        /// <summary>
        /// converts a string to an integer
        /// </summary>
        /// <param name="str">source string</param>
        /// <returns>integer</returns>
        public static int ToInt(this string str)
        {
            int.TryParse(str, out int result);
            return result;
        }
    }
}
