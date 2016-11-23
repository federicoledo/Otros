using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelotita
{
    public partial class Form3 : Form
    {
        Thread miHilo;

        public Form3()
        {
            InitializeComponent();
            this.btnPausar.Click += new EventHandler(this.pausarPelotita);
            this.btnDestruir.Click += new EventHandler(this.destruirPelotita);
            this.btnResumir.Click += new EventHandler(this.despausarPelotita);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        public void pausarPelotita(object sender, EventArgs e)
        {
            this.miHilo.Suspend();     
        }

        public void despausarPelotita(object sender, EventArgs e)
        {
            this.miHilo.Resume();
        }

        public void destruirPelotita(object sender, EventArgs e)
        {
            this.miHilo.Abort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pelotita_con_thread.Pelotita p = new Pelotita_con_thread.Pelotita(this.pictureBox1);
            
            this.miHilo = new Thread(p.DoWork);
            this.miHilo.Start();

        }

        private void btnPausar_Click(object sender, EventArgs e)
        {

        }

        private void btnDestruir_Click(object sender, EventArgs e)
        {
            
        }
    }
}
