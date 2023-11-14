using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlaces.API.Extensions
{
    public static class StringExtensions
    {
        public static int IndexOf(this string s, Func<char, bool> predicate)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (predicate(s[i]))
                {
                    return i;
                }
            }


            return -1;
        }

        public static bool StartsWith(this string s, Func<char, bool> predicate)
        {
            if (s.Length == 0)
            {
                return false;
            }
            else
            {
                return predicate(s[0]);
            }
        }

        public static string RemoveFirstWord(this string s)
        {
            int index = s.IndexOf(c => char.IsWhiteSpace(c) || char.IsPunctuation(c));

            if (index != -1)
            {
                s = s.Remove(0, index + 1).TrimStart();

                while (s.StartsWith(char.IsPunctuation))
                {
                    s = s.Remove(0, 1).TrimStart();
                }
            }

            return s;
        }
    }
}
