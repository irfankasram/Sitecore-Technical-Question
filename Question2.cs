using System;

public class PalindromeChecker
{
    public static bool IsPalindromeWithTrashSymbols(string InputString, string TrashSymbolString)
    {
        InputString = InputString.ToLower();
        TrashSymbolString = TrashSymbolString.ToLower();

        int i = 0;
        int j = InputString.Length - 1;
        while (i < j)
        {
            while (i < InputString.Length && TrashSymbolString.Contains(InputString[i].ToString()))
            {
                i++;
            }
            while (j >= 0 && TrashSymbolString.Contains(InputString[j].ToString()))
            {
                j--;
            }
            if (i < j && InputString[i] != InputString[j])
            {
                return false;
            }
            i++;
            j--;
        }
        return true;
    }

    static void Main(String[] args)
    {
        string InputString = "a@b!!b$a";
        string TrashSymbolString = "!@$";
        bool isPalindrome = PalindromeChecker.IsPalindromeWithTrashSymbols(InputString, TrashSymbolString);
        Console.WriteLine(isPalindrome);
    }
}
