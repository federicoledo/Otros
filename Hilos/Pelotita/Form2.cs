using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;


namespace Pelotita
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pelotita_con_thread.Pelotita p = new Pelotita_con_thread.Pelotita(this.pictureBox1);
           // p.DoWork();
            Thread nuevoHilo = new Thread(p.DoWork);
            nuevoHilo.Start();
        }
    }
}
