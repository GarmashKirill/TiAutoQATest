using System;
using static System.Console;

namespace TeamInternational
{
    class Program
    {
        static void Main(string[] args)
        {
            double ax = 0;
            double ay = 0;
            double bx = 0;
            double by = 0;
            double cx = 0;
            double cy = 0;
            double lengthAB = 0;
            double lengthBC = 0;
            double lengthAC = 0;
            double perimeter = 0;
            double delta = 0.1;

            try
            {
                WriteLine("Enter coordinate x of dot A:");
                ax = double.Parse(ReadLine());
                WriteLine("Enter coordinate y of dot A:");
                ay = double.Parse(ReadLine());

                WriteLine("Enter coordinate x of dot B:");
                bx = double.Parse(ReadLine());
                WriteLine("Enter coordinate y of dot B:");
                by = double.Parse(ReadLine());

                WriteLine("Enter coordinate x of dot C:");
                cx = double.Parse(ReadLine());
                WriteLine("Enter coordinate y of dot C:");
                cy = double.Parse(ReadLine());   
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                ReadLine();
                Environment.Exit(0);
            }
            CheckInputData(ax, ay, bx, by, cx, cy);

            //length
            lengthAB = GetLength(ax, ay, bx, by);
            lengthBC = GetLength(bx, by, cx, cy);
            lengthAC = GetLength(ax, ay, cx, cy);

            WriteLine("Length of AB is: '" + lengthAB + "'");
            WriteLine("Length of BC is: '" + lengthBC + "'");
            WriteLine("Length of AC is: '" + lengthAC + "'");
            WriteLine();

            //check equilateral
            if (Math.Abs(lengthAB - lengthBC) < delta
               && Math.Abs(lengthBC - lengthAC) < delta
               && Math.Abs(lengthAC - lengthAB) < delta)
            {
                WriteLine("Triangle IS 'Equilateral'");
            }
            else
            {
                WriteLine("Triangle IS NOT 'Equilateral'");
            }

            //check Isosceles
            if (Math.Abs(lengthAB - lengthBC) < delta
               || Math.Abs(lengthBC - lengthAC) < delta
               || Math.Abs(lengthAC - lengthAB) < delta)
            {
                WriteLine("Triangle IS 'Isosceles'");
            }
            else
            {
                WriteLine("Triangle IS NOT 'Isosceles'");
            }

            //check right
            if (Math.Abs(Math.Pow(lengthAC, 2) - (Math.Pow(lengthAB, 2) + Math.Pow(lengthBC, 2))) < delta
               || Math.Abs(Math.Pow(lengthBC, 2) - (Math.Pow(lengthAB, 2) + Math.Pow(lengthAC, 2))) < delta
               || Math.Abs(Math.Pow(lengthAB, 2) - (Math.Pow(lengthAC, 2) + Math.Pow(lengthBC, 2))) < delta)
            {
                WriteLine("Triangle IS 'Right'");
            }
            else
            {
                WriteLine("Triangle IS NOT 'Right'");
            }
            WriteLine();

            //perimeter
            perimeter = lengthAB + lengthBC + lengthAC;
            WriteLine("Perimeter: '" + perimeter + "'");
            WriteLine();

            //parity numbers
            WriteLine("Parity numbers in range from 0 to triangle perimeter:");
            for(int i = 0; i <= perimeter; i++)
            {
                if(i % 2 == 0)
                {
                    WriteLine(i);
                }
            }
            ReadLine();
        }

        static void CheckInputData(double ax, double ay, double bx, double by, double cx, double cy)
        {
            bool samePoint = (ax == bx && ay == by)
                          || (ax == cx && ay == cy)
                          || (cx == bx && cy == by);

            bool line = (ax == bx && ax == cx)
                     || (ay == by && ay == cy);

            if (samePoint || line)
            {
                WriteLine("Incorrect input data.");
                ReadLine();
                Environment.Exit(0);
            }
        }

        static double GetLength(double ax, double ay, double bx, double by)
        {
            return Math.Sqrt(Math.Pow((bx - ax), 2) + Math.Pow((by - ay), 2));
        }
    }
}
