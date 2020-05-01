using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCottage
{
    public class TextBoxUtils
    {
        public static string modifyInput(string input, int maxLength)
        {
            string output0 = input.Replace("\\","");
            string output1 = output0.Replace("\'", "\\'");
            if (output1.Length > maxLength)
            {
                output1 = output1.Substring(0, maxLength);
            }
            return output1;
        }
    }
}
