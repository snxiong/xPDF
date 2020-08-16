using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using System.IO;
using System.Windows.Forms;

namespace PDFTool
{
    class splitClass
    {

        private string fileToSplit;

        /***********************************************/
        // CONSTRUCTOR: splitClass()
        // DESCRIPTION: Saves the document that the user wants to split
        /***********************************************/
        public splitClass(string filepath)
        {
            fileToSplit = filepath;
        }

        /***********************************************/
        // FUNCTION: string getFileName()
        // DESCRIPTION: Get function that returns only the document name of the document path that will be split
        /***********************************************/
        public string getFileName()
        {
            return Path.GetFileName(fileToSplit);
        }

        /***********************************************/
        // FUNCTION: string splitRange()
        // DESCRIPTION: This function will split the pdf document between the page number indicated by "low" and "high"
        /***********************************************/
        public string splitRange(int low, int high)
        {
            // SaveFiledialog helps with opening a "Save As" window and asking the user for a location and a file name
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PDF (*.pdf)| *.pdf";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.ShowDialog(); // user selected location is now stored in saveFileDialog1.Filename


            if(saveFileDialog1.FileName != "")
            {
                FileInfo file = new FileInfo(saveFileDialog1.FileName);
                file.Directory.Create();

                PdfDocument firstPdf = new PdfDocument(new PdfReader(fileToSplit));

                PdfDocument pdf = new PdfDocument(new PdfWriter(saveFileDialog1.FileName));
                PdfMerger merger = new PdfMerger(pdf);

                
                // These statement checks to see if the user entered the page number in a invalid order
                if (high > firstPdf.GetNumberOfPages() && low <= 0)
                {  
                    firstPdf.Close();
                    return "3";
                }
                else if (low <= 0)
                {   
                    firstPdf.Close();
                    return "1";
                }
                else if (high > firstPdf.GetNumberOfPages())
                {  
                    firstPdf.Close();
                    return "2";
                }
                else if (low > high)
                {   
                    firstPdf.Close();
                    return "4";
                }

                // this is where the actual page splitting happens
                merger.Merge(firstPdf, low, high);

                pdf.Close();
                firstPdf.Close();
                return "0";

            }
          
            return "0";
        }
    }
}

