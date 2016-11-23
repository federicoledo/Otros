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
    public partial class Form4 : Form
    {
        List<Thread> miLista;
        Thread miHilo;
        int contadorPelotitas;
        
        public Form4()
        {
            InitializeComponent();
            miLista = new List<Thread>();
            contadorPelotitas = 0;
            this.lblCantidad.Text = "Cantidad de\n pelotitas: ";
            this.btnPausar.Click += new EventHandler(this.pausarPelotita);
            this.btnDestruir.Click += new EventHandler(this.destruirPelotita);
            this.btnReanudar.Click += new EventHandler(this.despausarPelotita);
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

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Pelotita_con_thread.Pelotita p = new Pelotita_con_thread.Pelotita(this.pictureBox1);            
            this.miHilo = new Thread(p.DoWork);
            this.miLista.Add(miHilo);

            this.miHilo.Start();
            this.contadorPelotitas++;
            this.lblCantidad.Text = "Cantidad de\n pelotitas: " + this.contadorPelotitas.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
