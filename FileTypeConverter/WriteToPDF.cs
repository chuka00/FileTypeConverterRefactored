using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileTypeConverter
{
    public class WriteToPDF
    {
        public static void CreateAndReadPDF()
        {

            Console.Clear();

            // Utility.PrintColorMessage(ConsoleColor.Cyan, "************ Welcome to the In-House Code Documentation Tool(PDF)********\n\n");


            string documentation = Operations.GetDocs();

            //create a pdf file and write to it

            using (FileStream fs = new FileStream("Besters.pdf", FileMode.Create))
            {
                using (Document doc = new Document())
                {
                    using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                    {
                        doc.Open();

                        doc.Add(new Paragraph(documentation));

                        doc.Close();


                    }
                }

            }




            //read from pdf to the console

            using (PdfReader reader = new PdfReader("Besters.pdf"))
            {
                StringBuilder text = new StringBuilder();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
                Console.WriteLine(text.ToString());
            }


        }

    }
}

