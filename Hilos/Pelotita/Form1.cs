using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pelotita
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
           // Pelotita_sin_thread.Pelotita p = new Pelotita_sin_thread.Pelotita(this.pictureBox1);
           // p.DoWork();
            Pelotita_con_thread.Pelotita p = new Pelotita_con_thread.Pelotita(this.pictureBox1);
            p.DoWork();
        }
    }
}
