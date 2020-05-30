using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace SOJU_VISUAL
{
    public partial class Form1 : Form
    {
        Cliente cli;
        SqlConnection cnn;
        Queue <Cliente> ListaClientes = new Queue<Cliente>();
        string extra;
        double xPriceFinal;
        ListaPrecio xLP = new ListaPrecio();
        public Form1()
        {
            InitializeComponent();

            string connetionString;
            connetionString = @"Data Source=LAPTOP-7C4IOT56\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            #region Label
            //LABEL
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.label3.Visible = false;
            this.label4.Visible = false;
            this.label5.Visible = false;
            this.label6.Visible = false;
            this.label7.Visible = false;
            this.label8.Visible = false;
            this.label9.Visible = false;
            this.label10.Visible = false;
            #endregion
            #region Button
            //BUTTON
            this.button3.Visible = false;
            this.button4.Visible = false;
            this.button5.Visible = false;
            this.button6.Visible = false;
            this.button9.Visible = false;
            this.button10.Visible = false;
            this.button11.Visible = false;
            this.button12.Visible = false;
            this.button13.Visible = false;
            this.button14.Visible = false;
            this.button15.Visible = false;
            this.button16.Visible = false;
            this.button17.Visible = false;
            this.button18.Visible = false;
            this.button19.Visible = false;
            this.button20.Visible = false;
            #endregion
            #region Textbox
            //TEXTBOX
            this.textBox1.Visible = false;
            this.textBox2.Visible = false;
            this.textBox3.Visible = false;
            this.textBox4.Visible = false;
            this.textBox5.Visible = false;
            this.textBox6.Visible = false;
            this.textBox7.Visible = false;
            this.textBox8.Visible = false;
            this.textBox10.Visible = false;
            #endregion
            #region ComboBox
            //COMBOBOX
            this.comboBox1.Visible = false;
            #endregion
            buttonPedidoUnshow();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.button3.Visible = true;
            this.button4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // NUEVO CLIENTE
            //Cliente c = new Cliente();
            this.textBox1.Visible = true;
            this.textBox2.Visible = true;
            this.textBox3.Visible = true;
            this.label2.Visible = true;
            this.label3.Visible = true;
            this.label4.Visible = true;
            this.button5.Visible = true;
            this.button4.Visible = false;
            this.button3.Visible = false;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //FINALIZADO CLIENTE
            int xID = 0;
            string sqlID = "SELECT TOP 1 ID FROM CLIENTE ORDER BY ID DESC";
            SqlCommand cmdID = new SqlCommand(sqlID, cnn);
            using (SqlDataReader reader = cmdID.ExecuteReader())
            {
                if (reader.Read())
                {
                    xID = int.Parse(reader["id"].ToString()) + 1;
                }
            }
            string a = this.textBox1.Text;
            string b = this.textBox2.Text;
            string c = this.textBox3.Text;
            this.label2.Visible = false;
            this.label3.Visible = false;
            this.label4.Visible = false;
            this.button5.Visible = false;
            this.textBox1.Visible = false;
            this.textBox2.Visible = false;
            this.textBox3.Visible = false;

            cli = new Cliente(a, b, c, xID);

            string sql = "INSERT INTO CLIENTE(ID, NOMBRE, DIRECCION, TELEFONO) VALUES(@param1,@param2,@param3,@param4)";
            using (SqlCommand cmd = new SqlCommand(sql, cnn))
            {
                cmd.Parameters.Add("@param1", SqlDbType.Int).Value = xID;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar, 75).Value = a;
                cmd.Parameters.Add("@param3", SqlDbType.VarChar, 100).Value = b;
                cmd.Parameters.Add("@param4", SqlDbType.VarChar, 50).Value = c;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            buttonPedidoShow();
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ELEGIR CLIENTE

            this.textBox10.Visible = true;
            this.label1.Visible = true;

            this.button9.Visible = true;

            this.button3.Visible = false;
            this.button4.Visible = false;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //FINALIZADO PEDIDO
            checkSingle();
            double precioFinal = calculaPrecios();
            buttonPedidoUnshow();
            int xID = 0;
            DateTime dia = DateTime.Now;
            string sqlID = "SELECT TOP 1 ID FROM PEDIDO ORDER BY ID DESC";
            SqlCommand cmdID = new SqlCommand(sqlID, cnn);
            using (SqlDataReader reader = cmdID.ExecuteReader())
            {
                if (reader.Read())
                {
                    xID = int.Parse(reader["id"].ToString());
                }
            }
            //Pedido p = new Pedido(int.Parse(this.textBox8.Text), int.Parse(this.textBox9.Text), int.Parse(this.textBox7.Text), int.Parse(this.textBox6.Text), int.Parse(this.textBox5.Text), this.textBox4.Text, cli);
            Pedido p = new Pedido(int.Parse(this.textBox8.Text), int.Parse(this.textBox4.Text), int.Parse(this.textBox5.Text), int.Parse(this.textBox6.Text), int.Parse(this.textBox7.Text), this.extra, cli, precioFinal);
            string sql = "INSERT INTO PEDIDO(ID, RB, MIX, FRUIT, PREMIUM, MAPLE, EXTRA, PRICE, FECHA, CLIENTE) VALUES(@param1,@param2,@param3,@param4, @param5, @param6, @param7, @param8, @param9, @param10)";
            using (SqlCommand cmd = new SqlCommand(sql, cnn))
            {
                cmd.Parameters.Add("@param1", SqlDbType.Int).Value = xID + 1;
                cmd.Parameters.Add("@param2", SqlDbType.Int).Value = p.rb;
                cmd.Parameters.Add("@param3", SqlDbType.Int).Value = p.mix;
                cmd.Parameters.Add("@param4", SqlDbType.Int).Value = p.fruit;
                cmd.Parameters.Add("@param5", SqlDbType.Int).Value = p.premium;
                cmd.Parameters.Add("@param6", SqlDbType.Int).Value = p.maples;
                cmd.Parameters.Add("@param7", SqlDbType.VarChar, 500).Value = p.extra;
                cmd.Parameters.Add("@param8", SqlDbType.Float).Value = p.total;
                cmd.Parameters.Add("@param9", SqlDbType.Date).Value = dia.Date;
                cmd.Parameters.Add("@param10", SqlDbType.Int).Value = cli.ID;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }

            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.textBox8.Text = "";

            this.button1.Visible = true;
            this.button2.Visible = true;
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //FINALIZADO PONER NOMBRE PARA ELEGIR CLIENTE
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM CLIENTE WHERE NOMBRE LIKE '%" + this.textBox10.Text + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                //MessageBox.Show((dr["nombre"].ToString()));
                Cliente x = new Cliente(dr["nombre"].ToString(), dr["direccion"].ToString(), dr["telefono"].ToString(), int.Parse(dr["id"].ToString()));
                ListaClientes.Enqueue(x);
            }

            this.comboBox1.Items.Clear();
            foreach (Cliente V in ListaClientes)
            {
                //MessageBox.Show(V.showCliente());
                this.comboBox1.Items.Add(V.showCliente());

            }

            this.textBox10.Visible = false;
            this.label1.Visible = false;
            this.button9.Visible = false;

            this.button10.Visible = true;
            this.comboBox1.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //FINALIZADO SELECCIONAR CLIENTE
            this.button10.Visible = false;
            this.comboBox1.Visible = false;
            string xSTR = this.comboBox1.SelectedItem.ToString();
            foreach (Cliente xCli in ListaClientes)
            {
                string xStr = xCli.showCliente();
                if (xStr == xSTR)
                {
                    cli = xCli;
                }
            }
            this.comboBox1.Items.Clear();
            buttonPedidoShow();
        }

        public void buttonPedidoUnshow()
        {
            #region Label
            this.label5.Visible = false;
            this.label6.Visible = false;
            this.label7.Visible = false;
            this.label8.Visible = false;
            this.label9.Visible = false;
            this.label10.Visible = false;

            this.label11.Visible = false;
            this.label12.Visible = false;
            this.label13.Visible = false;
            this.label14.Visible = false;
            this.label15.Visible = false;
            this.label16.Visible = false;
            this.label17.Visible = false;
            this.label18.Visible = false;
            this.label19.Visible = false;
            this.label20.Visible = false;
            this.label21.Visible = false;
            this.label22.Visible = false;
            this.label23.Visible = false;
            this.label24.Visible = false;
            this.label25.Visible = false;
            this.label26.Visible = false;
            this.label27.Visible = false;
            this.label28.Visible = false;
            this.label29.Visible = false;
            this.label30.Visible = false;
            this.label31.Visible = false;
            this.label32.Visible = false;
            this.label33.Visible = false;
            this.label34.Visible = false;
            this.label35.Visible = false;
            this.label36.Visible = false;
            this.label37.Visible = false;
            this.label38.Visible = false;
            this.label39.Visible = false;
            this.label40.Visible = false;
            this.label41.Visible = false;
            this.label42.Visible = false;
            this.label43.Visible = false;
            this.label44.Visible = false;
            this.label45.Visible = false;
            this.label46.Visible = false;
            #endregion
            #region Button
            this.button6.Visible = false;

            this.button11.Visible = false;
            this.button12.Visible = false;
            this.button13.Visible = false;
            this.button14.Visible = false;
            this.button15.Visible = false;
            this.button16.Visible = false;
            this.button17.Visible = false;
            this.button18.Visible = false;
            this.button19.Visible = false;
            this.button20.Visible = false;

            this.button7.Visible = false;
            this.button8.Visible = false;
            this.button21.Visible = false;
            this.button22.Visible = false;
            this.button23.Visible = false;
            this.button24.Visible = false;
            this.button25.Visible = false;
            this.button26.Visible = false;
            this.button27.Visible = false;
            this.button28.Visible = false;
            this.button29.Visible = false;
            this.button30.Visible = false;
            this.button31.Visible = false;
            this.button32.Visible = false;
            this.button33.Visible = false;
            this.button34.Visible = false;
            this.button35.Visible = false;
            this.button36.Visible = false;
            this.button37.Visible = false;
            this.button38.Visible = false;
            this.button39.Visible = false;
            this.button40.Visible = false;
            this.button41.Visible = false;
            this.button42.Visible = false;
            this.button43.Visible = false;
            this.button44.Visible = false;
            this.button45.Visible = false;
            this.button46.Visible = false;
            this.button47.Visible = false;
            this.button48.Visible = false;
            this.button49.Visible = false;
            this.button50.Visible = false;
            this.button51.Visible = false;
            this.button52.Visible = false;
            this.button53.Visible = false;
            this.button54.Visible = false;
            this.button55.Visible = false;
            this.button56.Visible = false;
            this.button57.Visible = false;
            this.button58.Visible = false;
            this.button59.Visible = false;
            this.button60.Visible = false;
            this.button61.Visible = false;
            this.button62.Visible = false;
            this.button63.Visible = false;
            this.button64.Visible = false;
            this.button65.Visible = false;
            this.button66.Visible = false;
            this.button67.Visible = false;
            this.button68.Visible = false;
            this.button69.Visible = false;
            this.button70.Visible = false;
            this.button71.Visible = false;
            this.button72.Visible = false;
            this.button73.Visible = false;
            this.button74.Visible = false;
            this.button75.Visible = false;
            this.button76.Visible = false;
            this.button77.Visible = false;
            this.button78.Visible = false;
            this.button79.Visible = false;
            this.button80.Visible = false;
            this.button81.Visible = false;
            this.button82.Visible = false;
            this.button83.Visible = false;
            this.button84.Visible = false;
            this.button85.Visible = false;
            this.button86.Visible = false;
            this.button87.Visible = false;
            this.button88.Visible = false;
            this.button89.Visible = false;
            this.button90.Visible = false;
            #endregion
            #region TextBox
            this.textBox4.Visible = false;
            this.textBox5.Visible = false;
            this.textBox6.Visible = false;
            this.textBox7.Visible = false;
            this.textBox8.Visible = false;

            this.textBox9.Visible = false;
            this.textBox11.Visible = false;
            this.textBox12.Visible = false;
            this.textBox13.Visible = false;
            this.textBox14.Visible = false;
            this.textBox15.Visible = false;
            this.textBox16.Visible = false;
            this.textBox17.Visible = false;
            this.textBox18.Visible = false;
            this.textBox19.Visible = false;
            this.textBox20.Visible = false;
            this.textBox21.Visible = false;
            this.textBox22.Visible = false;
            this.textBox23.Visible = false;
            this.textBox24.Visible = false;
            this.textBox25.Visible = false;
            this.textBox26.Visible = false;
            this.textBox27.Visible = false;
            this.textBox28.Visible = false;
            this.textBox29.Visible = false;
            this.textBox30.Visible = false;
            this.textBox31.Visible = false;
            this.textBox32.Visible = false;
            this.textBox33.Visible = false;
            this.textBox34.Visible = false;
            this.textBox35.Visible = false;
            this.textBox36.Visible = false;
            this.textBox37.Visible = false;
            this.textBox38.Visible = false;
            this.textBox39.Visible = false;
            this.textBox40.Visible = false;
            this.textBox41.Visible = false;
            this.textBox42.Visible = false;
            this.textBox43.Visible = false;
            this.textBox44.Visible = false;
            this.textBox45.Visible = false;
            #endregion
            this.dateTimePicker1.Visible = false;
            this.dateTimePicker2.Visible = false;
        }

        public void buttonPedidoShow()
        {
            #region Label
            this.label5.Visible = true;
            this.label6.Visible = true;
            this.label7.Visible = true;
            this.label8.Visible = true;
            this.label9.Visible = true;
            this.label10.Visible = true;

            this.label11.Visible = true;
            this.label12.Visible = true;
            this.label13.Visible = true;
            this.label14.Visible = true;
            this.label15.Visible = true;
            this.label16.Visible = true;
            this.label17.Visible = true;
            this.label18.Visible = true;
            this.label19.Visible = true;
            this.label20.Visible = true;
            this.label21.Visible = true;
            this.label22.Visible = true;
            this.label23.Visible = true;
            this.label24.Visible = true;
            this.label25.Visible = true;
            this.label26.Visible = true;
            this.label27.Visible = true;
            this.label28.Visible = true;
            this.label29.Visible = true;
            this.label30.Visible = true;
            this.label31.Visible = true;
            this.label32.Visible = true;
            this.label33.Visible = true;
            this.label34.Visible = true;
            this.label35.Visible = true;
            this.label36.Visible = true;
            this.label37.Visible = true;
            this.label38.Visible = true;
            this.label39.Visible = true;
            this.label40.Visible = true;
            this.label41.Visible = true;
            this.label42.Visible = true;
            this.label43.Visible = true;
            this.label44.Visible = true;
            this.label45.Visible = true;
            this.label46.Visible = true;
            #endregion
            #region Button
            this.button6.Visible = true;

            this.button11.Visible = true;
            this.button12.Visible = true;
            this.button13.Visible = true;
            this.button14.Visible = true;
            this.button15.Visible = true;
            this.button16.Visible = true;
            this.button17.Visible = true;
            this.button18.Visible = true;
            this.button19.Visible = true;
            this.button20.Visible = true;

            this.button7.Visible = true;
            this.button8.Visible = true;
            this.button21.Visible = true;
            this.button22.Visible = true;
            this.button23.Visible = true;
            this.button24.Visible = true;
            this.button25.Visible = true;
            this.button26.Visible = true;
            this.button27.Visible = true;
            this.button28.Visible = true;
            this.button29.Visible = true;
            this.button30.Visible = true;
            this.button31.Visible = true;
            this.button32.Visible = true;
            this.button33.Visible = true;
            this.button34.Visible = true;
            this.button35.Visible = true;
            this.button36.Visible = true;
            this.button37.Visible = true;
            this.button38.Visible = true;
            this.button39.Visible = true;
            this.button40.Visible = true;
            this.button41.Visible = true;
            this.button42.Visible = true;
            this.button43.Visible = true;
            this.button44.Visible = true;
            this.button45.Visible = true;
            this.button46.Visible = true;
            this.button47.Visible = true;
            this.button48.Visible = true;
            this.button49.Visible = true;
            this.button50.Visible = true;
            this.button51.Visible = true;
            this.button52.Visible = true;
            this.button53.Visible = true;
            this.button54.Visible = true;
            this.button55.Visible = true;
            this.button56.Visible = true;
            this.button57.Visible = true;
            this.button58.Visible = true;
            this.button59.Visible = true;
            this.button60.Visible = true;
            this.button61.Visible = true;
            this.button62.Visible = true;
            this.button63.Visible = true;
            this.button64.Visible = true;
            this.button65.Visible = true;
            this.button66.Visible = true;
            this.button67.Visible = true;
            this.button68.Visible = true;
            this.button69.Visible = true;
            this.button70.Visible = true;
            this.button71.Visible = true;
            this.button72.Visible = true;
            this.button73.Visible = true;
            this.button74.Visible = true;
            this.button75.Visible = true;
            this.button76.Visible = true;
            this.button77.Visible = true;
            this.button78.Visible = true;
            this.button79.Visible = true;
            this.button80.Visible = true;
            this.button81.Visible = true;
            this.button82.Visible = true;
            this.button83.Visible = true;
            this.button84.Visible = true;
            this.button85.Visible = true;
            this.button86.Visible = true;
            this.button87.Visible = true;
            this.button88.Visible = true;
            this.button89.Visible = true;
            this.button90.Visible = true;
            #endregion
            #region TextBox
            this.textBox4.Visible = true;
            this.textBox5.Visible = true;
            this.textBox6.Visible = true;
            this.textBox7.Visible = true;
            this.textBox8.Visible = true;

            this.textBox9.Visible = true;
            this.textBox11.Visible = true;
            this.textBox12.Visible = true;
            this.textBox13.Visible = true;
            this.textBox14.Visible = true;
            this.textBox15.Visible = true;
            this.textBox16.Visible = true;
            this.textBox17.Visible = true;
            this.textBox18.Visible = true;
            this.textBox19.Visible = true;
            this.textBox20.Visible = true;
            this.textBox21.Visible = true;
            this.textBox22.Visible = true;
            this.textBox23.Visible = true;
            this.textBox24.Visible = true;
            this.textBox25.Visible = true;
            this.textBox26.Visible = true;
            this.textBox27.Visible = true;
            this.textBox28.Visible = true;
            this.textBox29.Visible = true;
            this.textBox30.Visible = true;
            this.textBox31.Visible = true;
            this.textBox32.Visible = true;
            this.textBox33.Visible = true;
            this.textBox34.Visible = true;
            this.textBox35.Visible = true;
            this.textBox36.Visible = true;
            this.textBox37.Visible = true;
            this.textBox38.Visible = true;
            this.textBox39.Visible = true;
            this.textBox40.Visible = true;
            this.textBox41.Visible = true;
            this.textBox42.Visible = true;
            this.textBox43.Visible = true;
            this.textBox44.Visible = true;
            this.textBox45.Visible = true;

            this.textBox4.Text = "0";
            this.textBox5.Text = "0";
            this.textBox6.Text = "0";
            this.textBox7.Text = "0";
            this.textBox8.Text = "0";
            this.textBox9.Text = "0";
            //this.textBox10.Text = "0";
            this.textBox11.Text = "0";
            this.textBox12.Text = "0";
            this.textBox13.Text = "0";
            this.textBox14.Text = "0";
            this.textBox15.Text = "0";
            this.textBox16.Text = "0";
            this.textBox17.Text = "0";
            this.textBox18.Text = "0";
            this.textBox19.Text = "0";
            this.textBox20.Text = "0";
            this.textBox21.Text = "0";
            this.textBox22.Text = "0";
            this.textBox23.Text = "0";
            this.textBox24.Text = "0";
            this.textBox25.Text = "0";
            this.textBox26.Text = "0";
            this.textBox27.Text = "0";
            this.textBox28.Text = "0";
            this.textBox29.Text = "0";
            this.textBox30.Text = "0";
            this.textBox31.Text = "0";
            this.textBox32.Text = "0";
            this.textBox33.Text = "0";
            this.textBox34.Text = "0";
            this.textBox35.Text = "0";
            this.textBox36.Text = "0";
            this.textBox37.Text = "0";
            this.textBox38.Text = "0";
            this.textBox39.Text = "0";
            this.textBox40.Text = "0";
            this.textBox41.Text = "0";
            this.textBox42.Text = "0";
            this.textBox43.Text = "0";
            this.textBox44.Text = "0";
            this.textBox45.Text = "0";
            #endregion
        }

        public void checkSingle()
        {
            #region show
            if (this.textBox8.Text != "0")
                this.extra = label11.Text + " - " + this.extra;
            if (this.textBox11.Text != "0")
                this.extra = label12.Text + " - " + this.extra;
            if (this.textBox13.Text != "0")
                this.extra = label14.Text + " - " + this.extra;
            if (this.textBox12.Text != "0")
                this.extra = label13.Text + " - " + this.extra;
            if (this.textBox16.Text != "0")
                this.extra = label17.Text + " - " + this.extra;
            if (this.textBox17.Text != "0")
                this.extra = label18.Text + " - " + this.extra;
            if (this.textBox15.Text != "0")
                this.extra = label16.Text + " - " + this.extra;
            if (this.textBox14.Text != "0")
                this.extra = label15.Text + " - " + this.extra;
            if (this.textBox18.Text != "0")
                this.extra = label19.Text + " - " + this.extra;
            if (this.textBox19.Text != "0")
                this.extra = label20.Text + " - " + this.extra;
            if (this.textBox20.Text != "0")
                this.extra = label21.Text + " - " + this.extra;
            if (this.textBox21.Text != "0")
                this.extra = label22.Text + " - " + this.extra;
            if (this.textBox22.Text != "0")
                this.extra = label23.Text + " - " + this.extra;
            if (this.textBox23.Text != "0")
                this.extra = label24.Text + " - " + this.extra;
            if (this.textBox24.Text != "0")
                this.extra = label25.Text + " - " + this.extra;
            if (this.textBox25.Text != "0")
                this.extra = label26.Text + " - " + this.extra;
            if (this.textBox26.Text != "0")
                this.extra = label27.Text + " - " + this.extra;
            if (this.textBox27.Text != "0")
                this.extra = label28.Text + " - " + this.extra;
            if (this.textBox28.Text != "0")
                this.extra = label29.Text + " - " + this.extra;
            if (this.textBox29.Text != "0")
                this.extra = label30.Text + " - " + this.extra;
            if (this.textBox30.Text != "0")
                this.extra = label31.Text + " - " + this.extra;
            if (this.textBox31.Text != "0")
                this.extra = label32.Text + " - " + this.extra;
            if (this.textBox32.Text != "0")
                this.extra = label33.Text + " - " + this.extra;
            if (this.textBox33.Text != "0")
                this.extra = label34.Text + " - " + this.extra;
            if (this.textBox34.Text != "0")
                this.extra = label35.Text + " - " + this.extra;
            if (this.textBox35.Text != "0")
                this.extra = label36.Text + " - " + this.extra;
            if (this.textBox36.Text != "0")
                this.extra = label37.Text + " - " + this.extra;
            if (this.textBox37.Text != "0")
                this.extra = label38.Text + " - " + this.extra;
            if (this.textBox38.Text != "0")
                this.extra = label39.Text + " - " + this.extra;
            if (this.textBox39.Text != "0")
                this.extra = label40.Text + " - " + this.extra;
            if (this.textBox40.Text != "0")
                this.extra = label41.Text + " - " + this.extra;
            if (this.textBox41.Text != "0")
                this.extra = label42.Text + " - " + this.extra;
            if (this.textBox42.Text != "0")
                this.extra = label43.Text + " - " + this.extra;
            if (this.textBox43.Text != "0")
                this.extra = label44.Text + " - " + this.extra;
            if (this.textBox44.Text != "0")
                this.extra = label45.Text + " - " + this.extra;
            if (this.textBox45.Text != "0")
                this.extra = label46.Text + " - " + this.extra;
            #endregion
        }

        #region RESTA
        private void button12_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox8.Text);
            this.textBox8.Text = (x - 1).ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox4.Text);
            this.textBox4.Text = (x - 1).ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox5.Text);
            this.textBox5.Text = (x - 1).ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox6.Text);
            this.textBox6.Text = (x - 1).ToString();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int x = int.Parse(this.textBox7.Text);
            this.textBox7.Text = (x - 1).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int x = int.Parse(this.textBox9.Text);
            this.textBox9.Text = (x - 1).ToString();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox11.Text);
            this.textBox11.Text = (x - 1).ToString();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox13.Text);
            this.textBox13.Text = (x - 1).ToString();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox12.Text);
            this.textBox12.Text = (x - 1).ToString();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox17.Text);
            this.textBox17.Text = (x - 1).ToString();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox16.Text);
            this.textBox16.Text = (x - 0.5).ToString();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox15.Text);
            this.textBox15.Text = (x - 1).ToString();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox14.Text);
            this.textBox14.Text = (x - 0.5).ToString();
        }

        private void button89_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox45.Text);
            this.textBox45.Text = (x - 1).ToString();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox25.Text);
            this.textBox25.Text = (x - 0.5).ToString();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox24.Text);
            this.textBox24.Text = (x - 0.5).ToString();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox23.Text);
            this.textBox23.Text = (x - 0.5).ToString();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox22.Text);
            this.textBox22.Text = (x - 1).ToString();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox21.Text);
            this.textBox21.Text = (x - 0.5).ToString();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox20.Text);
            this.textBox20.Text = (x - 0.5).ToString();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox19.Text);
            this.textBox19.Text = (x - 0.5).ToString();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox18.Text);
            this.textBox18.Text = (x - 1).ToString();
        }

        private void button87_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox44.Text);
            this.textBox44.Text = (x - 0.5).ToString();
        }

        private void button81_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox41.Text);
            this.textBox41.Text = (x - 0.5).ToString();
        }

        private void button79_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox40.Text);
            this.textBox40.Text = (x - 0.5).ToString();
        }

        private void button77_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox39.Text);
            this.textBox39.Text = (x - 0.5).ToString();
        }

        private void button75_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox38.Text);
            this.textBox38.Text = (x - 0.5).ToString();
        }

        private void button73_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox37.Text);
            this.textBox37.Text = (x - 0.5).ToString();
        }

        private void button71_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox36.Text);
            this.textBox36.Text = (x - 1).ToString();
        }

        private void button69_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox35.Text);
            this.textBox35.Text = (x - 0.5).ToString();
        }

        private void button67_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox34.Text);
            this.textBox34.Text = (x - 1).ToString();
        }

        private void button85_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox43.Text);
            this.textBox43.Text = (x - 1).ToString();
        }

        private void button65_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox33.Text);
            this.textBox33.Text = (x - 1).ToString();
        }

        private void button63_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox32.Text);
            this.textBox32.Text = (x - 1).ToString();
        }

        private void button61_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox31.Text);
            this.textBox31.Text = (x - 0.5).ToString();
        }

        private void button59_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox30.Text);
            this.textBox30.Text = (x - 0.5).ToString();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox29.Text);
            this.textBox29.Text = (x - 0.5).ToString();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox28.Text);
            this.textBox28.Text = (x - 0.5).ToString();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox27.Text);
            this.textBox27.Text = (x - 1).ToString();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox26.Text);
            this.textBox26.Text = (x - 1).ToString();
        }

        private void button83_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox42.Text);
            this.textBox42.Text = (x - 1).ToString();
        }
        #endregion

        #region SUMA
        private void button14_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox4.Text);
            this.textBox4.Text = (x + 1).ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //SUMAR RB
            Double x = Double.Parse(this.textBox8.Text);
            this.textBox8.Text = (x + 1).ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox5.Text);
            this.textBox5.Text = (x + 1).ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox6.Text);
            this.textBox6.Text = (x + 1).ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox7.Text);
            this.textBox7.Text = (x + 1).ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox9.Text);
            this.textBox9.Text = (x + 1).ToString();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox11.Text);
            this.textBox11.Text = (x + 1).ToString();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox13.Text);
            this.textBox13.Text = (x + 1).ToString();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox12.Text);
            this.textBox12.Text = (x + 1).ToString();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox17.Text);
            this.textBox17.Text = (x + 1).ToString();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox16.Text);
            this.textBox16.Text = (x + 0.5).ToString();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox15.Text);
            this.textBox15.Text = (x + 1).ToString();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox14.Text);
            this.textBox14.Text = (x + 0.5).ToString();
        }

        private void button90_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox45.Text);
            this.textBox45.Text = (x + 0.5).ToString();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox25.Text);
            this.textBox25.Text = (x + 0.5).ToString();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox24.Text);
            this.textBox24.Text = (x + 0.5).ToString();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox23.Text);
            this.textBox23.Text = (x + 0.5).ToString();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox22.Text);
            this.textBox22.Text = (x + 1).ToString();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox21.Text);
            this.textBox21.Text = (x + 0.5).ToString();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox20.Text);
            this.textBox20.Text = (x + 0.5).ToString();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox19.Text);
            this.textBox19.Text = (x + 0.5).ToString();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox18.Text);
            this.textBox18.Text = (x + 1).ToString();
        }

        private void button88_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox44.Text);
            this.textBox44.Text = (x + 0.5).ToString();
        }

        private void button82_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox41.Text);
            this.textBox41.Text = (x + 0.5).ToString();
        }

        private void button80_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox40.Text);
            this.textBox40.Text = (x + 0.5).ToString();
        }

        private void button78_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox39.Text);
            this.textBox39.Text = (x + 0.5).ToString();
        }

        private void button76_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox38.Text);
            this.textBox38.Text = (x + 0.5).ToString();
        }

        private void button74_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox37.Text);
            this.textBox37.Text = (x + 0.5).ToString();
        }

        private void button72_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox36.Text);
            this.textBox36.Text = (x + 1).ToString();
        }

        private void button70_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox35.Text);
            this.textBox35.Text = (x + 0.5).ToString();
        }

        private void button68_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox34.Text);
            this.textBox34.Text = (x + 1).ToString();
        }

        private void button86_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox43.Text);
            this.textBox43.Text = (x + 1).ToString();
        }

        private void button66_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox33.Text);
            this.textBox33.Text = (x + 1).ToString();
        }

        private void button64_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox32.Text);
            this.textBox32.Text = (x + 1).ToString();
        }

        private void button62_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox31.Text);
            this.textBox31.Text = (x + 0.5).ToString();
        }

        private void button60_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox30.Text);
            this.textBox30.Text = (x + 0.5).ToString();
        }

        private void button58_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox29.Text);
            this.textBox29.Text = (x + 0.5).ToString();
        }

        private void button56_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox28.Text);
            this.textBox28.Text = (x + 0.5).ToString();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox27.Text);
            this.textBox27.Text = (x + 1).ToString();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox26.Text);
            this.textBox26.Text = (x + 1).ToString();
        }

        private void button84_Click(object sender, EventArgs e)
        {
            Double x = Double.Parse(this.textBox42.Text);
            this.textBox42.Text = (x + 1).ToString();
        }
        #endregion
        
        #region CALCULA PRECIOS SINGLE
        public double calculaPrecios()
        { 
            xPriceFinal = 0;
            if (this.textBox9.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label11.Text, Double.Parse(this.textBox9.Text));
            if (this.textBox11.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label12.Text, Double.Parse(this.textBox11.Text));
            if (this.textBox12.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label13.Text, Double.Parse(this.textBox12.Text));
            if (this.textBox13.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label14.Text, Double.Parse(this.textBox13.Text));
            if (this.textBox14.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label15.Text, Double.Parse(this.textBox14.Text));
            if (this.textBox15.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label16.Text, Double.Parse(this.textBox15.Text));
            if (this.textBox16.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label17.Text, Double.Parse(this.textBox16.Text));
            if (this.textBox17.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label18.Text, Double.Parse(this.textBox17.Text));
            if (this.textBox18.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label19.Text, Double.Parse(this.textBox18.Text));
            if (this.textBox19.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label20.Text, Double.Parse(this.textBox19.Text));
            if (this.textBox20.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label21.Text, Double.Parse(this.textBox20.Text));
            if (this.textBox21.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label22.Text, Double.Parse(this.textBox21.Text));
            if (this.textBox22.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label23.Text, Double.Parse(this.textBox22.Text));
            if (this.textBox23.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label24.Text, Double.Parse(this.textBox23.Text));
            if (this.textBox24.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label25.Text, Double.Parse(this.textBox24.Text));
            if (this.textBox25.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label26.Text, Double.Parse(this.textBox25.Text));
            if (this.textBox26.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label27.Text, Double.Parse(this.textBox26.Text));
            if (this.textBox27.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label28.Text, Double.Parse(this.textBox27.Text));
            if (this.textBox28.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label29.Text, Double.Parse(this.textBox28.Text));
            if (this.textBox29.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label30.Text, Double.Parse(this.textBox29.Text));
            if (this.textBox30.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label31.Text, Double.Parse(this.textBox30.Text));
            if (this.textBox31.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label32.Text, Double.Parse(this.textBox31.Text));
            if (this.textBox32.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label33.Text, Double.Parse(this.textBox32.Text));
            if (this.textBox33.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label34.Text, Double.Parse(this.textBox33.Text));
            if (this.textBox34.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label35.Text, Double.Parse(this.textBox34.Text));
            if (this.textBox35.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label36.Text, Double.Parse(this.textBox35.Text));
            if (this.textBox36.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label37.Text, Double.Parse(this.textBox36.Text));
            if (this.textBox37.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label38.Text, Double.Parse(this.textBox37.Text));
            if (this.textBox38.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label39.Text, Double.Parse(this.textBox38.Text));
            if (this.textBox39.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label40.Text, Double.Parse(this.textBox39.Text));
            if (this.textBox40.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label41.Text, Double.Parse(this.textBox40.Text));
            if (this.textBox41.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label42.Text, Double.Parse(this.textBox41.Text));
            if (this.textBox42.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label43.Text, Double.Parse(this.textBox42.Text));
            if (this.textBox43.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label44.Text, Double.Parse(this.textBox43.Text));
            if (this.textBox44.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label45.Text, Double.Parse(this.textBox44.Text));
            if (this.textBox45.Text != "0")
                xPriceFinal = xPriceFinal + this.xLP.price(this.label46.Text, Double.Parse(this.textBox45.Text));
            return xPriceFinal;
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            //MOSTRAR PEDIDOS
            this.dateTimePicker1.Visible = true;
            this.dateTimePicker2.Visible = true;

            this.button1.Visible = false;
            this.button2.Visible = false;
        }

        private void button91_Click(object sender, EventArgs e)
        {
            this.dateTimePicker1.Visible = false;
            this.dateTimePicker2.Visible = false;

            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Worksheet1");

                FileInfo excelFile = new FileInfo(@"C:\Users\feder\Desktop\test.xlsx");
                excel.SaveAs(excelFile);
            }
        }
    }
}
