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
        int placement;

        mergePanelClass()
        {

        }

        public mergePanelClass(Panel panelInput, string fileLocInput, int linkNumInput)
        {
            panelVar = panelInput;
            fileLocation = fileLocInput;
            fileName = Path.GetFileName(fileLocInput);
            linkNum = linkNumInput;
        }

        public void setPlacement(int placementInput)
        {
            placement = placementInput;
        }
        public int getPlacement()
        {
            return placement;
        }

        public Panel getPanel()
        {
            return panelVar;
        }

        public int getLinkNum()
        {
            return linkNum;
        }

        public string getfileName()
        {
            return fileName;
        }

        public string getfileLocation()
        {
            return fileLocation;
        }
     
    }


}


 /*
            buttonVar = sender as Button;
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


 * */
