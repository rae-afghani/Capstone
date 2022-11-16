using System.Text;

namespace CapstoneV4.Models.ExtensionMethods
{

    //creating extension methods that will make it easier to
    //manipulate strings throughout the solution
    public static class StringsEXT
    {
        public static string Slug(this string s)
        {
            var sBuilder = new StringBuilder();
            foreach(char c in s)
            {
                //this conditional will ignore dashes/punctuation
                //in slugs
                if (c == '-' || !char.IsPunctuation(c))
                {
                    sBuilder.Append(c);
                }
            }

            //creates user friendly slugs,
            //replaces whitespace with dashes
            //text transform to lowercase
            return sBuilder.ToString().Replace(' ', '-').ToLower();
        }

        //evaluates string to make sure that its lowercase
        public static bool EqualsNoCase(this string s, string compare) =>
            s?.ToLower() == compare?.ToLower();


        //conversion string to int
        //includes try parse
        public static int ToInt(this string s)
        {
            int.TryParse(s, out int id);
            return id;
        }

        //text transform to uppercase
        //null check on string
        //if NOT NULL, return subtring(0,1)--starting at the first character
        //if Substring(0,1) returns NULL, nothing changes
        //in the case that subtring(0,1) is NOT NULL, 
        //the specified string becomes uppercase
        //then, if s.Substring(1) is NOT NULL, append
        public static string Uppercase(this string s) =>
            s?.Substring(0, 1)?.ToUpper() + s?.Substring(1);
    }
}
