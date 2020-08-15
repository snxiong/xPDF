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


        public splitClass(string filepath)
        {
            fileToSplit = filepath;
        }

        public string getFileName()
        {
            return Path.GetFileName(fileToSplit);
        }


        public string splitRange(int low, int high)
        {
            int versionpdf = 1;
            string version = "-v";
            bool editVersion = false;
            string newVersion;

            /*  NEED TO FIX THIS SHIT
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PDF (*.pdf)| *.pdf";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.ShowDialog(); // user selected location is now stored in saveFileDialog1.Filename


            if(saveFileDialog1.FileName != "")
            { 
            }
            */


            String result = fileToSplit.Replace(".pdf", "-Page" + low.ToString() + "to" + high.ToString() + ".pdf");

            while (File.Exists(result))
            {
                if (editVersion)
                {
                    string oldVersion = version + (versionpdf - 1).ToString();
                    newVersion = version + versionpdf.ToString();
                    result = result.Replace(oldVersion + ".pdf", newVersion + ".pdf");
                    versionpdf++;
                }
                else
                {
                    newVersion = version + versionpdf.ToString();
                    result = result.Replace(".pdf", newVersion + ".pdf");
                    versionpdf++;
                    editVersion = true;
                }

            }

            FileInfo file = new FileInfo(result);
            file.Directory.Create();

            PdfDocument firstPdf = new PdfDocument(new PdfReader(fileToSplit));

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

            PdfDocument pdf = new PdfDocument(new PdfWriter(result));
            PdfMerger merger = new PdfMerger(pdf);

            merger.Merge(firstPdf, low, high);


            // pdfs must be closed after they have been manuipulated or read from. 
            pdf.Close();
            firstPdf.Close();
            return result;
        }
    }
}
