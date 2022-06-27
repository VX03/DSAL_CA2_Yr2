using System;
using System.Collections.Generic;
using System.Text;

namespace DSAL_CA2_Yr2.Classes
{
    public class General
    {
        public bool checkAlphabetAndSpace(string s)
        {
            if (s == null)
                return false;

            for (int i = 0; i < s.Length; i++)
            {
                if (!Char.IsLetter(s[i]) && !Char.IsWhiteSpace(s[i]))
                {
                    return false;
                }
            }
            return true;
        }// End of checkAlphabetAndSpace
    }
}
