using System;
using System.Collections.Generic;
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
using Org.BouncyCastle.Crypto.Engines;

namespace PDFTool
{
    class deletePanelController
    {
        Label deleteLabel1; //label4
        Label deleteLabel2; //label6
        TextBox deleteTextBox; //textbox5
        TextBox deleteTextBox1; //textbox6
        Button deleteButton; //button4

        public deletePanelController( Label dLabelInput1, Label dLabelInput2, TextBox dTextBoxInput, TextBox dTextBoxInput1, Button dButtonInput)
        {
            deleteLabel1 = dLabelInput1;
            deleteLabel2 = dLabelInput2;
            deleteTextBox = dTextBoxInput;
            deleteTextBox1 = dTextBoxInput1;
            deleteButton = dButtonInput;
        }


        /***********************************************/
        // FUNCTION: void disableDeleteView()
        // DESCRIPTION: Disables all the view for the controllers in "Delete" mode functions.
        /***********************************************/
        public void disableDeleteView()
        {
            deleteLabel1.Visible = false;
            deleteLabel2.Visible = false;
            deleteTextBox.Visible = false;
            deleteTextBox1.Visible = false;
            deleteButton.Visible = false;

        }

        /***********************************************/
        // FUNCTION: void enableDeleteView()
        // DESCRIPTION: Enables all the view for the controllers in "Delete" mode functions.
        /***********************************************/
        public void enableDeleteView()
        {
            deleteLabel1.Visible = true;
            deleteLabel2.Visible = true;
            deleteTextBox.Visible = true;
            deleteTextBox1.Visible = true;
            deleteButton.Visible = true;
        }

    }

    
}
