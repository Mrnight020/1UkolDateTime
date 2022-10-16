using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1.UkolDatumACas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool spravnedatum = true;
            DateTime nejmensidatum = DateTime.Now;

            double dny = 0;
            double srovnani = 0;
            int index = 0;
            int indexpole = 0;

            List<string> list = new List<string>();

            foreach (string neco in textBox1.Lines)
            {
                try
                {
                string[] pepa = neco.Split(';');
                string narozeni = pepa[2];
                //string narozeni = neco.Substring(neco.LastIndexOf(';')+1,10);

                DateTime narozenidate;
                if (!DateTime.TryParse(narozeni, out narozenidate)) 
                {
                    MessageBox.Show("Nekde se stala chyba");
                    spravnedatum = false;
                    break;
                }
                narozenidate = DateTime.Parse(narozeni);

                TimeSpan rozdil = (nejmensidatum - narozenidate);

                dny = rozdil.TotalDays;

                if (dny > srovnani)
                {
                    indexpole = index;
                    srovnani = dny;
                }

                index++;
                }
                catch
                {
                    MessageBox.Show("chyba");
                    spravnedatum = false;
                    break;
                }
                
            }

            if(spravnedatum && dny > 0)
            {
                string[] neco = textBox1.Lines[indexpole].Split(';');
                MessageBox.Show("Nejstarší je :" + neco[0] + " " + neco[1]);
            }
            textBox1.Text = "";

        }
    }
}
