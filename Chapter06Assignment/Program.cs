using System;
using System.Numerics;

namespace Chapter06AssignmentPart1
{
    class Program
    {
        static void Main(string[] args)
        {
            //question 1
            Random rand = new Random();

            int totalNumbers = 1000;
            int oddCount = 0;
            int smallest = int.MaxValue;
            int largest = int.MinValue;

            Console.WriteLine("\nRandomNumber Example");

            for (int i = 0; i < totalNumbers; i++)
            {
                int num = rand.Next(0, 100001);

                if (num % 2 != 0)
                {
                    oddCount++;
                }

                if (num < smallest)
                {
                    smallest = num;
                }

                if (num > largest)
                {
                    largest = num;
                }
            }
            Console.WriteLine($"\nOdd Values Count: {oddCount}" +
            $"\nSmallest: {smallest}" +
            $"\nLargest: {largest}");




            //question 2
            int validCount = 0;
            int invalidCount = 0;


            Console.WriteLine("\nInput Validation Example");
            Console.WriteLine("Enter a number 1-100; type quit to exit: ");

            while (true)
            {
                Console.Write("Enter input: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                // Cleans input; had to look
                // this up because for some reason it was constantly looping
                string cleanInput = input.Trim().ToLower();

                if (cleanInput == "quit")
                {
                    break;
                }

                if (int.TryParse(cleanInput, out int value) && value > 0 && value < 100)
                {
                    validCount++;
                    Console.WriteLine("Valid entry");
                }
                else
                {
                    invalidCount++;
                    Console.WriteLine("Invalid entry");
                }
            }
            Console.WriteLine($"\nValid Entries: {validCount}" +
                $"\nInvalid Entries: {invalidCount}");



            //question 3
            double totalScore = 0;
            int scoreCount = 0;
            const int Sentinel = -1;

            Console.WriteLine("\nGrading Example");
            Console.WriteLine("\nEnter scores between 0 and 100. Enter -1 when finished.\n");

            while (true)
            {
                Console.Write("Enter score (-1 to exit): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int score) && score == Sentinel)
                {
                    break;
                }

                if (double.TryParse(input, out double validScore) && validScore >= 0 && validScore <= 100)
                {
                    totalScore += validScore;
                    scoreCount++;
                }
                else
                {
                    Console.WriteLine("Invalid entry. Please enter a score between 0 and 100.");
                }
            }

            if (scoreCount > 0)
            {
                double average = totalScore / scoreCount;
                char letterGrade;

                if (average >= 90) letterGrade = 'A';
                else if (average >= 80) letterGrade = 'B';
                else if (average >= 70) letterGrade = 'C';
                else if (average >= 60) letterGrade = 'D';
                else letterGrade = 'F';

                Console.WriteLine("$\nResult" +
                    $"\nTotal Scores: {totalNumbers}" +
                    $"\nAverage Score: {average}" +
                    $"\nRecorded Grade: {letterGrade}");
            }
            else
            {
                Console.WriteLine("\nNo valid scores were entered.");
            }


            //question 4
            Console.WriteLine("\nMultiplication Table Example");

            Console.Write("\nEnter starting base value 2-8: ");
            if (!int.TryParse(Console.ReadLine(), out int startBase) || startBase < 2 || startBase > 8)
            {
                Console.WriteLine("Error: starting base value must be a number between 2 and 8.");
                return;
            }

            Console.Write("\nEnter ending base value 2-8: ");
            if (!int.TryParse(Console.ReadLine(), out int endBase) || endBase < 2 || endBase > 8)
            {
                Console.WriteLine("Error: ending base value must be a number between 2 and 8.");
                return;
            }

            if (startBase > endBase)
            {
                Console.WriteLine("Error: Starting base value cannot be greater than ending base value.");
                return;
            }

            Console.WriteLine();

            // Header
            Console.Write($"{"Multiplier",-12}|");
            for (int baseVal = startBase; baseVal <= endBase; baseVal++)
            {
                Console.Write($"{$"Base {baseVal}",10}");
            }
            Console.WriteLine();

            // 25 Rows of Computations
            for (int row = 1; row <= 25; row++)
            {
                Console.Write($"{$"{row} x",-12}|");
                for (int baseVal = startBase; baseVal <= endBase; baseVal++)
                {
                    Console.Write($"{(row * baseVal),10}");
                }
                Console.WriteLine();
            }

            Console.WriteLine();





            //question 5
            Console.WriteLine("\nJuggling Example");
            Console.WriteLine("\nEnter a positive integer between 1 and 50: ");

            if (!int.TryParse(Console.ReadLine(), out int jugglingInput) || jugglingInput < 1 || jugglingInput > 50)
            {
                Console.WriteLine("Error: Please enter a valid integer between 1 and 50.");
                return;
            }

            BigInteger current = jugglingInput;
            BigInteger maxVal = current;
            int steps = 0;

            Console.WriteLine($"\nSequence: " + current);

            while (current != 1)
            {
                if (current % 2 == 0)
                {
                    current = BigIntegerSqrt(current);
                }
                else
                {
                    BigInteger cubed = current * current * current;
                    current = BigIntegerSqrt(cubed);
                }

                if (current > maxVal)
                {
                    maxVal = current;
                }

                steps++;
                Console.WriteLine(current);
            }
            Console.WriteLine($"\nStarting Value: {jugglingInput}" +
                $"\nMax Value: {maxVal}" +
                $"\nSteps Required: {steps}");
        }




        //had to look up how to properly initialize this method
        static BigInteger BigIntegerSqrt(BigInteger value)
        {
            if (value == 0) return 0;
            if (value <= 3) return 1;

            BigInteger root = (BigInteger)Math.Sqrt((double)value);
            BigInteger lowerBound = root - 1;
            BigInteger upperBound = root + 1;

            while (lowerBound * lowerBound <= value)
            {
                root = lowerBound;
                lowerBound++;
            }

            return root;

        }
    }
}

    

