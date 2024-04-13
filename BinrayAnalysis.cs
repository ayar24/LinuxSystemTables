using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinuxSystemTables
{
    public partial class BinrayAnalysis : Form
    {
        public BinrayAnalysis()
        {
            InitializeComponent();
        }
        public void SetELF (string elf)
        {
            elf = elf.Replace("\r", "\n");
            textBox1.Text = elf.Replace("\t", "\n");
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
