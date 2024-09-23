using System;
using System.Threading;
using VBJ._13B.Group2;

public class Program 
{
    // Konzol alkalmazás belépési pontja -> rányomsz az exére
    public static void Main()
    {
        // Futár felvétele

        GLS gls = new GLS();
        for (int i = 0; i < 5; i++)
        {
            gls.HireCourier();
        }

        DateTime dateTime = DateTime.Now;
        for (int i = 0; i < 365; i++)
        {
            // ugyanaz mint i + 1 + ". munkanap"
            Console.Write($"{i+1}. munkanap |\t");
            Console.WriteLine(dateTime);
            gls.WorkDay();
            dateTime = dateTime.AddDays(1);

            Thread.Sleep(2000);
        }

        Console.WriteLine();
    }
}