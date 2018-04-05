using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UredjajFinder
{
    public partial class Form1 : Form
    {
        public int Brojac { get; set; }
        public StringBuilder lista { get; set; }
        public Form1()
        {
            Brojac = 0;
            lista = new StringBuilder();
            InitializeComponent();
        }

        private void txtUredjajID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                string vrijednost = DAUredjaji.GetID(txtUredjajID.Text.Trim());
                if (vrijednost != string.Empty)
                {
                    this.BackColor = Color.Red;
                    Brojac++;
                    lblBrojac.Text = Brojac.ToString();

                    lista.AppendLine(vrijednost);
                    

                }
                else
                    this.BackColor = Color.White;

                lblPrijasnji.Text = txtUredjajID.Text;
                txtUredjajID.Text = string.Empty;

            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog();
            svd.Filter = "Uredjaji DOC |.txt";
            svd.AddExtension = true;

            if (svd.ShowDialog() == DialogResult.OK)
            {
                File.AppendAllText(svd.FileName, lista.ToString());
                MessageBox.Show("Uspješno snimljena lista uređaja na lokaciji:\n" + svd.FileName, 
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
    }
}
