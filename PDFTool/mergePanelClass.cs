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
        int que;
        CheckBox checkBoxVar;


        /***********************************************/
        // CONSTRUCTOR: mergePanelClass()
        // DESCRIPTION: constructor for the class if there isn't any parameters
        /***********************************************/
        public mergePanelClass()
        {

        }

        /***********************************************/
        // CONSTRUCTOR: mergePanelClass()
        // DESCRIPTION: Constructor for the class if there is some parameters when initializing the object
        // Saves all the relevant information from a single PDF-Icon to the mergePanelClass object so that 
        // it can be reference when mergeing the files
        /***********************************************/
        public mergePanelClass(Panel panelInput, string fileLocInput, int linkNumInput, CheckBox checkBoxInput)
        {
            panelVar = panelInput;
            fileLocation = fileLocInput;
            fileName = Path.GetFileName(fileLocInput);
            linkNum = linkNumInput;
            checkBoxVar = checkBoxInput;

        }

        /***********************************************/
        // FUNCTION: CheckBox getCheckBox()
        // DESCRIPTION: Get-function that returns the "CheckBox" controller of the PDF-Icon
        // EXAMPLE: RETURNS = "CheckBox" <--A CheckBox Controller
        /***********************************************/
        public CheckBox getCheckBox()
        {
            return checkBoxVar;
        }

        /***********************************************/
        // FUNCTION: void setPlacement()
        // DESCRIPTION: Set-function that saves the current que of the PDF documents.
        // This is used to determine the position in the order of the merge documents.
        /***********************************************/
        public void setQue(int queInput)
        {
            que = queInput;
        }

        /***********************************************/
        // FUNCTION: int getPlacement()
        // DESCRIPTION: Get-function that returns the que number of the PDF document
        // EXAMPLE: RETURNS = '4' <-- 4th document in the merged PDF document.
        /***********************************************/
        public int getQue()
        {
            return que;
        }

        /***********************************************/
        // FUNCTION: void getPanel()
        // DESCRIPTION: Get-function that returns Panel controller on the right hand side of the program 
        // EXAMPLE: RETURNS = "Panel" <--a Panel controller
        /***********************************************/
        public Panel getPanel()
        {
            return panelVar;
        }

        /***********************************************/
        // FUNCTION: int getLinkNum()
        // DESCRIPTION: Get-function that returns Panel controller on the right hand side of the program 
        // EXAMPLE: RETURNS = "Panel" <--a Panel controller
        /***********************************************/
        public int getLinkNum()
        {
            return linkNum;
        }

        /***********************************************/
        // FUNCTION: string getfileName()
        // DESCRIPTION: Get-function that returns the PDF file name
        // EXAMPLE: RETURNS = "someUserPDFdocument.pdf"
        /***********************************************/
        public string getfileName()
        {
            return fileName;
        }

        /***********************************************/
        // FUNCTION: string getfileLocation()
        // DESCRIPTION: Get-function that returns the PDF file location
        // EXAMPLE: RETURNS = "C:\\user\someUserName\Desktop\someUserPDFdocument.pdf"
        /***********************************************/
        public string getfileLocation()
        {
            return fileLocation;
        }
        
    }


}