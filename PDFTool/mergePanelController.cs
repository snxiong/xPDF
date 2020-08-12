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


    class mergePanelController
    {
        Button addPDFButton;
        Button mergeButton;
        TableLayoutPanel mergeTableLayoutPanel;
        TextBox textBoxMerge;
        Label mergeLabel;

        public mergePanelController(Button addPDFButtonInput, Button mergeButtonInput, TableLayoutPanel tableLayoutPanelInput, TextBox textBoxMergeInput, Label labelInput)
        {
            //addPDFButton = addPDFButtonInput;
            mergeButton = mergeButtonInput;
            mergeTableLayoutPanel = tableLayoutPanelInput;
            textBoxMerge = textBoxMergeInput;
            mergeLabel = labelInput;
        }

        public void disableView()
        {
           // addPDFButton.Visible = false;
            mergeButton.Visible = false;
            mergeTableLayoutPanel.Visible = false;
            textBoxMerge.Visible = false;
            mergeLabel.Visible = false;
        }

        public void enableView()
        {
           // addPDFButton.Visible = true;
            mergeButton.Visible = true;
            mergeTableLayoutPanel.Visible = true;
            textBoxMerge.Visible = true;
            mergeLabel.Visible = true;
        }
    }
}
