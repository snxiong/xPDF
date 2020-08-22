using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
//using System.Web.UI.WebControls;
using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;

namespace PDFTool
{
    [TestFixture]
    public class unitTesting
    {
        private string pdfTestDoc = Path.Combine(Directory.GetCurrentDirectory(), "PDFSAMPLE.pdf");

        [SetUp]
        public void setup()
        {

        }

    }
}
