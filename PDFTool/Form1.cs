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
        int currentNum = 1;
        int textboxNum = 1;
        int mergeBoxNum = 1;
        int mergePanelNum = 0;
        
        string panelName = "pdfPanel1";
        string pictureBoxName = "pictureBox1";
        string buttonName = "pdfButton1";
        string checkBoxName = "checkBox1";
        string textBoxName = "textBox1";
        string mergeTextBoxName = "mergeTextBox1";



        Panel[] panelArray = new Panel[30];
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


            textBox1.Text = "";
            var path = "";
            
            // OPEN A WINDOW FOR THE USER TO SELECT A PDF FILE
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName; // user selected file path is stored in "path"

                pdfFileClass pdfFileObj = new pdfFileClass();
                pdfFileObj.setPDFLocation(path);
                pdfObjArray[currentNum] = pdfFileObj;
                pdfIconObj.setPDF(pdfFileObj);


            }

            for(int i = 1; i <= currentNum; i++)
            {
                textBox1.Text += pdfObjArray[i].getPDFname() + "[" + i + "] ,";
            }

            fileName = pdfObjArray[currentNum].getPDFname();

            //==========CREATE NEW PANEL==========
            panelName = panelName.Remove(8, 1);
            panelName = panelName + currentNum.ToString();

            Panel newPanel = new Panel();
            newPanel.Name = panelName;  // Setting the new name of the PDF panel
            newPanel.Size = new System.Drawing.Size(160,150);
            panelArray[currentNum] = newPanel;  //place the new panel in a panel array

            tableLayoutPanel1.Controls.Add(newPanel);   // adding the new PANEL to the tableLayoutPanel
            pdfIconObj.setPanel(newPanel);
            pdfIconObj.setID(currentNum);

            for(int i = 0; i <= 30; i++)
            {
                if(pdfIconArray[i] == null)
                {
                    pdfIconArray[i] = pdfIconObj;
                    i = 31;
                }
            }





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



            
            currentNum++;

        }

        public void delete_Function(object sender, EventArgs e)
        {

            Button buttonName = sender as Button;

            textBox1.Text = "Delete press  " + buttonName.Name.Substring(9,1) + " , " ;

            int panelNum = Int32.Parse(buttonName.Name.Substring(9, 1));    //the number of the panel to be deleted

            for(int i = 0; i <= 30; i++)
            {
                if(panelNum == pdfIconArray[i].getID())
                {
                    tableLayoutPanel1.Controls.Remove(pdfIconArray[i].getPanel());
                    pdfIconArray[i] = null;
                    i = 31;
                }
                else if(pdfIconArray[i] == null)
                {
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

        public void check_Function(object sender, EventArgs e)
        {
            CheckBox checkBoxVar = sender as CheckBox;

            //textBox1.Text = "Check box check " + checkBoxVar.Name;
            int textBoxNum = Int32.Parse(checkBoxVar.Name.Substring(8,1));  // get the checkbox number

            textBox1.Text = "";
           // textBox1.Text += " num = " + textBoxNum.ToString();

            if (checkBoxVar.Checked)
            {
                
                TextBox textboxVar = new TextBox();
                Button buttonVarUp = new Button();
                Button buttonVarDown = new Button();
                Panel panelVar = new Panel();

                mergeTextBoxName = mergeTextBoxName.Remove(12, 1);
                mergeTextBoxName = mergeTextBoxName + textBoxNum.ToString();

                panelVar.Size = new System.Drawing.Size(244,37);

                buttonVarUp.Image = global::PDFTool.Properties.Resources.smalluparrow;
                buttonVarUp.Size = new System.Drawing.Size(22, 22);
                buttonVarUp.Location = new Point(195,7);
                buttonVarUp.Click += new System.EventHandler(this.up_Function);

                buttonVarDown.Image = global::PDFTool.Properties.Resources.smalldownarrow;
                buttonVarDown.Size = new System.Drawing.Size(22, 22);
                buttonVarDown.Location = new Point(220, 7);
                buttonVarDown.Click += new System.EventHandler(this.down_Function);

                textboxVar.Name = mergeTextBoxName;
                textboxVar.Text = pdfObjArray[textBoxNum].getPDFname();
                textboxVar.Size = new System.Drawing.Size(185, 20);
                textboxVar.Location = new Point(0,7);

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

                //mergePanelClass mergePanelObj = new mergePanelClass(panelVar, pdfObjArray[textboxNum].getPDFLocation(), textBoxNum);

                for (int i = 0; i <= 30; i++)
                {
                    if (mergePanelArray[i] == null)
                    {
                        mergePanelArray[i] = mergePanelObj;
                        i = 31;
                    }
                    else
                    {
                        //WE NEED TO DO SOMETHING HERE


                    }
                }

                //mergePanel[textBoxNum] = panelVar;

                tableLayoutPanel2.Controls.Add(mergePanelObj.getPanel());
                /*
                for (int i = 0; i <= 30; i++)
                {
                    if (mergePanelArray[i] == null)
                    {
                        i = 31;
                    }
                    else
                    {
                        textBox1.Text += "%" + mergePanelArray[i].getLinkNum() + "%";
                    }
                }
                */
            }
            else
            {   // remove merge panel from the merge box table layout panel  

               // textBox1.Text += "(" + textBoxNum + ")";
                
                removeObjfromMergePanelArray(textBoxNum);
               

                /*
                for (int i = 0; i <= 30; i++)
                {
                    if (mergePanelArray[i] == null)
                    {
                        i = 31;
                    }
                    else
                    {
                        textBox1.Text += "{" + mergePanelArray[i].getLinkNum() + "}";
                    }
                }
                */

            }

        }

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

        public void reorganizepanelArray()
        {
            for(int i = 0; i <= 30; i++)
            {
                if(panelArray[i] == null)
                {
                    int k = i + 1;
                    if(panelArray[k] == null)
                    {
                        i = 31;
                    }
                    else
                    {
                        panelArray[i] = panelArray[k];
                        panelArray[k] = null;
                    }
                }
            }
        }

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

        public void up_Function(object sender, EventArgs e)
        {

        }

        public void down_Function(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel2ActionDetail_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
