using System;

class Program
{
    static void Main()
    {
        Console.Write("Nhập vào một xâu kí tự: ");
        string st = Console.ReadLine();
        
        if (st == "#")
        {
            Console.Beep();
        }
        else
        {
            int wordCount = CountWords(st);
            Console.WriteLine("Số từ trong xâu kí tự là: " + wordCount);
        }
    }

    public static int CountWords(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return 0;
        }

        string[] words = str.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }
}
