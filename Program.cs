using System;
using System.IO;

namespace Document_Merger
{
    class Program
    {
        static void Main(string[] args)
        {
            bool correct = false;
            string line;
            int count =0;
            string newMerge = "Yes";

            while (newMerge == "Yes")
            {
                Console.WriteLine("Document Merger\n\nPlease enter the name of the first text file: ");
                string text = Console.ReadLine();
                while (correct == false)
                {
                    if (File.Exists(text))
                    {
                        correct = true;
                    }
                    else
                    {
                        Console.WriteLine("That file does not exist! Please enter a new file: ");
                        text = Console.ReadLine();
                    }
                }
                correct = false;
                Console.WriteLine("Please enter the name of the second text file: ");
                string text2 = Console.ReadLine();
                while (correct == false)
                {
                    if (File.Exists(text2))
                    {
                        correct = true;
                    }
                    else
                    {
                        Console.WriteLine("That file does not exist! Please enter a new file: ");
                        text2 = Console.ReadLine();
                    }
                }
                Console.WriteLine("What would you like the new document to called: ");
                string newText = Console.ReadLine();
                try
                {
                    StreamReader file1 = new StreamReader(text);
                    StreamReader file2 = new StreamReader(text2);
                    StreamWriter file3 = File.AppendText(newText);
                    while ((line = file1.ReadLine()) != null)
                    {
                        file3.WriteLine(line);
                        count = count + line.Length;
                    }
                    while ((line = file2.ReadLine()) != null)
                    {
                        file3.WriteLine(line);
                        count = count + line.Length;
                    }
                    file1.Close();
                    file2.Close();
                    file3.Close();
                    Console.WriteLine("{0} was successfully saved. The document contains {1} characters.", newText, count);
                }
                catch (Exception ex)
                { 
                    Console.WriteLine(ex); 
                }
                Console.WriteLine("Would you like to merge two more documents? If so type 'Yes'");
                newMerge=Console.ReadLine();
            }
        }
    }
}