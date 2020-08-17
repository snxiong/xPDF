using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using iText;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PDFTool
{
    class deleteClass
    {
        private string pdfDocument;
        private int errorCode = 0;
        private int[] pagesToDelete;
        
        public deleteClass(string pdfInput)
        {
            pdfDocument = pdfInput;
        }

        public bool getPagesToDel(string pagesToDelString)
        {   // accepts a paremeter of a string of numbers, ex " 1,2,4,6,7"
            // will convert it into an array of int and place it in 'pagesToDelete'

            string regextextBox3 = "^(\\d+(,\\d+)*)?$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(pagesToDelString, regextextBox3))
            {
                return false;
            }
            pagesToDelete = Array.ConvertAll(pagesToDelString.Split(','), int.Parse);
            Array.Sort(pagesToDelete); // sort the pages to delete array from loweset to highest
            return true;

        }

        public string deletePage()
        {
            // SaveFiledialog helps with opening a "Save As" window and asking the user for a location and a file name
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PDF (*.pdf)| *.pdf";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.ShowDialog(); // user selected location is now stored in saveFileDialog1.Filename

            FileInfo file = new FileInfo(pdfDocument);
            file.Directory.Create();

            PdfDocument pdf = new PdfDocument(new PdfWriter(saveFileDialog1.FileName)); // saves a new pdf filescalled xxxsave.pdf

            PdfMerger merger = new PdfMerger(pdf);

            PdfReader reader = new PdfReader(file);
            PdfWriter writer = pdf.GetWriter();
            PdfDocument document = new PdfDocument(reader, writer);

            int numOfPages = document.GetNumberOfPages();

            if(numOfPages == 1)
            {   // The document the user wants to delete from only has 1 page in it.
                document.Close();
                File.Delete(saveFileDialog1.FileName);
                return "1";
            }

            var PTDList = new List<int>(pagesToDelete);
            PTDList = PTDList.Distinct().ToList();

            if(numOfPages < PTDList.Max())
            {   // user entered a page number that is larger then the last page of the PDF Documents
                document.Close();
                File.Delete(saveFileDialog1.FileName);
                return "2";
            }

            if(PTDList.Min() == 0)
            {   // user is trying to delete pages 0, which is impossible
                document.Close();
                File.Delete(saveFileDialog1.FileName);
                return "3";
            }

            pagesToDelete = PTDList.ToArray();

            if(!checkIfOnePage(document.GetNumberOfPages()))
            {
                document.RemovePage(pagesToDelete[pagesToDelete.Length - 1]);
            }
            else
            {
                document.Close();
                return "5";
            }

            for(int i = pagesToDelete.Length - 1; i > 0; i--)
            {
                if((i - 1) == 0)
                {
                    document.RemovePage(pagesToDelete[0]);
                }
                else if(!checkIfOnePage(document.GetNumberOfPages()))
                {
                    document.RemovePage(pagesToDelete[i - 1]);
                }
                else
                {   // user document only has 1 page, so we cannot delete any more pages from it
                    document.Close();
                    return "4";
                }
            }

            document.Close();
            return saveFileDialog1.FileName;

        }

        bool checkIfOnePage(int num)
        {
            if(num == 1)
            {
                return true;
            }

            return false;
        }

        public int sizeOfArray()
        {
            return pagesToDelete.Length;
        }

        public string printDelPages()
        {
            string pagestoDel = "";

            for (int i = 0; i < pagesToDelete.Length; i++)
            {
                pagestoDel += pagesToDelete[i].ToString() + ", ";
            }

            return pagestoDel;
        }

    }
}
