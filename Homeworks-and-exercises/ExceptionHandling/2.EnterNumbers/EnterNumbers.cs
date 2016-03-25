using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.EnterNumbers
{
    class EnterNumbers
    {
        static int ReadNumber(int start, int end)
        {
            //if (start >= end)
            //{
            //    throw new ArgumentException("The first argument must have smaller value than second argument");
            //}

            string input = Console.ReadLine();
            int number;

            if (int.TryParse(input, out number) == false)
            {
                throw new FormatException("Please, enter a valid integer number!");
            }

            if (number < start || number > end)
            {
                throw new ArgumentOutOfRangeException("The number must be in range [first argument . . . second argument]");
            }
            return number;
        }
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int currentNumber;

            for (int i = 0; i < 10; i++)
            {
                bool isInputIncorrect = true;
                while (isInputIncorrect)
                {
                    try
                    {
                        currentNumber = ReadNumber(1, 100);
                        if (i > 0 && currentNumber <= numbers[i - 1])
                        {
                            throw new Exception("The current number you enter must be bigger than previous one!");
                        }
                        numbers.Add(currentNumber);
                        isInputIncorrect = false;
                    }
                    catch (FormatException)
                    {
                        Console.Error.WriteLine("Please, enter a valid integer number!");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.Error.WriteLine("The number you entered must be in range [1 . . . 100]");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("The current number you enter must be bigger than previous one!");
                    }
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
