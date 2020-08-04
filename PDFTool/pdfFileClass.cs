using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFTool
{
    

    class pdfFileClass
    {
        private string pdfLoction = "";

        public pdfFileClass()
        {

        }

        public pdfFileClass(string path)
        {
            pdfLoction = path;
        }

        public string getPDFLocation()
        {
            return pdfLoction;
        }

        public  void setPDFLocation(string newPDFLocation)
        {
            pdfLoction = newPDFLocation;
        }


        public string getPDFname()
        {

            string fileName = Path.GetFileName(getPDFLocation());



            return fileName;
        }
    }
}
