using System;
using System.Collections.Generic;
using System.Linq;
namespace Chunks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "C# Chunks";
            Console.WriteLine("|> Example program on how to create chunks of an array in C#");
            Console.Write("|> Press any key to begin...");
            Console.ReadKey();
            Console.Clear();

            /*
             * ==================================================================================================================================
             *                                                      BUILDING THE ARRAY WITH A TOTAL OF 100 ITEMS
             * ==================================================================================================================================
             */

            List<string> idList = new List<string>();    
            
            for (int i = 0; i < 100; i++)
                idList.Add(i.ToString());

            // The actual array we are going to use later on
            string[] idArray = idList.ToArray();

            /*
             * ==================================================================================================================================
             *                                  SPLITTING THE ARRAY INTO CHUNKS WITH A SIZE OF 10 ITEMS PER CHUNK
             * ==================================================================================================================================
             */

            String[][] chunks = idArray
                                .Select((s, i) => new { Value = s, Index = i })
                                .GroupBy(x => x.Index / 10) // Change the 10 to any number to define how many items you want per chunk
                                .Select(grp => grp.Select(x => x.Value).ToArray())
                                .ToArray();

            /*
             * ==================================================================================================================================
             *                                           PRINTING THE CHUNKS WITH THE COUNT OF THEIR ITEMS
             * ==================================================================================================================================
             */

            PrintLog("Chunks have been generated!");
            for (int i = 0; i < chunks.Length; i++)
                Console.WriteLine("Chunk #{0} with {1} items", i, chunks[i].Length);

            /*
             * ==================================================================================================================================
             *                                           SELECTING A RANDOM CHUNK AND PRINTING IT'S ITEMS
             * ==================================================================================================================================
             */

            PrintLog("\nSelecting a random chunk and printing it's items");

            int randomChunk = new Random().Next(0, chunks.Length);
            Console.WriteLine("Items from Chunk #{0}:", randomChunk);

            foreach (var item in chunks[randomChunk])
            {
                Console.WriteLine("Item: {0}", item);
            }

            /*
             * ==================================================================================================================================
             *                                                              END
             * ==================================================================================================================================
             */

            Console.Write("\nPress any key to exit...");
            Console.ReadKey();
            Environment.Exit(Environment.ExitCode);
        }

        private static void PrintLog(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(input);

            //Printing a line as long as the input
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
