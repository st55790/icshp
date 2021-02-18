using System;

namespace Ex04
{
    class Program
    {
        static void Main(string[] args)
        {
            GuessNumber();
        }

        public static void GuessNumber() {
            bool repeat = false;
            do
            {
                Random rnd = new Random();
                int rndNumber = rnd.Next(0, 100);
                int myNumber = -1;
                int counter = 0;
                Console.WriteLine(rndNumber);

                Console.WriteLine("Hádej číslo od 1-100");
                do
                {
                    if (counter == 10) {
                        Console.WriteLine("Počet pokusů byl vyčerpán!");
                        break;
                    }
                    Console.Write("Zadej číslo: ");
                    string userInput = Console.ReadLine();
                    myNumber = int.Parse(userInput.ToString());

                    if (myNumber == rndNumber)
                    {
                        Console.WriteLine("Výborně, úhadl si číslo! Bylo to opravdu " + myNumber);
                    }
                    else if (myNumber < rndNumber)
                    {
                        Console.WriteLine("Zkus o něco větší");
                    }
                    else {
                        Console.WriteLine("Zkus o něco měnší");
                    }
                    counter++;

                } while (rndNumber != myNumber);

                repeat = false;
                Console.WriteLine("Chceš hrát znovu? y/n: ");
                string again = Console.ReadLine();

                if (again == "y")
                {
                    repeat = true;
                }

            } while (repeat);
        }
    }
}
