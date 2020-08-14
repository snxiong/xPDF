using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFTool
{
    class splitPanelController
    {
        TextBox splitTextbox1;
        TextBox splitTextBox2;
        TextBox splitTextBox3;
        Button splitButton;
        Label splitLabel1;
        Label splitLabel2;
        Label splitLabel3;

        /***********************************************/
        // CONSTRUCTOR: splitPanelController()
        // DESCRIPTION: Constructs and intializses the object
        /***********************************************/
        public splitPanelController(TextBox splitTextBoxInput1, TextBox splitTextBoxInput2,TextBox splitTextBoxInput3, Button splitButtonInput, Label splitLabelInput1, Label splitLabelInput2, Label splitLabelInput3)
        {
            splitTextbox1 = splitTextBoxInput1;
            splitTextBox2 = splitTextBoxInput2;
            splitTextBox3 = splitTextBoxInput3;
            splitButton = splitButtonInput;
            splitLabel1 = splitLabelInput1;
            splitLabel2 = splitLabelInput2;
            splitLabel3 = splitLabelInput3;
        }


        /***********************************************/
        // FUNCTION: void disableSplitView()
        // DESCRIPTION: Disables all the view for the controllers in "Split" mode functions.
        /***********************************************/
        public void disableSplitView()
        {
            splitTextbox1.Visible = false;
            splitTextBox2.Visible = false;
            splitTextBox3.Visible = false;
            splitButton.Visible = false;
            splitLabel1.Visible = false;
            splitLabel2.Visible = false;
            splitLabel3.Visible = false;
        }


        /***********************************************/
        // FUNCTION: void enableSplitView()
        // DESCRIPTION: enables all the view for the controllers in "Split" mode functions.
        /***********************************************/
        public void enableSplitView()
        {
            splitTextbox1.Visible = true;
            splitTextBox2.Visible = true;
            splitTextBox3.Visible = true;
            splitButton.Visible = true;
            splitLabel1.Visible = true;
            splitLabel2.Visible = true;
            splitLabel3.Visible = true;
        }




    }
}
