using System;

class Program
{
    static void Main()
    {
        double x = ReadDouble();
        Console.WriteLine("Giá trị căn bậc 2 của {0} là: {1}", x, Math.Sqrt(x));
    }

    public static double ReadDouble()
    {
        double result;
        while (true)
        {
            Console.Write("Nhập vào một số thực 8 byte: ");
            string input = Console.ReadLine();
            if (double.TryParse(input, out result))
            {
                break;
            }
            else
            {
                Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
            }
        }
        return result;
    }
}
