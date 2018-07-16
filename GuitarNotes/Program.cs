using System;
using System.IO;
using System.Text;

namespace GuitarNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            string line; string[] splits;
            string guitarString, fret;
            StringBuilder[] guitarStrings = new StringBuilder[6];
            for(int i = 0; i < guitarStrings.Length; i++)
            {
                guitarStrings[i] = new StringBuilder("[");
            }
            using (StreamReader sr = new StreamReader("SampleFile.txt"))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        splits = line.Split(' ');
                        guitarString = splits[0];
                        fret = splits[1];

                        AddToOutput(guitarString, fret, guitarStrings);
                    }
                }
            }
            for(int i = 0; i < guitarStrings.Length; i++)
            {
                guitarStrings[i].Append("]");
                Console.WriteLine(guitarStrings[i]);
            }
            Console.ReadKey();
        }

         static void AddToOutput(string guitarString, string fret, StringBuilder[] guitarStrings)
        {
            int stringIndexer;
            if (int.TryParse(guitarString, out stringIndexer))
            {
                for (int i = 0; i < 6; i++)
                {
                    if (i != stringIndexer - 1)
                    {
                        guitarStrings[i].Append("---");
                    }
                    else
                    {
                        guitarStrings[stringIndexer - 1].Append(FormatOutput(fret));
                    }
                }
            }
        }

        static string FormatOutput(string fret)
        {
            if (fret.Length > 1)
            {
                fret = "-" + fret;
            }
            else
            {
                fret = "-" + fret + "-";
            }
            return fret;
        }
    }
}
