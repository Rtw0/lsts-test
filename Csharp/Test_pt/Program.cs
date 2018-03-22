using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Test_pt
{
    class Program
    {

        static void Evaluate() {

            var lines = File.ReadLines("arithmetic.txt"); // get all lines from file 
            DataTable dt = new DataTable();  //inicialize evaluation 

            Console.WriteLine(Environment.NewLine + "Excercise #2");

            foreach (var line in lines) //iterate through line in string
             {
                    var v = dt.Compute(line, "");  //Evaluate string using DataTable
                    Console.WriteLine(line + " = " + v);

             }
        }
        static void Text1(List<string> lines)
        {
            lines = lines.Distinct(StringComparer.CurrentCultureIgnoreCase).ToList(); //get unique words, filter set: case insensitive
            Console.WriteLine(Environment.NewLine +"Excercise #1_1");
            foreach (string word in lines) //iterate through line in string
            {
                Console.WriteLine(word);
            }
        }

        static void Text2(List<string> lines)
        {
            lines.Sort(); //default sort is ascending a,b,c,d....
            Console.WriteLine(Environment.NewLine + "Excercise #1_2");
            foreach (string word in lines) //iterate through line in string
            {
                Console.WriteLine(word);
            }
        }
        static void Text3(List<string> lines)
        {
            lines = lines.OrderBy(word => word.Length).ToList();  // order by length of word
            Console.WriteLine(Environment.NewLine + "Excercise #1_3");
            foreach (string word in lines) //iterate through line in string
            {
                Console.WriteLine(word);
            }
        }
        static void Text4(List<string> lines)
        {
            lines = lines.OrderBy(word => word).ToList(); // order by ascending alphabeticly
            Console.WriteLine(Environment.NewLine + "Excercise #1_4");

            var groups = lines.GroupBy(s => s[0]);  //group by 1st character in string

            foreach (var group in groups)
            {
                string fileName = group.Key.ToString().ToUpper() + ".txt"; //get Group name - Key is the First letter which we group by
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName))
                {
                    foreach (var word in group)
                    {
                        writer.WriteLine(word);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            var lines = File.ReadLines("words.txt");
            List<string> tempList = lines.ToList();
            Text1(tempList);//Excersise 1_1
            Text2(tempList);//Excersise 1_2
            Text3(tempList);//Excersise 1_3
            Text4(tempList);//Excersise 1_4
            Evaluate(); //Excersise 2
            Console.WriteLine("Press enter to close...");
            Console.ReadKey();
        }
    }
}
