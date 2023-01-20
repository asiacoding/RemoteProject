using System;
using System.Collections.Generic;
using System.Text;

namespace BlueApp1.Extensions
{
    internal static class MT
    {
        public const string SystemGuid = "7FDC63DB-BBE2-49A5-BE76-79799E8B72DA>"; // It' is System Code Def
        public static string ConvertDECtoBIN(this object ObjNumber)
        {
            string answer;
            string result;
            answer = ObjNumber.ToString();
            long num = Convert.ToInt64(answer);
            result = "";
            while (num > 1)
            {
                long remainder = num % 2;
                result = Convert.ToString(remainder) + result;
                num /= 2;
            }
            result = Convert.ToString(num) + result;
            return result;
        }
        public static string ConvertBINtoDEC(this object ObjNumber)
        {
            //Check
            int Power(int n) => 
                n == 0 ? 1 : 2 * Power(n - 1);

            string s1 = ObjNumber.ToString();
            string s2 = "";
            string sum = "";
            for (int i = s1.Length - 1; i >= 0; i--)
            {
                s2 += s1[i];
            }
            for (int i = 0; i < s2.Length; i++)
            {
                int res = Power(i);
                sum = sum + (res * int.Parse(s2[i].ToString()));
            }
            return sum;
        }
    }
}
