using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFTool
{
    class checkBoxClass
    {
        mergePanelClass mergePanelObj;
        bool mergeFlag;
        bool splitFlag;
        bool deleteFlag;
        int textBoxNum;
        CheckBox checkBoxVar;

        List<Control> controlList = new List<Control>();
   


        public checkBoxClass(bool mergeFlagInput, bool splitFlagInput, bool deleteFlagInput, int textBoxNumInput )
        {
            mergeFlag = mergeFlagInput;
            splitFlag = splitFlagInput;
            deleteFlag = deleteFlagInput;
            textBoxNum = textBoxNumInput;
            
        }

        public void checkBoxClick()
        {
            if(mergeFlag)
            {
                
            }
            else if(splitFlag)
            {
                
            }
            else if(deleteFlag)
            {

            }
        }


    }
}
