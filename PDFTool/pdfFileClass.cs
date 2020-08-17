using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFTool
{

    //something
    
    class pdfFileClass
    {
        private string pdfLoction = "";

        /***********************************************/
        // CONSTRUCTOR: pdfFileClass()
        // DESCRIPTION: Constructs and intializses the object without parameters
        /***********************************************/
        public pdfFileClass()
        {

        }

        /***********************************************/
        // CONSTRUCTOR: pdfFileClass()
        // DESCRIPTION: Constructs and intializses the object with parameters, saving the pdf FileLocation
        /***********************************************/
        public pdfFileClass(string path)
        {
            pdfLoction = path;
        }

        /***********************************************/
        // FUNCTION: string getPDFLocation()
        // DESCRIPTION: Get-function that returns the PDF document file path
        // EXAMPLE: RETURNS = "C:\\user\someUserName\Desktop\someUserPDFdocument.pdf"
        /***********************************************/
        public string getPDFLocation()
        {
            return pdfLoction;
        }

        /***********************************************/
        // FUNCTION: void setPDFLocation()
        // DESCRIPTION: Set-function that saves the PDF document file path
        /***********************************************/
        public void setPDFLocation(string newPDFLocation)
        {
            pdfLoction = newPDFLocation;
        }

        /***********************************************/
        // FUNCTION: string getPDFname()
        // DESCRIPTION: Get-function that returns only the PDF document name
        // EXAMPLE: RETURNS = "someUserPDFdocument.pdf"
        /***********************************************/
        public string getPDFname()
        {

            string fileName = Path.GetFileName(getPDFLocation());
            return fileName;
        }
    }
}
