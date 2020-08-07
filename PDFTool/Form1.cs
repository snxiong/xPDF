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
    public partial class Form1 : Form
    {
        int currentNum = 0;
        int mergeBoxNum = 0;
        int mergePanelNum = 0;
        
        string panelName = "pdfPanel1";
        string pictureBoxName = "pictureBox1";
        string buttonName = "pdfButton1";
        string checkBoxName = "checkBox1";
        string textBoxName = "textBox1";
        string mergeTextBoxName = "mergeTextBox1";



        //Panel[] panelArray = new Panel[30];
        //Panel[] mergePanel = new Panel[30];
        pdfFileClass[] pdfObjArray = new pdfFileClass[30];
        mergePanelClass[] mergePanelArray = new mergePanelClass[30];

        pdfIconPanelClass[] pdfIconArray = new pdfIconPanelClass[30];


        public Form1()
        {
            InitializeComponent();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // pdfFileClass newPDFFile = new pdfFileClass();
            string fileName = "";
            pdfIconPanelClass pdfIconObj = new pdfIconPanelClass();


            //========================CODE TO OPEN A DOCUMENT FINDER WINDOW
            //Opens a file selection window, to allow user to select a pdf file
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "PDF (*.pdf)| *.pdf";  // user can only view.pdf files
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;


            //textBox1.Text = "" + "[" + currentNum + "]";
            var path = "";
            
            // OPEN A WINDOW FOR THE USER TO SELECT A PDF FILE
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName; // user selected file path is stored in "path"

                pdfFileClass pdfFileObj = new pdfFileClass();
                pdfFileObj.setPDFLocation(path);
                pdfIconObj.setPDF(pdfFileObj);

                
            }

            textBox1.Text = "";
            
            //fileName = pdfObjArray[currentNum].getPDFname();
            for(int i = 0; i <= 30; i++)
            {
                if(pdfIconArray[i] == null)
                {
                    currentNum = i;
                    i = 31;
                }
            }

            textBox1.Text = " currentNum = " + currentNum;
            //==========CREATE NEW PANEL==========
            panelName = panelName.Remove(8, 1);
            panelName = panelName + currentNum.ToString();

            Panel newPanel = new Panel();
            newPanel.Name = panelName;  // Setting the new name of the PDF panel
            newPanel.Size = new System.Drawing.Size(160,150);
            //panelArray[currentNum] = newPanel;  //place the new panel in a panel array

            tableLayoutPanel1.Controls.Add(newPanel);   // adding the new PANEL to the tableLayoutPanel
            pdfIconObj.setPanel(newPanel);
            pdfIconObj.setID(currentNum);
            pdfIconArray[currentNum] = pdfIconObj;

            fileName = pdfIconObj.getPDFfileName();
            //textBox1.Text +=  " [" + currentNum + "]" + " ID = " + pdfIconArray[currentNum].getID() + " " + pdfIconArray[currentNum].getPDFfileName();

            //==========CREATE NEW BUTTON==========
            buttonName = buttonName.Remove(9, 1);
            buttonName = buttonName + currentNum.ToString();

            Button newButton = new Button();
            newButton.Name = buttonName;            // Setting the new Button name

            newButton.Text = "DELETE";

            newButton.Location = new Point(51, 116);
            newButton.Size = new System.Drawing.Size(75,23);

            newButton.Click += new System.EventHandler(this.delete_Function);
            
            //newButton.Click += delete_Function;     // new created button is linked to the delete_Function() 
            newPanel.Controls.Add(newButton);
            //tableLayoutPanel1.Controls.Add(newButton);

            

            //==========CREATE NEW PICTURE BOX==========
            
            pictureBoxName = pictureBoxName.Remove(10,1);
            pictureBoxName = pictureBoxName + currentNum.ToString();

            PictureBox newPictureBox1 = new PictureBox();
            newPictureBox1.Name = pictureBoxName;   // Setting the new pictureBox name

            newPanel.Controls.Add(newPictureBox1);  // adding the new picturebox to the new PANEL

            newPictureBox1.Location = new Point(40,30); // Setting the picturebox location in the PANEL

            newPictureBox1.ImageLocation = "C:\\Users\\MiniSnxiong\\Desktop\\PDFicon.png"; // add a picture into the picturebox
            
            
            
            //==========CREATE NEW CHECKBOX==========
            checkBoxName = checkBoxName.Remove(8,1);
            checkBoxName = checkBoxName + currentNum.ToString();

            CheckBox newCheckBox = new CheckBox();
            newCheckBox.Name = checkBoxName;        // Setting the new name of the CheckBox name

            newCheckBox.CheckedChanged += check_Function;   // action to handle when the checkbox is checked or unchecked.

            newPanel.Controls.Add(newCheckBox);     // adding the new checkbox to the new PANEL

            newCheckBox.Location = new Point(30,120);   // Setting the checkBox location in the PANEL

            //==========CREATE NEW TEXTBOX==========

            textBoxName = textBoxName.Remove(7,1);
            textBoxName = textBoxName + currentNum.ToString();

            TextBox newTextBox = new TextBox();
            newTextBox.Name = textBoxName;      // Setting the new name of the textbox name

            newPanel.Controls.Add(newTextBox);  // adding the new textbox to the new PANEL

            newTextBox.Size = new System.Drawing.Size(120, 20);
            newTextBox.Location = new Point(20,3);  // Setting the textBox location in the PANEL
            newTextBox.ReadOnly = true;

            newTextBox.Text = fileName;
            //newTextBox.Text = "PDF File #" + currentNum.ToString();

            //=======================================
            /*
            Button textButton = new Button();

            textButton.Name = buttonName;
            textButton.Size = new System.Drawing.Size(75, 23);
            textButton.Click += new System.EventHandler(this.test_function);
            newPanel.Controls.Add(textButton);
            */



            
           // currentNum++;

        }

        public void delete_Function(object sender, EventArgs e)
        {

            Button buttonName = sender as Button;

            //textBox1.Text = "Delete press  " + buttonName.Name.Substring(9,1) + " , " ;

            int panelNum = Int32.Parse(buttonName.Name.Substring(9, 1));    //the number of the panel to be deleted

            for(int i = 0; i <= 30; i++)
            {
                if(pdfIconArray[i] == null)
                {
                    int k = i - 1;
                    textBox1.Text = "CRAP i = " + i + " panelNum = " + panelNum + " ID =" + pdfIconArray[panelNum].getID();
                    i = 31;
                    
                }
                else if(panelNum == pdfIconArray[i].getID())
                {
                    tableLayoutPanel1.Controls.Remove(pdfIconArray[i].getPanel());
                    pdfIconArray[i] = null;
                    i = 31;
                }
           
            }
            reorganizepdfIconArray();

            for(int i = 0; i <= 30; i++)
            {
                if (mergePanelArray[i] == null)
                {
                    i = 31;
                }
                else if (panelNum == mergePanelArray[i].getLinkNum())
                {
                    tableLayoutPanel2.Controls.Remove(mergePanelArray[i].getPanel());
                    mergePanelArray[i] = null;
                    i = 31;
                }
                
            }
            reorganizeMergePanelArray();

        }

        public void test_function(object sender, EventArgs e)
        {
            Button buttonVar = sender as Button;
            int textBoxNum = Int32.Parse(buttonVar.Name.Substring(9,1));

            textBox1.Text = "(" + textBoxNum + ") " + pdfIconArray[textBoxNum].getPDFfileName() + " ID = " + pdfIconArray[textBoxNum].getID();


        }

        public void check_Function(object sender, EventArgs e)
        {
            CheckBox checkBoxVar = sender as CheckBox;

            //textBox1.Text = "Check box check " + checkBoxVar.Name;
            int textBoxNum = Int32.Parse(checkBoxVar.Name.Substring(8,1));  // get the checkbox number

            textBox1.Text = "" + textBoxNum;
            // textBox1.Text += " num = " + textBoxNum.ToString();

            mergePanelNum = textBoxNum;

            if (checkBoxVar.Checked)
            {
                
                TextBox textboxVar = new TextBox();
                TextBox textboxVar2 = new TextBox();
                Button buttonVarUp = new Button();
                Button buttonVarDown = new Button();
                Panel panelVar = new Panel();

                mergeTextBoxName = mergeTextBoxName.Remove(12, 1);
                mergeTextBoxName = mergeTextBoxName + textBoxNum.ToString();

                panelVar.Size = new System.Drawing.Size(244,37);

                buttonVarUp.Image = global::PDFTool.Properties.Resources.smalluparrow;
                buttonVarUp.Name = textBoxNum.ToString();
                buttonVarUp.Size = new System.Drawing.Size(22, 22);
                buttonVarUp.Location = new Point(195,7);
                buttonVarUp.Click += new System.EventHandler(this.up_Function);

                buttonVarDown.Image = global::PDFTool.Properties.Resources.smalldownarrow;
                buttonVarDown.Name = textBoxNum.ToString();
                buttonVarDown.Size = new System.Drawing.Size(22, 22);
                buttonVarDown.Location = new Point(220, 7);
                buttonVarDown.Click += new System.EventHandler(this.down_Function);

                textboxVar.Name = mergeTextBoxName;
                //textboxVar.Text = pdfObjArray[textBoxNum].getPDFname();
                textboxVar.Text = pdfIconArray[textBoxNum].getPDFfileName();
                textboxVar.Size = new System.Drawing.Size(185, 20);
                textboxVar.Location = new Point(0,7);

                textboxVar2.Text = textBoxNum.ToString();
                textboxVar2.Visible = false;

                panelVar.Controls.Add(textboxVar2);
                panelVar.Controls.Add(textboxVar);
                panelVar.Controls.Add(buttonVarUp);
                panelVar.Controls.Add(buttonVarDown);

                mergePanelClass mergePanelObj = null;

                int x = 0;
                for (int i = 0; i <= 30; i++)
                {
                    if(textBoxNum == pdfIconArray[i].getID())
                    {
                       mergePanelObj = new mergePanelClass(panelVar, pdfIconArray[i].getPDFfilePath(), textBoxNum);
                        i = 31;
                    }
                }

                for (int i = 0; i <= 30; i++)
                {
                    if (mergePanelArray[i] == null)
                    {
                        mergePanelObj.setPlacement(i);
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
            else
            {   // remove merge panel from the merge box table layout panel  

                removeObjfromMergePanelArray(textBoxNum);

            }

        }

        // FUNCTION to remove a Panel controller from the merge tablelayoutpanel and from the mergePanelArray
        public void removeObjfromMergePanelArray(int inputTextBoxNum)
        {
            for (int i = 0; i <= 30; i++)
            {
                if (mergePanelArray[i].getLinkNum() == inputTextBoxNum)
                {
                    tableLayoutPanel2.Controls.Remove(mergePanelArray[i].getPanel());
                    mergePanelArray[i] = null;
                    i = 31;
                }
                else
                {

                }
            }

            reorganizeMergePanelArray();
        }

        // FUNCTION to reorganize the pdfIconArray so that there isn't any null object in between objects
        public void reorganizepdfIconArray()
        {
            for(int i = 0; i <= 30; i++)
            {
                if(pdfIconArray[i] == null)
                {
                    int k = i + 1;
                    if(pdfIconArray[k] == null)
                    {
                        i = 31;
                    }
                    else
                    {
                        pdfIconArray[i] = pdfIconArray[k];
                        pdfIconArray[k] = null; 
                    }
                }
            }
        }

        // FUNCTION to reorganize the MergePanelArray so that there isn't any null object in between objects
        public void reorganizeMergePanelArray()
        {
            for (int i = 0; i <= 30; i++)
            {
                if (mergePanelArray[i] == null)
                {
                    int k = i + 1;
                    if (mergePanelArray[k] == null)
                    {
                        i = 31;
                    }
                    else
                    {
                        mergePanelArray[i] = mergePanelArray[k];
                        mergePanelArray[k] = null;

                    }
                }


            }
        }

        public void refresh_mergeTable()
        {

        }

        // FUNCTION to move up the obj in the mergePanelArray
        public void up_Function(object sender, EventArgs e)
        {
            Button buttonVar = sender as Button;
            int textBoxNum = Int32.Parse(buttonVar.Name.Substring(0, 1));
            //textBox1.Text = "UP " + textBoxNum + "" ;

            int placement = 0;
            int replacementNum = 0;

            for(int i = 0; i <= 30; i++)
            {
                if(textBoxNum == mergePanelArray[i].getLinkNum())
                {
                    placement = mergePanelArray[i].getPlacement();
                    i = 31;
                }
            }

            for(int i= 0;i <= 30; i++)
            {
                if(mergePanelArray[i] != null)
                {
                    tableLayoutPanel2.Controls.Remove(mergePanelArray[i].getPanel());
                }
                else
                {
                    i = 31;
                }
            }

            if(placement != 0)
            {

                replacementNum = placement - 1;
                mergePanelClass mergePanelHolder = mergePanelArray[replacementNum];
                mergePanelArray[replacementNum] = mergePanelArray[placement];
                mergePanelArray[replacementNum].setPlacement(replacementNum);
                mergePanelArray[placement] = mergePanelHolder;
                mergePanelArray[placement].setPlacement(placement);
            }

            for(int i = 0; i <= 30; i++)
            {
                if(mergePanelArray[i] != null)
                {
                    tableLayoutPanel2.Controls.Add(mergePanelArray[i].getPanel());
                }
                else
                {
                    i = 31;
                }
                
            }
        }

        // FUNCTION to move down the obj in the mergePanelArray
        public void down_Function(object sender, EventArgs e)
        {
            Button buttonVar = sender as Button;
            int textBoxNum = Int32.Parse(buttonVar.Name.Substring(0, 1));
            textBox1.Text = "DOWN " + textBoxNum;

            int placement = 0;
            int replacementNum = 0;
            int lastObj = 0;

            for(int i = 0; i <= 30; i++)
            {
                if(textBoxNum == mergePanelArray[i].getLinkNum())
                {
                    placement = mergePanelArray[i].getPlacement();
                    i = 31;
                }
            }

            for(int i = 0; i <= 30; i++)
            {
                if(mergePanelArray[i] == null)
                {
                    lastObj = i - 1;
                    i = 31;
                }
                else if(mergePanelArray[i] != null)
                {
                    tableLayoutPanel2.Controls.Remove(mergePanelArray[i].getPanel());
                    //textBox1.Text += " REMOVED " + mergePanelArray[i].getfileName();
                }
              
            }

            if(placement != lastObj)
            {
                replacementNum = placement + 1;
                mergePanelClass mergePanelHolder = mergePanelArray[replacementNum];
                mergePanelArray[replacementNum] = mergePanelArray[placement];
                mergePanelArray[replacementNum].setPlacement(replacementNum);
                mergePanelArray[placement] = mergePanelHolder;
                mergePanelArray[placement].setPlacement(placement);
            }

            for(int i = 0; i<= 30; i++)
            {
                if(mergePanelArray[i] != null)
                {
                    tableLayoutPanel2.Controls.Add(mergePanelArray[i].getPanel());
                }
                else
                {
                    i = 31;
                }
            }

            

           
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel2ActionDetail_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            for(int i = 0; i <= 30; i++)
            {
                if(pdfIconArray[i] != null)
                {
                    textBox1.Text += pdfIconArray[i].getPDFfileName() + "[" + i + "] ";
         
                }
                else if(pdfIconArray[i] == null)
                {
                    i = 31;
                }
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
