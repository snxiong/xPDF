using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;


// CLASS DESCRIPTION: MergeClass.cs holds the code to merge the pdf documents sotred in megePanelArrayInput

namespace PDFTool
{
    class MergeClass
    {
        mergePanelClass[] mergePanelArray = new mergePanelClass[30];

        /***********************************************/
        // CONSTRUCTOR: MergeClass()
        // DESCRIPTION: constructs the mergeClass object and merges the document that is currently stored in the
        //              mergePanelClass array that is accpeted as a parameter
        /***********************************************/
        public MergeClass(mergePanelClass[] mergePanelArrayInput)
        {
            mergePanelArray = mergePanelArrayInput;
            mergePDFDoc();
        }


        /***********************************************/
        // FUNCTION: void mergePDFDoc()
        // DESCRIPTION: Does the actual mergeing of PDF documents, will prompt user where to save the merged document.
        /***********************************************/
        private void mergePDFDoc()
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PDF (*.pdf)| *.pdf";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.ShowDialog(); // user selected location is now stored in saveFileDialog1.Filename

            if (saveFileDialog1.FileName != "")
            {
                FileInfo file = new FileInfo(saveFileDialog1.FileName);
                file.Directory.Create();

                PdfDocument pdf = new PdfDocument(new PdfWriter(saveFileDialog1.FileName));

                PdfMerger merger = new PdfMerger(pdf);

                for (int i = 0; i <= 20; i++)
                {
                    if (mergePanelArray[i] != null)
                    {

                        PdfDocument pdfDoc = new PdfDocument(new PdfReader(mergePanelArray[i].getfileLocation()));
                        merger.Merge(pdfDoc, 1, pdfDoc.GetNumberOfPages());

                        pdfDoc.Close();
                    }
                    else if (mergePanelArray[i] == null)
                    {
                        i = 21;
                    }
                }


                pdf.Close();
                MessageBox.Show("Your documents have all been merged.");
            }

            
        }
    }
}
