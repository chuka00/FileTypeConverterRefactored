using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.IO;
using System.Text;
using FileTypeConverter;
using System.Xml.Linq;

namespace WriteToPdf
{
    public class CreatePdfFile
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



       /* public static void CreateFile(string textContent, string fileName)
        {

            using (var document = new Document())
            {
                PdfWriter.GetInstance(document, new FileStream("mydocument.pdf", FileMode.Create));
                document.Open();

                var font = FontFactory.GetFont(FontFactory.HELVETICA, 14);
                var paragraph = new Paragraph("Hello, this is my first PDF document!", font);
                document.Add(paragraph);

                document.Close();
            }*/


            /* // Create a new PDF document
             Document document = new Document();

             // Set the page size and margins
             document.SetPageSize(PageSize.A4);
             document.SetMargins(50, 50, 50, 50);

             // Create a new PdfWriter object
             PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));

             // Open the document for writing
             document.Open();

             // Create a new font and add it to the document
             Font font = new Font(Font.FontFamily.TIMES_ROMAN, 12, Font.NORMAL);
             document.Add(new Paragraph(textContent, font));

             // Close the document
             document.Close();*/
        
    


