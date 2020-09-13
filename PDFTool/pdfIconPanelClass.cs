using System.Windows.Forms;

namespace PDFTool
{
    class pdfIconPanelClass
    {
        pdfFileClass pdfObj;
        Panel panelObj;
        int NumID; // used for identification
        CheckBox checkBoxVar;
        PictureBox pictureBoxVar;
        Button buttonVar;

        /***********************************************/
        // CONSTRUCTOR: pdfIconPanelClass()
        // DESCRIPTION: Constructs and intializses the object if the class is initizalises without parameters
        /***********************************************/
        public pdfIconPanelClass()
        {

        }

        /***********************************************/
        // CONSTRUCTOR: pdfIconPanelClass()
        // DESCRIPTION: Constructs and intializses the object  if the class is initizalises with parameters
        /***********************************************/
        public pdfIconPanelClass(pdfFileClass inputPDFObj, Panel inputPanelObj)
        {
            pdfObj = inputPDFObj;
            panelObj = inputPanelObj;
        }

        /***********************************************/
        // FUNCTION: void setCheckBox()
        // DESCRIPTION: Set-function to save the check box controller
        /***********************************************/
        public void setCheckBox(CheckBox checkBoxInput)
        {
            checkBoxVar = checkBoxInput;
        }

        /***********************************************/
        // FUNCTION: void setPictureBox()
        // DESCRIPTION: Set-function to save the picture box controller
        /***********************************************/
        public void setPictureBox(PictureBox pictureBoxInput)
        {
            pictureBoxVar = pictureBoxInput;
        }

        /***********************************************/
        // FUNCTION: void setButton()
        // DESCRIPTION: Set-function to save the button controller
        /***********************************************/
        public void setButton(Button buttonInput)
        {
            buttonVar = buttonInput;
        }

        /***********************************************/
        // FUNCTION: void getButton()
        // DESCRIPTION: Set-function to save the button controller
        /***********************************************/
        public Button getButton()
        {
            return buttonVar;
        }


        /***********************************************/
        // FUNCTION: void getPicturebox()
        // DESCRIPTION: Get-function to return the saved picture box controller
        /***********************************************/
        public PictureBox getPicturebox()
        {
            return pictureBoxVar;
        }

        /***********************************************/
        // FUNCTION: void getCheckBox()
        // DESCRIPTION: Get-function to return the saved check box controller
        /***********************************************/
        public CheckBox getCheckBox()
        {
            return checkBoxVar;
        }

        /***********************************************/
        // FUNCTION: void setID()
        // DESCRIPTION: Set-function to save the ID Number of the PDF-Icon so the program can more easily tell them apart
        /***********************************************/
        public void setID(int inputID)
        {
            NumID = inputID; 
        }

        /***********************************************/
        // FUNCTION: void getID()
        // DESCRIPTION: Get-function that returns the ID of the PDF-Icon
        /***********************************************/
        public int getID()
        {
            return NumID;
        }

        /***********************************************/
        // FUNCTION: void setPDF()
        // DESCRIPTION: Set-function to save the "pdfFileClass" object that holds all the information regarding the PDF Document
        /***********************************************/
        public void setPDF(pdfFileClass inputPDF)
        {
            pdfObj = inputPDF;
        }

        /***********************************************/
        // FUNCTION: string getPDFfileName()
        // DESCRIPTION: Get-function that uses the built-in function in "pdfFileClass" and returns only the PDF document name
        // EXAMPLE: RETURNS = "someUserPDFdocument.pdf"
        /***********************************************/
        public string getPDFfileName()
        {
            if(pdfObj.getPDFname() == "")
            {
                return null;
            }

            return pdfObj.getPDFname();
        }

        /***********************************************/
        // FUNCTION: string getPDFfilePath()
        // DESCRIPTION: Get-function that uses the built-in function in "pdfFileClass" and returns the PDF document file path
        // EXAMPLE: RETURNS = "C:\\user\someUserName\Desktop\someUserPDFdocument.pdf"
        /***********************************************/
        public string getPDFfilePath()
        {
            return pdfObj.getPDFLocation();
        }



        /***********************************************/
        // FUNCTION: void setPanel()
        // DESCRIPTION: Set-function that saves the Panel controller for the PDF Icon
        /***********************************************/
        public void setPanel(Panel inputPanel)
        {
            panelObj = inputPanel;
        }

        /***********************************************/
        // FUNCTION: Panel getPanel()
        // DESCRIPTION: Get-function that returns the Panel controller
        /***********************************************/
        public Panel getPanel()
        {
            return panelObj;
        }

        public pdfFileClass getPDFobj()
        {
            return pdfObj;
        }

        

        

        

    }
}
