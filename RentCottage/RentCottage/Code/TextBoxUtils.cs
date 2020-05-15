using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCottage
{
    public class TextBoxUtils
    {
        public static string ModifyInput(string input, int maxLength) //modifies the textbox input in case it contains backslashes or apostrophes
        {
            string output0 = input.Replace("\\","");
            string output1 = output0.Replace("\'", "\\'");
            if (output1.Length > maxLength)
            {
                output1 = output1.Substring(0, maxLength);
                if (output1.Substring(maxLength - 1, 1).Equals("\\"))
                {
                    output1 = output1.Substring(0, maxLength - 1);
                }
            }
            return output1;
        }
    }
}
