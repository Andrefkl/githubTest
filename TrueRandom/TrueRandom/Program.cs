using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueRandom
{
    class Program
    {
        Random Ran = new Random();
        static void Main(string[] args)
        {
            Program p = new Program();
            while (true)
            {
                Console.WriteLine("Tests for array vs list speed");

                Console.WriteLine("Choose: 'True Random'    'Sort', or 'end' to stop the program");
                string input = Console.ReadLine().ToLower();
                if (input == "end")
                    break;
                Console.WriteLine("Write how many numbers you want to use:");
                int sizeNumbers = int.Parse(Console.ReadLine());

                if (input == "true random")
                    p.CheckTrueRandomListVsArray(sizeNumbers);
                else if (input == "sort")
                    p.CheckSortListVsArray(sizeNumbers);

                Console.WriteLine();
            }
            
        }

        public double SortArray(int sizeNumbers)
        {
            int[] numbers = new int[sizeNumbers];

            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = Ran.Next(1, 1001);

            DateTime startTime = DateTime.Now;
            Array.Sort(numbers);
            DateTime endTime = DateTime.Now;

            double timeInTicks = (endTime - startTime).TotalMilliseconds;
            return timeInTicks;
        }
        public double SortList(int sizeNumbers)
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < sizeNumbers; i++)
                numbers.Add(Ran.Next(1, 1001));

            DateTime startTime = DateTime.Now;
            numbers.Sort();
            DateTime endTime = DateTime.Now;

            double timeInTicks = (endTime - startTime).TotalMilliseconds;
            return timeInTicks;
        }
        public void CheckSortListVsArray(int sizeNumbers)
        {
            List<double> timesArray = new List<double>();
            List<double> timesList = new List<double>();

            DateTime startTime = DateTime.Now;
            for (int i = 0; i < sizeNumbers; i++)
                timesArray.Add(SortArray(sizeNumbers));
            DateTime endTime = DateTime.Now;
            double timesArrayTotal = (endTime - startTime).TotalMilliseconds;
            startTime = DateTime.Now;

            for (int i = 0; i < sizeNumbers; i++)
                timesList.Add(SortList(sizeNumbers));
            endTime = DateTime.Now;            
            double timesListTotalt = (endTime - startTime).TotalMilliseconds;

            Console.WriteLine("The total time when sorting an array with " + sizeNumbers + " numbers is " + timesArrayTotal);
            Console.WriteLine("The total time when sorting a list with " + sizeNumbers + " numbers is " + timesListTotalt);
        }

        public void CheckTrueRandomListVsArray(int sizeNumbers)
        {
            List<double> timesArray = new List<double>();
            List<double> timesList = new List<double>();

            for (int i = 0; i < sizeNumbers; i++)
                timesArray.Add(TrueRandomWithArray(sizeNumbers));
            for (int i = 0; i < sizeNumbers; i++)
                timesList.Add(TrueRandomWithList(sizeNumbers));

            double timesArrayAvg = timesArray.Average();
            double timesListAvg = timesList.Average();

            Console.WriteLine("The average time when generating " + sizeNumbers + " numbers with an array is " + timesArrayAvg);
            Console.WriteLine("The average time when generating " + sizeNumbers + " numbers with a list is " + timesListAvg);
        }

        public double TrueRandomWithArray(int wantedNumbers)
        {
            int[] numbers = new int[wantedNumbers];

            int placeholder;
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < wantedNumbers; i++)
            {
                placeholder = Ran.Next(0, wantedNumbers+1);
                while (numbers.Contains(placeholder))
                    placeholder = Ran.Next(wantedNumbers + 1);
                numbers[i] = placeholder;
            }
            DateTime endTime = DateTime.Now;

            double timeInTicks = (endTime - startTime).TotalMilliseconds;  

            return timeInTicks;
        }
        public double TrueRandomWithList(int wantedNumbers)
        {
            List<int> numbers = new List<int>();

            int placeholder;
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < wantedNumbers; i++)
            {
                placeholder = Ran.Next(0, wantedNumbers + 1);
                while (numbers.Contains(placeholder))
                    placeholder = Ran.Next(wantedNumbers + 1);
                numbers.Add(placeholder);
            }
            DateTime endTime = DateTime.Now;

            double timeInTicks = (endTime - startTime).TotalMilliseconds;

            return timeInTicks;
        }
    }
}
