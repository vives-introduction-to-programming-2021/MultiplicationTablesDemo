using System;
using System.Diagnostics;

namespace MultiplicationTablesDemo
{
    class Program
    {

        public static int RequestBaseNumber()
        {
            int baseNumber = 0;
            do
            {
                Console.Write("Please enter the base number [1,10]: ");
                baseNumber = Convert.ToInt32(Console.ReadLine());
            } while (baseNumber > 10 || baseNumber < 1);

            return baseNumber;
        }

        public static bool RequestToPlayRandom()
        {
            string userInput = "";
            do
            {
                Console.Write("Would you like to play random? [y/N]: ");
                userInput = Console.ReadLine().ToLower();
            } while (userInput != "n" && userInput != "y" && userInput != "");

            // Option 1
            // bool playRandom = false;
            // if (userInput == "y") {
            //   playRandom = true;
            // }
            // return playRandom;

            // Option 2
            return userInput == "y";
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Table Multiplicator");
            Console.WriteLine("This app teaches you the tables of multiplication");

            int baseNumber = RequestBaseNumber();
            bool playRandom = RequestToPlayRandom();

            int userAnswer = -1;
            int multiplier = 0;
            int totalCorrect = 0;
            int totalWrong = 0;
            const int RANDOM_MINIMUM = 0;
            const int RANDOM_MAXIMUM = 21;

            Random generator = new Random();
            if (playRandom)
            {
                multiplier = generator.Next(RANDOM_MINIMUM, RANDOM_MAXIMUM);
            }

            // Start timing
            Stopwatch watch = new Stopwatch();
            watch.Start();

            do
            {
                Console.Write($"{multiplier} x {baseNumber} = ? ");
                userAnswer = Convert.ToInt32(Console.ReadLine());

                if (userAnswer != -1)
                {
                    if (userAnswer == multiplier * baseNumber)
                    {
                        totalCorrect++;
                    }
                    else
                    {
                        totalWrong++;
                    }
                }

                if (playRandom)
                {
                    multiplier = generator.Next(RANDOM_MINIMUM, RANDOM_MAXIMUM);
                }
                else
                {
                    multiplier++;
                }

            } while (userAnswer != -1);

            // Stop timing
            watch.Stop();

            Console.WriteLine($"Correct answers: {totalCorrect}");
            Console.WriteLine($"Wrong answers: {totalWrong}");

            int percentage = 100 * totalCorrect / (totalCorrect + totalWrong);
            Console.WriteLine($"Your score percentage is {percentage}%");

            int totalSeconds = (int)(watch.ElapsedMilliseconds / 1000);
            // (int)(...) = casten
            int seconds = totalSeconds % 60;
            int minutes = totalSeconds / 60;

            Console.WriteLine($"It took you {minutes}m {seconds}s");

        }
    }
}
