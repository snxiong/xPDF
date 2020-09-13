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
        Button upButtonVar;
        Button downButtonVar;


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

        public void setButtonUp(Button buttonUpInput)
        {
            upButtonVar = buttonUpInput;
        }

        public void setButtonDown(Button buttonDownInput)
        {
            downButtonVar = buttonDownInput;
        }

        public Button getButtonUp()
        {
            return upButtonVar;
        }

        public Button getButtonDown()
        {
            return downButtonVar;
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

        public void setLink(int linkNumInput)
        {
            linkNum = linkNumInput;
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

        /*
        private void createMergeControllers(object sender)
        {
            CheckBox checkBoxVar = sender as CheckBox;

            //textBox1.Text = "Check box check " + checkBoxVar.Name;
            int textBoxNum = Int32.Parse(checkBoxVar.Name.Substring(8, 1));  // get the checkbox number

            //=====================================
            //=========CREATES NEW PANEL===========
            //=====================================

            Panel panelVar = new Panel();
            panelVar.Size = new System.Drawing.Size(244, 37);

            //=====================================
            //=========CREATES NEW BUTTON==========
            //=====================================

            Button buttonVarUp = new Button();
            buttonVarUp.Image = global::PDFTool.Properties.Resources.smalluparrow;
            //buttonVarUp.Name = textBoxNum.ToString();
            buttonVarUp.Size = new System.Drawing.Size(22, 22);
            buttonVarUp.Location = new Point(200, 7);
            buttonVarUp.Click += new System.EventHandler(this.up_Function);
            buttonVarUp.BackColor = System.Drawing.Color.White;

            //=====================================
            //=========CREATES NEW BUTTON========== // original form 292
            //=====================================

            Button buttonVarDown = new Button();
            buttonVarDown.Image = global::PDFTool.Properties.Resources.smalldownarrow;
            //buttonVarDown.Name = textBoxNum.ToString();
            buttonVarDown.Size = new System.Drawing.Size(22, 22);
            buttonVarDown.Location = new Point(225, 7);
            buttonVarDown.Click += new System.EventHandler(this.down_Function);
            buttonVarDown.BackColor = System.Drawing.Color.White;

            //=====================================
            //========CREATES NEW TEXTBOX==========
            //=====================================

            //textboxVar.Name = mergeTextBoxName;
            //textboxVar.Text = pdfObjArray[textBoxNum].getPDFname();
            TextBox textboxVar = new TextBox();
            textboxVar.Text = pdfIconArray[textBoxNum].getPDFfileName();

            textboxVar.Size = new System.Drawing.Size(190, 20);
            textboxVar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textboxVar.Location = new Point(0, 7);

            //====================================
            //========CREATES NEW TEXTBOX=========
            //=====================================
            TextBox textboxVar2 = new TextBox();
            textboxVar2.Text = textBoxNum.ToString();
            textboxVar2.Visible = false;

            // Adds all newly created controllers to the panel
            panelVar.Controls.Add(textboxVar2);
            panelVar.Controls.Add(textboxVar);
            panelVar.Controls.Add(buttonVarUp);
            panelVar.Controls.Add(buttonVarDown);

            mergePanelClass mergePanelObj = null;

            // textBoxNum is bugging the program

            int x = 0;
            for (int i = 0; i <= 30; i++)
            {
                if (textBoxNum == pdfIconArray[i].getID())
                {
                    mergePanelObj = new mergePanelClass(panelVar, pdfIconArray[i].getPDFfilePath(), textBoxNum, pdfIconArray[i].getCheckBox());
                    i = 31;
                }
            }

            for (int i = 0; i <= 30; i++)
            {
                if (mergePanelArray[i] == null)
                {
                    mergePanelObj.setQue(i); // setPlacement
                    mergePanelArray[i] = mergePanelObj;
                    i = 31;
                }
                else
                {
                    //WE NEED TO DO SOMETHING HERE
                }
            }

            tableLayoutPanel2.Controls.Add(mergePanelObj.getPanel());
        }
        */

    }


}