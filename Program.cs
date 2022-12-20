using System;
using System.Collections.Generic;

namespace DSA2._3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<decimal> coinsType = new List<decimal>();


            bool finished = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("****************WELCOME TO DISPENSING MACHINE****************");
                Console.WriteLine("----------NOTE: WE ONLY TAKE MAXIMUM 5$ TO DISPENSE----------");
                Console.WriteLine("Tap 1 to enter the amount you want to dispense");
                Console.WriteLine("Tap 2 to enter the amount you want to dispense in the smallest way");
                Console.WriteLine("Tap 0 to EXIT");
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine();

                int answer;
                answer = Convert.ToInt32(Console.ReadLine());

                while (answer != 1 && answer != 2 && answer != 0)
                {
                    Console.Write("This option does not exist. Choose an existing one: ");
                    answer = int.Parse(Console.ReadLine());
                }
                Console.WriteLine();
                switch (answer)
                {
                    case 1:
                        {
                            Console.WriteLine("Please enter the money value");
                            decimal money = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("----------------------------------------------------");
                            Console.WriteLine($"{money}$ can be dispensed in these options below: ");
                            Console.WriteLine("-----------------------------------------------------");
                            if (money <= 5)
                            {
                                getAllChange(coinsType, 10, 0, 0, money);
                            }
                            else
                            {
                                Console.WriteLine("Please enter a lower amount of money");
                            }
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Enter the amount of money");
                            decimal money2 = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("---------------------------------------------------------------------");
                            Console.WriteLine($"Smallest way that: {money2}$ can be dispensed is the option below: ");
                            Console.WriteLine("---------------------------------------------------------------------");
                            if (money2 <= 5)
                            {
                                smallestDispense(money2);
                            }
                            else
                            {
                                Console.WriteLine("Please enter a lower amount of money");
                            }
                        }
                        break;
                    case 0:
                        {

                            finished = true;
                        }
                        break;
                }
            } while (!finished);
        }

        static List<decimal> denominations = new List<decimal> { 2.0M, 1.0M, 0.5M, 0.2M, 0.1M, 0.05M, 0.02M, 0.01M };

        private static void display(List<decimal> coinsType)
        {
            foreach (decimal denomination in coinsType)
            {
                Console.Write($"{denomination}$; ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        static void getAllChange(List<decimal> coins, int maxCoins, decimal highest, decimal sum, decimal amountToGet)
        {
            if (sum == amountToGet)
            {
                display(coins);
                return;
            }

            if (sum > amountToGet || coins.Count == maxCoins)
            {
                return;
            }

            foreach (decimal value in denominations)
            {
                if (value >= highest)
                {
                    List<decimal> coinsNeeded = new List<decimal>(coins);
                    coinsNeeded.Add(value);
                    getAllChange(coinsNeeded, maxCoins, value, sum + value, amountToGet);
                }
            }
        }

        static void smallestDispense(decimal value)
        {

            int i = 0;
            string result = null;

            while (value > 0)
            {
                if (denominations[i] <= value)
                {
                    result += denominations[i] + "$ ";
                    value -= denominations[i];
                }
                else
                {
                    i += 1;
                }
                if (value == 0)
                {
                    break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
