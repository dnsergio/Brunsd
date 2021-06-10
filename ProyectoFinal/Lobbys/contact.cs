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
    public partial class contact : Form
    {
        string nombre;
        Dictionary<int, Helper.wrapperProduct> mapProducts = new Dictionary<int, Helper.wrapperProduct>();

        public contact(string nombre)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pro_user con = new pro_user(nombre);
            con.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            probuy con = new probuy(nombre);
            con.Show();
            this.Hide();
        }
    }
}

