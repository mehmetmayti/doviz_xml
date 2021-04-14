using doviz_xml.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doviz_xml
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataXmlServices services = new DataXmlServices();
            var a = services.getAllDocument();
            var b=services.convertToList(a);
            services.listWriteTextFile(b);
        }
    }
}
