using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.Admin
{
    public partial class bu_res : DevExpress.XtraEditors.XtraForm
    {
        Helper.wrapperProduct product;
        all_pro pro;
        public bu_res(Helper.wrapperProduct product, all_pro pro)
        {
            InitializeComponent();

            textBox4.Text = product.Name;
            textBox5.Text = product.Stock.ToString();

            this.pro = pro;
            this.product = product;
        }

        
        private void bu_res_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Helper helperclass = new Helper();

            int stockDB = int.Parse(product.Stock);

            using (SqlConnection conection = new SqlConnection(helperclass.getConnectionDB(@"(localdb)\BrunsdDB1", "BrunsdDB1")))
            {

                conection.Open();

                string querystock = "SELECT stockPro FROM Productos WHERE nombrePro=@nombreProd";

                SqlCommand cmdstock = new SqlCommand(querystock, conection);

                cmdstock.Parameters.AddWithValue("@nombreProd", product.Name);

                using (SqlDataReader dataReader = cmdstock.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        stockDB = int.Parse(dataReader["stockPro"].ToString());
                    }
                }
                //update stock y ahi restarlo

                int finalstock = stockDB + int.Parse(textBox6.Text);

                string queryUpdate = "UPDATE Productos SET stockPro = " + finalstock + " WHERE nombrePro=@nombreProd";

                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conection);

                cmdUpdate.Parameters.AddWithValue("@nombreProd", product.Name);

                cmdUpdate.ExecuteNonQuery();

                MessageBox.Show("Stock Cambiado");

                pro.getData();
                pro.paintEmails();

                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bu_res_Load_1(object sender, EventArgs e)
        {

        }
    }
}