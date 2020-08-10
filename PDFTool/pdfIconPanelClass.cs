using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFTool
{
    class pdfIconPanelClass
    {
        pdfFileClass pdfObj;
        Panel panelObj;
        int NumID; // used for identification
        CheckBox checkBoxVar;

        public pdfIconPanelClass()
        {

        }

        public pdfIconPanelClass(pdfFileClass inputPDFObj, Panel inputPanelObj)
        {
            pdfObj = inputPDFObj;
            panelObj = inputPanelObj;
        }

        public void setCheckBox(CheckBox checkBoxInput)
        {
            checkBoxVar = checkBoxInput;
        }

        public CheckBox getCheckBox()
        {
            return checkBoxVar;
        }

        public void setID(int inputID)
        {
            NumID = inputID; 
        }

        public void setPDF(pdfFileClass inputPDF)
        {
            pdfObj = inputPDF;
        }

        public void setPanel(Panel inputPanel)
        {
            panelObj = inputPanel;
        }

        public int getID()
        {
            return NumID;
        }
        public string getPDFfileName()
        {
            return pdfObj.getPDFname();
        }

        public string getPDFfilePath()
        {
            return pdfObj.getPDFLocation();
        }

        public Panel getPanel()
        {
            return panelObj;
        }

    }
}
