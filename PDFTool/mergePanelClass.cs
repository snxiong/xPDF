using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.IO;
using iText;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using iText.Layout.Element;
namespace PDFTool
{
   


    class mergePanelClass
    {
        Panel panelVar;
        string fileLocation;
        string fileName;
        int linkNum;

        mergePanelClass()
        {

        }

        public mergePanelClass(Panel panelInput, string fileLocInput, int linkNumInput)
        {
            panelVar = panelInput;
            fileLocation = fileLocInput;
            fileName = Path.GetFileName(fileLocInput);
            linkNum = linkNumInput;
        }

        public Panel getPanel()
        {
            return panelVar;
        }

        public int getLinkNum()
        {
            return linkNum;
        }

     
    }


}
