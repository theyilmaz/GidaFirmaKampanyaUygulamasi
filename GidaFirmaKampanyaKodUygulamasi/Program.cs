using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
       
        List<string> generatedCodes = GenerateCodes(1000);

        foreach (var code in generatedCodes)
        {
            bool isValid = CheckCode(code);
            Console.WriteLine($"Code: {code}, IsValid: {isValid}");
        }
    }

    static List<string> GenerateCodes(int count)
    {
        List<string> codes = new List<string>();
        Random random = new Random();

        while (codes.Count < count)
        {
          
            string code = new string(Enumerable.Repeat("ACDEFGHKLMNPRTXYZ234579", 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());

           
            if (!codes.Contains(code))
            {
                codes.Add(code);
            }
        }

        return codes;
    }

    static bool CheckCode(string code)
    {
        
        string pattern = "^[ACDEFGHKLMNPRTXYZ234579]{8}$";
        return Regex.IsMatch(code, pattern);
    }
}
