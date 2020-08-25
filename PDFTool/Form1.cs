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
using Org.BouncyCastle.Crypto.Engines;
using System.Runtime.CompilerServices;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Linq.Expressions;
using System.ComponentModel.Design;
using iText.StyledXmlParser.Jsoup.Safety;

namespace PDFTool
{
    public partial class Form1 : Form
    {
      
        int currentNum = 0;
        
        string panelName = "pdfPanel1";
        string pictureBoxName = "pictureBox1";
        string buttonName = "pdfButton1";
        string checkBoxName = "checkBox1";
        string textBoxName = "textBox1";

        bool mergeFlag = true;
        bool splitFlag = false;
        bool deleteFlag = false;

        string splitFilePath = "";
        CheckBox splitCheckBox;



        // mergePanelArray holds the names of the files that the user wants to be merged
        mergePanelClass[] mergePanelArray = new mergePanelClass[30];
        mergePanelClass[] mergePanelArrayCopy = new mergePanelClass[30];

        // pdfIconArray holds the names of the files that the user uploaded to the program
        pdfIconPanelClass[] pdfIconArray = new pdfIconPanelClass[30];
        pdfIconPanelClass[] pdfIconArrayCopy = new pdfIconPanelClass[30];


        public Form1()
        {
            InitializeComponent();
           // textBox1.Visible = false;
          
        }
        
        /***********************************************/
        // FUNCTION: void button2_click()
        // EVENTLISTENER: for the "Add PDF" button
        // will crete PDF icon to represent user files in the middle panel
        /***********************************************/
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));

            textBox1.Text = " currentNum = " + currentNum;

            //====================================
            //==========CREATE NEW PANEL==========
            //====================================

            panelName = panelName.Remove(8, 1);
            panelName = panelName + currentNum.ToString();

            Panel newPanel = new Panel();
            newPanel.Name = panelName;  // Setting the new name of the PDF panel
            newPanel.Size = new System.Drawing.Size(160,150);
            newPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            newPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //panelArray[currentNum] = newPanel;  //place the new panel in a panel array

            tableLayoutPanel1.Controls.Add(newPanel);   // adding the new PANEL to the tableLayoutPanel
            pdfIconObj.setPanel(newPanel);
            pdfIconObj.setID(currentNum);
            

            fileName = pdfIconObj.getPDFfileName();
            //textBox1.Text +=  " [" + currentNum + "]" + " ID = " + pdfIconArray[currentNum].getID() + " " + pdfIconArray[currentNum].getPDFfileName();

            //=====================================
            //==========CREATE NEW BUTTON==========
            //=====================================

            buttonName = buttonName.Remove(9, 1);
            buttonName = buttonName + currentNum.ToString();

            Button newButton = new Button();
            newButton.Name = buttonName;            // Setting the new Button name

            newButton.Text = "DELETE";

            newButton.Location = new Point(51, 116);
            newButton.Size = new System.Drawing.Size(75,23);
            newButton.BackColor = System.Drawing.Color.White;


            newButton.Click += new System.EventHandler(this.delete_Function);
            
            //newButton.Click += delete_Function;     // new created button is linked to the delete_Function() 
            newPanel.Controls.Add(newButton);
            //tableLayoutPanel1.Controls.Add(newButton);


            //==========================================
            //==========CREATE NEW PICTURE BOX==========
            //=========================================

            pictureBoxName = pictureBoxName.Remove(10,1);
            pictureBoxName = pictureBoxName + currentNum.ToString();

            PictureBox newPictureBox1 = new PictureBox();
            newPictureBox1.Name = pictureBoxName;   // Setting the new pictureBox name

            newPanel.Controls.Add(newPictureBox1);  // adding the new picturebox to the new PANEL

            newPictureBox1.Location = new Point(30,30); // Setting the picturebox location in the PANEL
            newPictureBox1.Size = new System.Drawing.Size(100, 80);

            newPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage"))); // add a picture into the picturebox
            newPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            newPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
     

            //=======================================
            //==========CREATE NEW CHECKBOX==========
            //=======================================

            checkBoxName = checkBoxName.Remove(8,1);
            checkBoxName = checkBoxName + currentNum.ToString();

            CheckBox newCheckBox = new CheckBox();
            newCheckBox.Name = checkBoxName;        // Setting the new name of the CheckBox name

            newCheckBox.CheckedChanged += check_Function;   // action to handle when the checkbox is checked or unchecked.

            newPanel.Controls.Add(newCheckBox);     // adding the new checkbox to the new PANEL

            newCheckBox.Location = new Point(30,120);   // Setting the checkBox location in the PANEL
            newCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            pdfIconObj.setCheckBox(newCheckBox);

            pdfIconArray[currentNum] = pdfIconObj;
            

            //======================================
            //==========CREATE NEW TEXTBOX==========
            //======================================

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

        }

        /***********************************************/
        // FUNCTION: void autoscroll_Function()
        // EVENTLISTENER: function to decide if auto scroll should be turned on
        /***********************************************/
        public void autoscroll_Function()
        {

        }



        /***********************************************/
        // FUNCTION: void delete_Function()
        // EVENTLISTENER: for the "DELETE" button that removes the PDF icon
        // from the middle of the panel
        /***********************************************/
        private void delete_Function(object sender, EventArgs e)
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


        /***********************************************/
        // FUNCTION: void check_Function()
        // EVENTLISTENER: for the Checkbox that is checked in the middle panel, will create 
        //                Controllers that represents the PDF file in the merge Panel on the right hand side of the program
        /***********************************************/
        private void check_Function(object sender, EventArgs e)
        {
            CheckBox checkBoxVar = sender as CheckBox;

            //textBox1.Text = "Check box check " + checkBoxVar.Name;
            int textBoxNum = Int32.Parse(checkBoxVar.Name.Substring(8,1));  // get the checkbox number

            textBox1.Text = "" + textBoxNum;
            // textBox1.Text += " num = " + textBoxNum.ToString();


            if (checkBoxVar.Checked)
            {
                if(mergeFlag)
                {
                    createMergeControllers(sender);
                }
                else if(splitFlag)
                {
                    splitAction(sender);
                }
                else if(deleteFlag)
                {
                    deleteAction(sender);
                }
                

            }
            else
            {   // remove merge panel from the merge box table layout panel  
                if(mergeFlag)
                {
                    removeObjfromMergePanelArray(textBoxNum);
                }
                else if(splitFlag)
                {
                    textBox5.Text = "";
                    splitFilePath = "";

                }
                else if(deleteFlag)
                {
                    textBox5.Text = "";
                    splitFilePath = "";
                }

            }

        }

        /***********************************************/
        // FUNCTION: void removeObjectfromMergePanelArray()
        // DESCRIPTION: removes an object from the mergePanelArray referenced by inputTextBoxNum
        /***********************************************/
        private void removeObjfromMergePanelArray(int inputTextBoxNum)
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

        /***********************************************/
        // FUNCTION: void reorganizedpdfIconArray()
        // DESCRIPTION: Reorganizes the pdfIconArray so that there isn't any null objects in between
        /***********************************************/
        private void reorganizepdfIconArray()
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

        /***********************************************/
        // FUNCTION: void reorganizedMergePanelArray()
        // DESCRIPTION:Reorganizes the mergePanelArray so that there isn't any null object in between
        /***********************************************/
        private void reorganizeMergePanelArray()
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



        /***********************************************/
        // FUNCTION: void up_Function()
        // EVENTLISTENER: For the up arrow buttons in the MergePanel, moves the PDF files up in the que
        /***********************************************/
        private void up_Function(object sender, EventArgs e)
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
                    placement = mergePanelArray[i].getQue();
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
                mergePanelArray[replacementNum].setQue(replacementNum); // setPlacement
                mergePanelArray[placement] = mergePanelHolder;
                mergePanelArray[placement].setQue(placement); // setPlacement
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


        /***********************************************/
        // FUNCTION: void down_Function()
        // EVENTLISTENER: For the down arrow buttons in the MergePanel, moves the PDF files down in the que
        /***********************************************/
        private void down_Function(object sender, EventArgs e)
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
                    placement = mergePanelArray[i].getQue();
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
                mergePanelArray[replacementNum].setQue(replacementNum); //setPlacement
                mergePanelArray[placement] = mergePanelHolder;
                mergePanelArray[placement].setQue(placement); //setPlacement
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


        /***********************************************/
        // FUNCTION: void button5_Click()
        // EVENTLISTENER: merges the documents stored in the "mergePanelArray"
        /***********************************************/
        private void button5_Click(object sender, EventArgs e)
        {
            MergeClass mergeClassObj = new MergeClass(mergePanelArray);
        }

        /***********************************************/
        // FUNCTION: void button1Merge_Click()
        // EVENTLISTENER: For button "Merge" on the left hand side of the program so that it will switch to 
        //                Merge mode.
        /***********************************************/
        private void button1Merge_Click(object sender, EventArgs e)
        {
            CheckBox checkBoxVar;

            // perform specific action base on the previous mode of the program
            if(splitFlag == true)
            {   
                splitFlag = false;
                //splitCheckBox.Checked = false;
                textBox5.Text = "";
                splitFilePath = "";
            }
            else if(deleteFlag == true)
            {
                deleteFlag = false;
            }
            
            mergeFlag = true;
           
            for (int x = 0; x <= 30; x++)
            {
                if (mergePanelArray[x] == null)
                {
                    x = 31;
                }
                else
                {
                    //textBox1.Text += "[" + x + "]" + mergePanelArray[x].getfileName();
                    checkBoxVar = mergePanelArray[x].getCheckBox();
                    checkBoxVar.Checked = false;

                    tableLayoutPanel2.Controls.Remove(mergePanelArray[x].getPanel());
                    mergePanelArray[x] = null;
                }
            }

            splitPanelController splitPanelControllerObj = new splitPanelController(textBox3, textBox4, textBox5, button3, label1, label3, label4);
            splitPanelControllerObj.disableSplitView();

            deletePanelController deletePanelControllerObj = new deletePanelController(label5, label4, label6, textBox5, textBox6, button4);
            deletePanelControllerObj.disableDeleteView();

            mergePanelController mergePanelControllerObj = new mergePanelController(button2, button5, tableLayoutPanel2, textBox1, label2);
            mergePanelControllerObj.enableMergeView();


        }

        private void button1Merge_Hover(object sender, EventArgs e)
        {
            this.button1Merge22.ForeColor = System.Drawing.Color.Red;
        }

        private void button1Merge_Leave(object sender, EventArgs e)
        {
            this.button1Merge22.ForeColor = System.Drawing.Color.Silver;
        }


        /***********************************************/
        // FUNCTION: void button2Split_Click()
        // EVENTLISTENER: For button "Split" on the left hand side of the program so that it will switch to 
        //                split mode.
        /***********************************************/
        private void button2Split_Click(object sender, EventArgs e)
        {
            CheckBox checkBoxVar;

            if(deleteFlag == true)
            {
                deleteFlag = false;
            }
            else if(mergeFlag == true)
            {
                mergeFlag = false;
            }

            splitFlag = true;

            for (int x = 0; x <= 30; x++)
            {
                if(mergePanelArray[x] == null)
                {
                    x = 31;
                }
                else
                {
                    //textBox1.Text += "[" + x + "]" + mergePanelArray[x].getfileName();
                    checkBoxVar = mergePanelArray[x].getCheckBox();
                    checkBoxVar.Checked = false;

                    tableLayoutPanel2.Controls.Remove(mergePanelArray[x].getPanel());
                    mergePanelArray[x] = null;
                }
            }
            

            mergePanelController mergePanelControllerObj = new mergePanelController(button2, button5, tableLayoutPanel2,  textBox1, label2);
            mergePanelControllerObj.disableMergeView();

            deletePanelController deletePanelControllerObj = new deletePanelController(label5, label4, label6, textBox5, textBox6, button4);
            deletePanelControllerObj.disableDeleteView();

            splitPanelController splitPanelControllerObj = new splitPanelController(textBox3, textBox4, textBox5, button3, label1, label3, label4);
            splitPanelControllerObj.enableSplitView();





        }

        /***********************************************/
        // FUNCTION: void button3Delete_Click()
        // EVENTLISTENER: For button "Delete" on the left hand side of the program so that it will switch to 
        //                split mode.
        /***********************************************/
        private void button3Delete_Click(object sender, EventArgs e)
        {
            CheckBox checkBoxVar;

            if(mergeFlag == true)
            {
                mergeFlag = false;
            }
            else if(splitFlag == true)
            {
                splitFlag = false;
            }

            deleteFlag = true;

            mergePanelController mergePanelControllerObj = new mergePanelController(button2, button5, tableLayoutPanel2, textBox1, label2);
            mergePanelControllerObj.disableMergeView();

            splitPanelController splitPanelControllerObj = new splitPanelController(textBox3, textBox4, textBox5, button3, label1, label3, label4);
            splitPanelControllerObj.disableSplitView();

            deletePanelController deletePanelControllerObj = new deletePanelController(label5, label4, label6, textBox5, textBox6, button4);
            deletePanelControllerObj.enableDeleteView();

        }

        /***********************************************/
        // FUNCTION: void button3_Click()
        // EVENTLISTENER: For button "Split PDF" that will split the user selected PDF files
        /***********************************************/
        private void button3_Click_2(object sender, EventArgs e)
        {
           if(splitFilePath == "")
            {
                MessageBox.Show("Please select a PDF document first.");
                return;
            }

            int firstPage;
            int lastPage;

            bool isNumericFirst = int.TryParse(textBox3.Text, out firstPage);
            bool isNmericLast = int.TryParse(textBox4.Text, out lastPage);

            textBox3.Text = "";
            textBox4.Text = "";

            string fileTobeSplit = splitFilePath;
            
            splitClass splitPDF = new splitClass(fileTobeSplit);

            string resultPDF;

            if(isNumericFirst && isNmericLast)
            {
                resultPDF = splitPDF.splitRange(firstPage, lastPage);

                switch(resultPDF)
                {
                    case "1":
                        MessageBox.Show("Page " + firstPage + " is not within range. ERROR#1");
                        textBox3.Text = "";
                        return;
                    case "2":
                        MessageBox.Show("Page " + lastPage + " is not within range. ERROR#02");
                        textBox4.Text = "";
                        return;
                    case "3":
                        MessageBox.Show("Page " + firstPage + " and " + lastPage + " is not within range. ERROR#03");
                        textBox3.Text = "";
                        textBox4.Text = "";
                        return;
                    case "4":
                        MessageBox.Show("Entered the Page number in the wrong order. [first] to [last]. ERROR#04");
                        textBox3.Text = "";
                        textBox4.Text = "";
                        return;
                    default:
                        break;
                }  

            }
        }

        /***********************************************/
        // FUNCTION: void createMergeControllers()
        // DESCRIPTION: function that creates all the controllers for the Merge Panel
        /***********************************************/
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
            buttonVarUp.Name = textBoxNum.ToString();
            buttonVarUp.Size = new System.Drawing.Size(22, 22);
            buttonVarUp.Location = new Point(200, 7);
            buttonVarUp.Click += new System.EventHandler(this.up_Function);
            buttonVarUp.BackColor = System.Drawing.Color.White;

            //=====================================
            //=========CREATES NEW BUTTON========== // original form 292
            //=====================================

            Button buttonVarDown = new Button();
            buttonVarDown.Image = global::PDFTool.Properties.Resources.smalldownarrow;
            buttonVarDown.Name = textBoxNum.ToString();
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


        /***********************************************/
        // FUNCTION: void splitAction()
        // DESCRIPTION: split action that happens when the user checks a checkbox in the PDF icon
        /***********************************************/
        private void splitAction(object sender)
        {

            CheckBox checkBoxVar = sender as CheckBox;
            splitCheckBox = checkBoxVar;

            //textBox1.Text = "Check box check " + checkBoxVar.Name;
            int textBoxNum = Int32.Parse(checkBoxVar.Name.Substring(8, 1));  // get the checkbox number

            splitFilePath = pdfIconArray[textBoxNum].getPDFfilePath(); //splitFilePath will hold the file location of the document the user wants to split
            textBox5.Text = Path.GetFileName(splitFilePath);

            for (int i = 0; i <= 30; i++)
            {

                if(pdfIconArray[i] != null && i != textBoxNum)
                {
                   
                   pdfIconArray[i].getCheckBox().Checked = false;
                    
                }
                else
                {
                    i = 31;
                }
                
            }

        }

        /***********************************************/
        // FUNCTION: void deleteAction()
        // DESCRIPTION: 
        /***********************************************/
        private void deleteAction(object sender)
        {
            CheckBox checkBoxVar = sender as CheckBox;

            splitCheckBox = checkBoxVar;

            //textBox1.Text = "Check box check " + checkBoxVar.Name;
            int textBoxNum = Int32.Parse(checkBoxVar.Name.Substring(8, 1));  // get the checkbox number


            splitFilePath = pdfIconArray[textBoxNum].getPDFfilePath(); //splitFilePath will hold the file location of the document the user wants to split
            textBox5.Text = Path.GetFileName(splitFilePath);

            for (int i = 0; i <= 30; i++)
            {

                if (pdfIconArray[i] != null && i != textBoxNum)
                {

                    pdfIconArray[i].getCheckBox().Checked = false;

                }
                else
                {
                    i = 31;
                }

            }
        }

        /***********************************************/
        // FUNCTION: void button4_Click()
        // EVENTLISTENER: For button "Delete Page" that will delete pages from the user selected PDF files
        /***********************************************/
        private void button4_Click(object sender, EventArgs e)
        {
            deleteClass delObj = new deleteClass(splitFilePath);

            if(textBox5.Text == "")
            {   // user didn't select a file to delete a page from
                MessageBox.Show("ERROR. Please select a file.");
                return;
            }

            if(textBox6.Text == "")
            {   // user didn't enter a page number to delete
                MessageBox.Show("ERROR. Please enter a page number to delete.");
                return;
            }

            bool passGetPages = delObj.getPagesToDel(textBox6.Text);

            if(!passGetPages)
            {
                MessageBox.Show("ERROR: Please enter a valid number");
                textBox6.Text = "";
                return;
            }

            string newPDF = delObj.deletePage();


            switch (newPDF)
            {
                case "1":
                    MessageBox.Show("ERROR. There's only 1 page int he PDF file");
                    return;
                case "2":
                    MessageBox.Show("ERROR. You've enter a page number that is larger then the last pag enumber");
                    return;
                case "3":
                    MessageBox.Show("ERROR. You've entered page 0, there is no page 0.");
                    return;
                case "4":
                    MessageBox.Show("ERROR. Can not delete the only page in the PDF file.");
                    return;
                case "5":
                    MessageBox.Show("ERROR. PDF file must have at least 1 page in the PDF file.");
                    return;
                default:
                    break;
            }

        }

        private void panel3FileHolder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1Merge_Hover(object sender, MouseEventArgs e)
        {

        }

        private void panel1AppMode_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
