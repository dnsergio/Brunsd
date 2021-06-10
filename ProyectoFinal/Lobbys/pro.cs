using System;
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
using System.Text.RegularExpressions;

namespace ProyectoFinal
{
    public partial class pro : Form
    {
        string nombre;
        Dictionary<int, Helper.wrapperProduct> mapProducts = new Dictionary<int, Helper.wrapperProduct>();

        public pro(string nombre)
        {
            InitializeComponent();
            this.nombre = nombre;


        }


        private void pro_multi_Load(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            pro pro = new pro(nombre);
            pro.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            sale2 pro = new sale2(nombre);
            pro.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            shops shop = new shops(nombre);
            shop.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            contact con = new contact(nombre);
            con.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/brunsdproyecto/");
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/Brunds5");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void bu_lobby_Click(object sender, EventArgs e)
        {
            lobby1 l1 = new lobby1(nombre);
            l1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            pro_elec pe = new pro_elec(nombre);
            pe.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            pro_home pe = new pro_home(nombre);
            pe.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pro_ropa pe = new pro_ropa(nombre);
            pe.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pro_videog pe = new pro_videog(nombre);
            pe.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            pro_garden pe = new pro_garden(nombre);
            pe.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            pro_sport pe = new pro_sport(nombre);
            pe.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            pro_multii pe = new pro_multii(nombre);
            pe.Show();
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {

            pro_other pe = new pro_other(nombre);
            pe.Show();
            this.Hide();
        }
    }
}

