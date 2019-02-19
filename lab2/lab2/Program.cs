using System;
using System.Net.Mime;
using System.Numerics;
using System.Text;
using System.Threading;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hello! ");
            Console.Write("Enter your name, bro: ");
            String name = Console.ReadLine();
            Console.Write("Good day, " + name + "!\n");
            
            Random rand = new Random();
            int a = rand.Next(51);
            Console.WriteLine("I thought random integer between 0 and 50. Try to guess :)");
            
            int effortCounter = 0;
            StringBuilder history = new StringBuilder("");
            string[] phrases = {"Good job! Continue", "Do your best", "Cheer up", "You're on the right track", "O'K, try again"};

            int integer = 0;
            DateTime start = DateTime.Now;

                do
                {
                    String answer = Console.ReadLine();
                    
                    if (answer == "q")
                    {
                        Console.WriteLine("Sorry, bye!");
                        System.Environment.Exit(1);
                    }
                    
                    if (Int32.TryParse(answer, out integer))
                    {
                        if (integer < a)
                        {
                            history.Append(answer).Append(" less\n");
                            Console.WriteLine("Try to guess something bigger");
                        }
                        else if (integer > a)
                        {
                            history.Append(answer).Append(" bigger\n");
                            Console.WriteLine("Try to guess something less");
                        }
                        effortCounter++;
                        if (effortCounter%4 == 0)
                        {
                            int phraseIndex = rand.Next(phrases.Length);
                            Console.WriteLine(name + ", " + phrases[phraseIndex] + "!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Write a number please");
                    }  
                }  while (integer != a);
                
                DateTime end = DateTime.Now;
                TimeSpan interval = end - start;
                string outputTime = "Your time result: " + interval.ToString(@"mm\:ss");
                Console.WriteLine("success!\n");
                Console.WriteLine("Efforts: " + effortCounter);
                Console.WriteLine("History: " + history);
                Console.WriteLine(outputTime);
        }
    }
}