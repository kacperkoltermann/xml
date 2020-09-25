using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace xml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                XmlReader xmlReader = XmlReader.Create("https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml?fe2e4baf6098ca8b6f5e5b186b4995c7");

                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Cube"))
                    {
                        if (xmlReader.HasAttributes)

                            if ((xmlReader.GetAttribute("rate") != null))
                            {

                                richTextBox1.Text += (xmlReader.GetAttribute("currency") + ": " + xmlReader.GetAttribute("rate")) + "\n";
                                //richTextBox1.Text = (xmlReader.GetAttribute("Mid"));
                            }

                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show($"{err.Message}\n\n", "Błąd", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
