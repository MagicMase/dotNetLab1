using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> words = new List<string>();
            bool running = true;
            string option;
            while (running)
            {
                System.Console.Write("1 - Import Words From File\n" +
                    "2 - Bubble Sort words\n" +
                    "3 - LINQ/Lambda sort words\n" +
                    "4 - Count the Distinct Words\n" +
                    "5 - Take the first 10 words\n" +
                    "6 - Get the number of words that start with 'j' and display the count\n" +
                    "7 - Get and display of words that end with 'd' and display the count\n" +
                    "8 - Get and display of words that are greater than 4 characters long, and display the count\n" +
                    "9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count\n" +
                    "x - Exit\n\n" +
                    "Make a selection: ");
                option = Console.ReadLine();
                Console.WriteLine("\n");
                Console.Clear();

                switch (option)
                {
                    case "1":
                        importWords(words);
                        break;
                    case "2":
                        BubbleSort(words);
                        break;
                    case "3":
                        lambdaSort(words);
                        break;
                    case "4":
                        distinctWords(words);
                        break;
                    case "5":
                        firstTenWords(words);
                        break;
                    case "6":
                        wordsStartWithJ(words);
                        break;
                    case "7":
                        wordsEndWithD(words);
                        break;
                    case "8":
                        wordsGreaterThanFour(words);
                        break;
                    case "9":
                        wordsLessThanThree(words);
                        break;
                    case "x":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input\n\n"); break;
                } //end of switch
            }//end of while

        } //end of main

        public static void importWords(IList<string> words)
        {
            try
            {
                using (StreamReader sr = new StreamReader("Words.txt"))
                {
                    string line;
                    Console.WriteLine("Reading words");
                    while((line =sr.ReadLine()) != null)
                    {
                        words.Add(line);
                    }
                    Console.WriteLine(words.Count() + " words have been imported\n");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("The file could not be read");//error with file message
                Console.WriteLine(e.Message);
            }

        }

        public static IList<string> BubbleSort(IList<string> words)
        {
            string[] temp = words.ToArray();
            bool wasSwapped = true;
            Stopwatch timer = new Stopwatch();
            timer.Start();

            for(int i=0; i<words.Count()-1 && wasSwapped; i++)
            {
                wasSwapped = false;
                for(int j=0; j<words.Count() - i - 1; j++)
                {
                    if (string.Compare(temp[j], temp[j + 1]) >= 0) // compare j and i if (j>i)->swap
                    {
                        string tempString = temp[j];
                        temp[j] = temp[j + 1]; //j index is now equal to i
                        temp[j + 1] = tempString; //inedex is now equal to j
                        wasSwapped = true;
                    }
                }
            }
            timer.Stop();
            TimeSpan ts = timer.Elapsed;
            Console.WriteLine("Time elapsed: " + ts.Milliseconds + "ms\n\n");
            return temp;
        }

        public static void lambdaSort(IList<string> words)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();


            var _Results = from elements in words
                           orderby elements.ToString()//sorts the words in acending order
                           select elements;

            timer.Stop();
            TimeSpan ts = timer.Elapsed;
            Console.WriteLine("Time elapsed: " + ts.Milliseconds + "ms\n\n");
        }

        public static void distinctWords(IList<string> words)
        {
            var _Results = (from elements in words
                            select elements).Distinct().Count(); 
            Console.WriteLine("There are: "+_Results+" distince words \n\n");
         }


        public static void firstTenWords(IList<string> words)
        {
            var _Results = (from elements in words
                            select elements).Take(10);

            foreach (string value in _Results) 
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();
        }

        public static void wordsStartWithJ(IList<string> words)
        {
            var _Results = (from elements in words
                            where elements.StartsWith("j")
                            select elements).Count();

            Console.WriteLine("There are: " + _Results + " words that start with the letter 'j'");

        }

        public static void wordsEndWithD(IList<string> words)
        {
            var _Results = (from elements in words
                            where elements.EndsWith("d")
                            select elements);

            foreach (string value in _Results)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("There are: " + _Results.Count() + " words that end with the letter 'd'");

        }

        public static void wordsGreaterThanFour(IList<string> words)
        {
            var _Results = (from elements in words
                            where elements.Length > 4
                            select elements);

            foreach(string value in _Results)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("There are: " + _Results.Count() + " words that have a length greater than 4");
        }

        public static void wordsLessThanThree(IList<string> words)
        {
            var _Results = (from elements in words
                            where elements.Length < 3 && elements.StartsWith("a")
                            select elements);

            foreach (string value in _Results)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("There are: " + _Results.Count() + " words that are less than 3 chars and start with the letter 'a'");
        }




    } //end of class
} // end of nsamespace
