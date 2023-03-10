using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileTypeConverter
{
    public class WriteToText
    {
        public static void CreateAndWrite()
        {

            string documentation = Operations.GetDocs();


            using (StreamWriter writer = new StreamWriter("document.txt"))
            {
                writer.Write(documentation);
            }

            // Now read data from file to console

            using (StreamReader sr = File.OpenText("document.txt"))
            {
                string input = null;

                while ((input = sr.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
            }
        }
    }
}
