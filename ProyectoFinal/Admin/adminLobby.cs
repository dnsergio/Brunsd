using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.Admin
{
    public partial class adminLobby : DevExpress.XtraEditors.XtraForm
    {
        public adminLobby()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add ap = new Add();
            ap.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addShop ap = new addShop();
            ap.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            all2 a = new all2();
            a.Show();
            this.Hide();
        }

        private void adminLobby_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            all_pro ap = new all_pro();
            ap.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            price_pro ap = new price_pro();
            ap.Show();
            this.Hide();
        }
    }
}